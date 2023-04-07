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

namespace FaceRecognition
{
    public partial class SavedFacesForm : Form
    {
        private void SavedFacesForm_Load(object sender, EventArgs e)
        {

        }
        public SavedFacesForm(List<Image<Gray, byte>> trainedFaces, List<string> personsNames)
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Složka TrainedImages nebyla nalezena.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(path, "*.jpg");

            foreach (string file in files)
            {
                string personName = Path.GetFileNameWithoutExtension(file).Split('_')[0];
                personsNames.Add(personName);
                //Image<Gray, byte> faceImage = new Image<Gray, byte>(file);
                //trainedFaces.Add(faceImage);
            }

            tableLayoutPanel.ColumnCount = trainedFaces.Count;
            tableLayoutPanel.RowCount = 2;

            for (int i = 0; i < trainedFaces.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 100;
                pictureBox.Height = 100;
                pictureBox.Image = trainedFaces[i].ToBitmap();
                tableLayoutPanel.Controls.Add(pictureBox, i, 0);

                Label label = new Label();
                label.Text = personsNames[i];
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Width = 100;
                tableLayoutPanel.Controls.Add(label, i, 1);
            }

            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.Dock = DockStyle.Fill;

            tableLayoutPanel.AutoScroll = true;
            this.Controls.Add(tableLayoutPanel);
        }
    
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
