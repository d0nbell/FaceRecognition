using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Text.RegularExpressions;

namespace FaceRecognition
{
    public partial class VideoFaceDetectionForm : Form
    {
        private VideoCapture videoCapture = null;
        private Image<Bgr, byte> currentFrame = null;
        Mat frame = new Mat();


        public CascadeClassifier haarCascade = new CascadeClassifier("haarcascade_frontalface_alt.xml");

        List<Image<Gray, byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabels = new List<int>();
        List<string> personsNames = new List<string>();


        // booleanové funkce 
        private bool IfPicDetected = false;
        private bool facesDetectionEnabled = false;
        private bool capturing = false;
        private bool EnableSaveImage = false;
        private bool isTrained = false;

        EigenFaceRecognizer recognizer;
        public VideoFaceDetectionForm()
        {
            InitializeComponent();
            TrainImagesFromDir();
            LoadTrainedFaces();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!capturing)
            {
                // Spuštění kamery
                if (videoCapture != null) videoCapture.Dispose();
                videoCapture = new VideoCapture();
                Application.Idle += ProcessFrame;

                // Změna textu tlačítka a aktualizace zachycující proměnné
                btnCapture.Text = "Zastavit kameru";
                capturing = true;
            }
            else
            {

                if (videoCapture != null)
                {
                    Application.Idle -= ProcessFrame;
                    videoCapture.Dispose();
                    videoCapture = null;
                    picCapture.Image = null;
                }


                btnCapture.Text = "Zapnout kameru";
                capturing = false;
            }
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            //1. krok začít snímat
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                frame = videoCapture.QueryFrame();
                currentFrame = frame.ToImage<Bgr, byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);

                Image<Bgr, byte> rawImage = currentFrame.Convert<Bgr, byte>();

                //2. krok detekovat obličej
                if (facesDetectionEnabled)
                {

                    // převedení z Bgr formátu do šedého formátu (pro lepší prácí s detekci)
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);

                    // upravit vlastnosti obrázku
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    // vytvoři vlastnosti čtverce okolo obličeje
                    Rectangle[] faces = haarCascade.DetectMultiScale(grayImage, 1.2, 1, Size.Empty, Size.Empty);

                    // jestliže je detekován obličej
                    if (faces.Length > 0)
                    {

                        foreach (var face in faces)
                        {
                            // vytvořit čtverec okolo obličeje
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);


                            // zobrazit detekovaný obličej v picDetected
                            Image<Bgr, byte> resultImage = rawImage;
                            resultImage.ROI = face;
                            picCapture.SizeMode = PictureBoxSizeMode.Zoom;
                            picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                            picDetected.Image = resultImage;
                            IfPicDetected = true;
                            
                            if (EnableSaveImage)
                            {
                                // vytvoříme directory s relativní cestou, pokud neexistuje
                                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                                resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonsName.Text + "_" + timestamp + ".jpg");

                                TrainImagesFromDir();
                                LoadTrainedFaces();
                            }
                            EnableSaveImage = false;



