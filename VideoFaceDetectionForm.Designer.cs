using Emgu.CV.UI;
namespace FaceRecognition
{
    partial class VideoFaceDetectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoFaceDetectionForm));
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnDetectFaces = new System.Windows.Forms.Button();
            this.btnDeleteFace = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnRenameFace = new System.Windows.Forms.Button();
            this.btnShowFaces = new System.Windows.Forms.Button();
            this.txtDeletePerson = new System.Windows.Forms.TextBox();
            this.txtPersonsName = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.txtOldName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picCapture = new Emgu.CV.UI.ImageBox();
            this.picDetected = new Emgu.CV.UI.ImageBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddPerson.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddPerson.Location = new System.Drawing.Point(811, 12);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(169, 29);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.Text = "Přidat obličej";
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnDetectFaces
            // 
            this.btnDetectFaces.BackColor = System.Drawing.Color.Orange;
            this.btnDetectFaces.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDetectFaces.Location = new System.Drawing.Point(619, 82);
            this.btnDetectFaces.Name = "btnDetectFaces";
            this.btnDetectFaces.Size = new System.Drawing.Size(169, 29);
            this.btnDetectFaces.TabIndex = 4;
            this.btnDetectFaces.Text = "Detekovat obličej";
            this.btnDetectFaces.UseVisualStyleBackColor = false;
            this.btnDetectFaces.Click += new System.EventHandler(this.btnDetectFaces_Click);
            // 
            // btnDeleteFace
            // 
            this.btnDeleteFace.BackColor = System.Drawing.Color.Salmon;
            this.btnDeleteFace.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteFace.Location = new System.Drawing.Point(811, 82);
            this.btnDeleteFace.Name = "btnDeleteFace";
            this.btnDeleteFace.Size = new System.Drawing.Size(169, 29);
            this.btnDeleteFace.TabIndex = 5;
            this.btnDeleteFace.Text = "Odstranit obličej";
            this.btnDeleteFace.UseVisualStyleBackColor = false;
            this.btnDeleteFace.Click += new System.EventHandler(this.btnDeleteFace_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.Orange;
            this.btnCapture.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCapture.Location = new System.Drawing.Point(619, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(169, 29);
            this.btnCapture.TabIndex = 6;
            this.btnCapture.Text = "Začít snímat";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnRenameFace
            // 
            this.btnRenameFace.BackColor = System.Drawing.Color.Orange;
            this.btnRenameFace.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRenameFace.Location = new System.Drawing.Point(811, 150);
            this.btnRenameFace.Name = "btnRenameFace";
            this.btnRenameFace.Size = new System.Drawing.Size(169, 29);
            this.btnRenameFace.TabIndex = 8;
            this.btnRenameFace.Text = "Přejmenovat obličej";
            this.btnRenameFace.UseVisualStyleBackColor = false;
            this.btnRenameFace.Click += new System.EventHandler(this.btnRenameFace_Click);
            // 
            // btnShowFaces
            // 
            this.btnShowFaces.BackColor = System.Drawing.Color.Gold;
            this.btnShowFaces.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShowFaces.Location = new System.Drawing.Point(811, 417);
            this.btnShowFaces.Name = "btnShowFaces";
            this.btnShowFaces.Size = new System.Drawing.Size(169, 29);
            this.btnShowFaces.TabIndex = 9;
            this.btnShowFaces.Text = "Zobrazit databázi obličejů";
            this.btnShowFaces.UseVisualStyleBackColor = false;
            this.btnShowFaces.Click += new System.EventHandler(this.btnShowFaces_Click);
            // 
            // txtDeletePerson
            // 
            this.txtDeletePerson.Location = new System.Drawing.Point(811, 117);
            this.txtDeletePerson.Name = "txtDeletePerson";
            this.txtDeletePerson.Size = new System.Drawing.Size(125, 27);
            this.txtDeletePerson.TabIndex = 10;
            // 
            // txtPersonsName
            // 
            this.txtPersonsName.Location = new System.Drawing.Point(811, 49);
            this.txtPersonsName.Name = "txtPersonsName";
            this.txtPersonsName.Size = new System.Drawing.Size(125, 27);
            this.txtPersonsName.TabIndex = 11;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(619, 356);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(151, 104);
            this.listBox1.TabIndex = 12;
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(894, 218);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(86, 27);
            this.txtNewName.TabIndex = 13;
            // 
            // txtOldName
            // 
            this.txtOldName.Location = new System.Drawing.Point(894, 185);
            this.txtOldName.Name = "txtOldName";
            this.txtOldName.Size = new System.Drawing.Size(86, 27);
            this.txtOldName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(799, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Staré jméno:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(799, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nové jméno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(619, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 40);
            this.label3.TabIndex = 17;
            this.label3.Text = "Jména obličejů\r\nuložených v databázi:\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(619, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Detekovaný obličej:";
            // 
            // picCapture
            // 
            this.picCapture.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCapture.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.picCapture.Location = new System.Drawing.Point(2, 12);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(611, 470);
            this.picCapture.TabIndex = 2;
            this.picCapture.TabStop = false;
            // 
            // picDetected
            // 
            this.picDetected.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picDetected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDetected.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.picDetected.Location = new System.Drawing.Point(619, 150);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(169, 155);
            this.picDetected.TabIndex = 2;
            this.picDetected.TabStop = false;
            // 
            // imageBox1
            // 
            this.imageBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.Location = new System.Drawing.Point(910, 326);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(73, 85);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.Location = new System.Drawing.Point(811, 326);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(72, 85);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(805, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 40);
            this.label5.TabIndex = 19;
            this.label5.Text = "Detekovaný\r\nobličej:\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(910, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 60);
            this.label6.TabIndex = 20;
            this.label6.Text = "Obličej s \r\nnejvětší\r\nshodou:\r\n";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(619, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "Detekovat ze souboru";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnHelp.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHelp.Location = new System.Drawing.Point(811, 452);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(172, 29);
            this.btnHelp.TabIndex = 22;
            this.btnHelp.Text = "Nápověda";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // VideoFaceDetectionForm
            // 
            this.AcceptButton = this.btnCapture;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(998, 486);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.picCapture);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOldName);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtPersonsName);
            this.Controls.Add(this.txtDeletePerson);
            this.Controls.Add(this.btnShowFaces);
            this.Controls.Add(this.btnRenameFace);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnDeleteFace);
            this.Controls.Add(this.btnDetectFaces);
            this.Controls.Add(this.btnAddPerson);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VideoFaceDetectionForm";
            this.Text = "Face Recognition App";
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnAddPerson;
        private Button btnDetectFaces;
        private Button btnDeleteFace;
        private Button btnCapture;
        private Button btnRenameFace;
        private Button btnShowFaces;
        private TextBox txtDeletePerson;
        private TextBox txtPersonsName;
        private ListBox listBox1;
        private TextBox txtNewName;
        private TextBox txtOldName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Emgu.CV.UI.ImageBox picCapture;
        private Emgu.CV.UI.ImageBox picDetected;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button btnHelp;
    }
}