using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.CvEnum;

namespace FaceRecognition
{
    public partial class ImageFaceDetectionForm : Form
    {
        private readonly VideoFaceDetectionForm parent;
        private Rectangle face;
        private Image<Bgr, byte> rawImage;
        private bool picDetected = false;
        public ImageFaceDetectionForm(VideoFaceDetectionForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Vybrat fotku",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "jpg",
                Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF",
                RestoreDirectory = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Kontrola, zda je vybraný soubor obrázek
                    var extension = Path.GetExtension(openFileDialog1.FileName).ToLower();
                    var allowedExtensions = new List<string> { ".bmp", ".jpg", ".jpeg", ".gif", ".png", ".tiff" };
                    if (!allowedExtensions.Contains(extension))
                    {
                        MessageBox.Show("Vybraný soubor není obrázek. Prosím, vyberte platný obrázek.", "Neplatný formát souboru", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    PictureBox imageControl = new PictureBox();

                    var img1 = new Image<Bgr, byte>(openFileDialog1.FileName);
                    rawImage = img1.Resize(600,
                        (int)(600.0 / img1.Width * img1.Height), Inter.Cubic);

                    Image<Gray, byte> grayImage = new Image<Gray, byte>(rawImage.Width, rawImage.Height);
                    CvInvoke.CvtColor(rawImage, grayImage, ColorConversion.Bgr2Gray);

                    // upravit vlastnosti obrázku
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    // vytvoři vlastnosti čtverce okolo obličeje
                    Rectangle[] faces = parent.haarCascade.DetectMultiScale(grayImage, 1.2, 1, Size.Empty, Size.Empty);

                    Image<Bgr, byte> imageWithRectangle = rawImage.Clone();

                    // jestliže je detekován obličej
                    if (faces.Length < 5)
                    {// podporujeme obrázky pouze s jedním obličejem
                        // vytvořit čtverec okolo obličeje
                        face = faces[0];
                        CvInvoke.Rectangle(imageWithRectangle, face, new Bgr(Color.Red).MCvScalar, 2);
                        picDetected = true;
                    }
                    else
                    {
                        MessageBox.Show("Na fotce nebyl detekován správný počet obličejů, očekávaný počet je jeden obličej." +  "Zkuste to znovu", "Neplatná detekce obličejů", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        picDetected = false;
                        return;
                    }

                    imageControl.Image = imageWithRectangle.ToBitmap();

                    // upravit velikost obrázku pro zobrazení v PictureBoxu
                    var zoom = Math.Min((double)PhotoPreview.Width / imageControl.Image.Width, (double)PhotoPreview.Height / imageControl.Image.Height);
                    var width = (int)(imageControl.Image.Width * zoom);
                    var height = (int)(imageControl.Image.Height * zoom);
                    imageControl.Image = new Bitmap(imageControl.Image, new Size(width, height));

                    // zobrazit upravený obrázek v PictureBoxu
                    imageControl.SizeMode = PictureBoxSizeMode.Zoom;
                    imageControl.Dock = DockStyle.Fill;
                    PhotoPreview.Controls.Clear();
                    PhotoPreview.Controls.Add(imageControl);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (!picDetected)
            {
                MessageBox.Show("Není žádný obličej k uložení. Prosím, detekujte obličej než jej přidáte.", "Chybějící obličej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string personName = txtPersonsName.Text.Trim();
            if (!parent.ValidFilename(personName))
            {
                MessageBox.Show("Jméno osoby obsahuje neplatné znaky. Zadejte prosím platné jméno..", "Neplatné jméno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonsName.Text))
            {
                MessageBox.Show("Jméno chybí", "Prosím pojmenuj obličej.", MessageBoxButtons.OK);
                return;
            }

            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            Image<Bgr, byte> resultImage = rawImage;
            resultImage.ROI = face;

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonsName.Text + "_" + timestamp + ".jpg");

            

            MessageBox.Show("Obličej byl úspěšně pojmenován a přidán do databáze.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);

            parent.TrainImagesFromDir();
            parent.LoadTrainedFaces();
            txtPersonsName.Text = string.Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpText = "Nápověda k nahrávání obličeje ze souboru:\n\n" +
                          "1. Vyberte soubor ve správném formátu jpg, bmp, jpeg, tiff, gif, png.\n" +
                          "2. Pamatujte, že můžete nahrát pouze jeden obličej, nevybírejte obrázky s větším počtem obličejů!\n" +
                          "3. Obličej se po správném zvolení sám detekuje.\n" +
                          "3. Pro co nejpřesnější detekci zvolte více dané osoboy\n" +
                          "4. Zadejte jméno osoby a stiskněte tlačítko 'Přidat obličej', pokud chcete přidat obličej do databáze.\n" +
                          "5. Pro navrácení zpátky do aplikace použijte tlačítko 'Zpět'\n\n" +
                          "Správu uložených obličejů můžete provést v hlavním okně aplikace, pro správu používejte tlačítka 'Zobrazit databázi', 'Odstranit obličej' a 'Přejmenovat obličej'.";

            MessageBox.Show(helpText, "Nápověda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
