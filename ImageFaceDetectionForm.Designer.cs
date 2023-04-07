namespace FaceRecognition
{
    partial class ImageFaceDetectionForm
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.txtPersonsName = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.PhotoPreview = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Orange;
            this.btnBrowse.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBrowse.Location = new System.Drawing.Point(600, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(179, 29);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Procházet obrázky";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.Orange;
            this.btnAddPerson.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddPerson.Location = new System.Drawing.Point(600, 47);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(179, 29);
            this.btnAddPerson.TabIndex = 6;
            this.btnAddPerson.Text = "Přidat obličej";
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // txtPersonsName
            // 
            this.txtPersonsName.Location = new System.Drawing.Point(654, 82);
            this.txtPersonsName.Name = "txtPersonsName";
            this.txtPersonsName.Size = new System.Drawing.Size(125, 27);
            this.txtPersonsName.TabIndex = 7;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightCoral;
            this.btnBack.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(685, 374);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 29);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Zpět";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PhotoPreview
            // 
            this.PhotoPreview.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PhotoPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoPreview.Location = new System.Drawing.Point(0, 0);
            this.PhotoPreview.Name = "PhotoPreview";
            this.PhotoPreview.Size = new System.Drawing.Size(594, 453);
            this.PhotoPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PhotoPreview.TabIndex = 9;
            this.PhotoPreview.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnHelp.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHelp.Location = new System.Drawing.Point(617, 409);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(162, 29);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "Nápověda";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // ImageFaceDetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.PhotoPreview);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtPersonsName);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageFaceDetectionForm";
            this.Text = "Detekovat obličej ze souboru";
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnBrowse;
        private Button btnAddPerson;
        private TextBox txtPersonsName;
        private Button btnBack;
        private PictureBox PhotoPreview;
        private Button btnHelp;
    }
}