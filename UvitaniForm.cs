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
    public partial class UvitaniForm : Form
    {
        public UvitaniForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoFaceDetectionForm videoFaceDetectionForm = new VideoFaceDetectionForm();
            videoFaceDetectionForm.Show();
            this.Hide();
        }
    }
}