                            // 5. krok rozpznání obličeje
                            if (isTrained)
                            {
                                Image<Gray, byte> grayFaceResult = resultImage.Convert<Gray, byte>().Resize(200, 200, Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                                var result = recognizer.Predict(grayFaceResult);
                                imageBox1.Image = grayFaceResult;
                                imageBox2.Image = TrainedFaces[result.Label];

                                string displayName = JmenoBezCisla(personsNames[result.Label]);
                                //Debug.WriteLine(result.Label + " " + result.Distance);

                                //Zde nalezené výsledky známých tváří
                                if (result.Label != -1 && result.Distance < 2000)
                                {
                                    CvInvoke.PutText(currentFrame, displayName, new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                }
                                //zde výsledky nenašly žádné známé tváře
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                                }
                            }
                        }
                    }
                }

                //načtení zachycené videa do picCapture
                picCapture.Image = currentFrame;
            }


            if (currentFrame != null)
                currentFrame.Dispose();
        }

        private void btnDetectFaces_Click(object sender, EventArgs e)
        {
            facesDetectionEnabled = true;
        }
        public void LoadTrainedFaces()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(personsNames.ToHashSet().ToArray());
        }
        private string JmenoBezCisla(string fullName)
        {
            string[] nameParts = fullName.Split('_');
            if (nameParts.Length > 1)
            {
                return string.Join("_", nameParts.Take(nameParts.Length - 1));
            }
            return fullName;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            string personName = txtPersonsName.Text.Trim();

            if (!IfPicDetected)
            {
                MessageBox.Show("Není žádný obličej k uložení. Prosím, detekujte obličej než jej přidáte.", "Žádný obličej nenalezen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrEmpty(txtPersonsName.Text))
            {
                MessageBox.Show("Jméno chybí", "Prosím pojmenuj obličej.", MessageBoxButtons.OK);
                return;
            }

            if (!ValidFilename(personName))
            {
                MessageBox.Show("Jméno osoby obsahuje neplatné znaky." + "Používejte pouze písmena abecedy", "Neplatné jméno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            if (PersonNameExists(personName))
            {
                MessageBox.Show("Jméno osoby již v databázi existuje. Prosím zvolte jiné jméno.", "Jméno osoby již existuje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            EnableSaveImage = true;
            MessageBox.Show("Obličej byl úspěšně pojmenován a přidán do databáze.", "Obličej nalezen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //txtPersonsName.Text = string.Empty;
        }


        private bool PersonNameExists(string personName)
        {
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                string existingName = file.Split('\\').Last().Split('_')[0];
                if (personName.Equals(existingName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


        //public bool TrainImagesFromDir()
        //{
        //    int ImagesCount = 0;
        //    double Threshold = 2000;
        //    TrainedFaces.Clear();
        //    PersonsLabels.Clear();
        //    personsNames.Clear();

        //    // Přidáme slovník pro mapování jmen osob na jedinečné štítky
        //    Dictionary<string, int> nameLabels = new Dictionary<string, int>();
        //    int currentLabel = 0;

        //    try
        //    {
        //        string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
        //        string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

        //        foreach (var file in files)
        //        {
        //            Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
        //            CvInvoke.EqualizeHist(trainedImage, trainedImage);
        //            TrainedFaces.Add(trainedImage);

        //            string name = file.Split('\\').Last().Split('_')[0];

        //            // Pokud jméno osoby ještě není v našem slovníku, přidáme jej a přiřadíme mu nový štítek
        //            if (!nameLabels.ContainsKey(name))
        //            {
        //                nameLabels[name] = currentLabel;
        //                currentLabel++;
        //            }

        //            // Přidáme štítek osoby do seznamu PersonsLabels
        //            PersonsLabels.Add(nameLabels[name]);
        //            personsNames.Add(name);
        //            ImagesCount++;
        //        }

        //        if (TrainedFaces.Count() > 0)
        //        {


        //            // Zde musíme převést obě pole na požadovéné pole pro funkci recognizer recognizer.Train(Mat[] images, int [] labels)
        //            Image<Gray, Byte>[] Faces = TrainedFaces.ToArray();
        //            VectorOfMat vectorOfMat = new VectorOfMat();
        //            vectorOfMat.Push(Faces);
        //            int[] labels = PersonsLabels.ToArray();
        //            VectorOfInt vectorOfInt = new VectorOfInt();
        //            vectorOfInt.Push(labels);
        //            recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
        //            recognizer.Train(vectorOfMat, vectorOfInt);



        //            isTrained = true;

        //            return true;
        //        }
        //        else
        //        {
        //            isTrained = false;
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        isTrained = false;
        //        MessageBox.Show("Chyba při tréninku obličeje: " + ex.Message);
        //        return false;
        //    }
        //}
        public bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            PersonsLabels.Clear();
            personsNames.Clear();

            // Přidáme slovník pro mapování jmen osob na jedinečné štítky
            Dictionary<string, int> nameLabels = new Dictionary<string, int>();
            int currentLabel = 0;

            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);

                    string name = file.Split('\\').Last().Split('_')[0];

                    // Pokud jméno osoby ještě není v našem slovníku, přidáme jej a přiřadíme mu nový štítek
                    if (!nameLabels.ContainsKey(name))
                    {
                        nameLabels[name] = currentLabel;
                        currentLabel++;
                    }

                    // Přidáme štítek osoby do seznamu PersonsLabels
                    PersonsLabels.Add(nameLabels[name]);
                    personsNames.Add(name);

                    // přidání obličeje do listu TrainedFaces pro danou osobu
                    if (TrainedFaces.Count() == currentLabel)
                    {
                        TrainedFaces.Add(new List<Image<Gray, byte>>());
                    }
                    TrainedFaces[nameLabels[name]].Add(trainedImage);

                    ImagesCount++;
                }

                if (TrainedFaces.Count() > 0)
                {
                    // Převod listu TrainedFaces na pole
                    List<Image<Gray, byte>>[] trainedFacesList = TrainedFaces.ToArray();
                    Image<Gray, byte>[][] trainedFacesArray = new Image<Gray, byte>[trainedFacesList.Length][];
                    for (int i = 0; i < trainedFacesList.Length; i++)
                    {
                        trainedFacesArray[i] = trainedFacesList[i].ToArray();
                    }

                    // Převod listu PersonsLabels na pole
                    int[] labels = PersonsLabels.ToArray();

                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(trainedFacesArray, labels);

                    isTrained = true;
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Chyba při tréninku obličeje: " + ex.Message);
                return false;
            }
        }



        private void btnShowFaces_Click(object sender, EventArgs e)
        {
            SavedFacesForm savedFacesForm = new SavedFacesForm(TrainedFaces, personsNames);
            savedFacesForm.ShowDialog();
            //ToolTip toolTip = new ToolTip();
            //toolTip.SetToolTip(btnShowFaces, "Zobrazí tváře uložené v databázi.");
        }

        private void btnDeleteFace_Click(object sender, EventArgs e)
        {
            string personToDelete = txtDeletePerson.Text;
            personToDelete.Trim();
            if (!ValidFilename(personToDelete))
            {
                MessageBox.Show("Jméno osoby obsahuje neplatné znaky." + "Používejte pouze písmena abecedy.", "Neplatné jméno.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtDeletePerson.Text = string.Empty;
                return;
            }

            // Zkontrolujte, zda jméno osoby existuje
            if (personsNames.Contains(personToDelete))
            {
                // Vyhledání a odstranění všech souborů obličejů patřících této osobě z adresáře TrainedImages.
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, personToDelete + "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    File.Delete(file);
                }

                // aktualizovat seznam natrénovaných obličejů a znovu natrénovat rozpoznávač obličejů.
                TrainImagesFromDir();


                MessageBox.Show("Obličej byl úspěšně odstraněn z databáze.");
                LoadTrainedFaces();
                /*txtDeletePerson.Text = string.Empty*/
                ;

            }
            else
            {
                MessageBox.Show("Tvář s tímto jménem nebyla nalezena.");
                /*txtDeletePerson.Text = string.Empty*/
                ;
            }
        }

        private void btnRenameFace_Click(object sender, EventArgs e)
        {
            string oldName = txtOldName.Text.Trim();
            string newName = txtNewName.Text.Trim();

            if (!ValidFilename(newName) || !ValidFilename(oldName))
            {
                MessageBox.Show("Nový název obsahuje nepovolené znaky nebo je prázdný. " + "Používejte pouze písmena abecedy.", "Neplatné jméno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(oldName) || string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Musí být vyplňěné jméno staré a nové tváře!", "Zadejte jméno obličeje.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            string[] files = Directory.GetFiles(path, oldName + "*.jpg");

            if (files.Length == 0)
            {
                MessageBox.Show("Žádná tvář s tímto jménem nebyla nalezena.");
                return;
            }

            foreach (var file in files)
            {
                string newFileName = file.Replace(oldName, newName);
                File.Move(file, newFileName);
            }


            TrainImagesFromDir();
            MessageBox.Show("Název tváří byl úspěšně přejmenován.");



            LoadTrainedFaces();
            MessageBox.Show("Obličej pod novým jménem je natrénován.");
            //txtOldName.Text = string.Empty;
            //txtNewName.Text = string.Empty;
        }
        public bool ValidFilename(string testName)
        {

            Regex isValid = new Regex(@"^[A-Za-z\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (string.IsNullOrEmpty(testName))
            {
                return false;
            }
            else if (testName.Length > 100)
            {
                return false;
            }
            else if (!isValid.IsMatch(testName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //přejít na detekovat ze souboru form
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ImageFaceDetectionForm(this);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpText = "Nápověda k použití programu:\n\n" +
                      "1. Zmáčkněte tlačítko 'Začít snímat' pro získání snímku obličeje z kamery.\n" +
                      "2. Pokud budete chtít nahrát obličej ze souboru, využijte tlačítko 'Detekovat ze souboru', širší nápověda se vám zobrazí v okně\n" +
                      "3. Stiskněte tlačítko 'Detekovat obličej' pro detekci a rozpoznání obličejů v aktuálním snímku.\n" +
                      "4. Pokud je obličej detekován, zobrazí se v okně 'Detekovaný obličej'.\n" +
                      "5. Zadejte jméno osoby a stiskněte tlačítko 'Přidat obličej', pokud chcete přidat obličej do databáze.\n" +
                      "6. Pro odstranění obličeje z databáze zadejte jméno osoby, kterou chcete odstranit a stiskněte tlačítko 'Odstranit obličej'.\n" +
                      "7. Pro přejmenovaní obličeje musíte zadat staré i nové jméno obličeje, který chcete přejmenovat a stisknout tlačítko 'Přejmenovat obličej'.\n\n" +
                      "Pro správu uložených obličejů používejte tlačítka 'Zobrazit databázi', 'Odstranit obličej' a 'Přejmenovat obličej'.";

            MessageBox.Show(helpText, "Nápověda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
