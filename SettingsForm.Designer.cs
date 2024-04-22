namespace VocalConnect
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            saveButton = new Button();
            zoomGroupBox = new GroupBox();
            kHZoomCodeTextbox = new TextBox();
            kHZoomIDTextbox = new TextBox();
            groupBox1 = new GroupBox();
            ministryZoomCodeTextbox = new TextBox();
            ministryZoomIDTextbox = new TextBox();
            groupBox2 = new GroupBox();
            groupZoomCodeTextbox = new TextBox();
            groupZoomIDTextbox = new TextBox();
            zoomGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            saveButton.Location = new Point(12, 368);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(324, 42);
            saveButton.TabIndex = 7;
            saveButton.Text = "Sauvegarder";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // zoomGroupBox
            // 
            zoomGroupBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            zoomGroupBox.Controls.Add(kHZoomCodeTextbox);
            zoomGroupBox.Controls.Add(kHZoomIDTextbox);
            zoomGroupBox.Location = new Point(12, 16);
            zoomGroupBox.Name = "zoomGroupBox";
            zoomGroupBox.Size = new Size(324, 107);
            zoomGroupBox.TabIndex = 5;
            zoomGroupBox.TabStop = false;
            zoomGroupBox.Text = "Salle du Royaume";
            // 
            // kHZoomCodeTextbox
            // 
            kHZoomCodeTextbox.Location = new Point(6, 59);
            kHZoomCodeTextbox.Name = "kHZoomCodeTextbox";
            kHZoomCodeTextbox.PlaceholderText = "Code demandé par la réunion Zoom";
            kHZoomCodeTextbox.Size = new Size(312, 23);
            kHZoomCodeTextbox.TabIndex = 1;
            // 
            // kHZoomIDTextbox
            // 
            kHZoomIDTextbox.Location = new Point(6, 30);
            kHZoomIDTextbox.Name = "kHZoomIDTextbox";
            kHZoomIDTextbox.PlaceholderText = "ID de la réunion Zoom";
            kHZoomIDTextbox.Size = new Size(312, 23);
            kHZoomIDTextbox.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(ministryZoomCodeTextbox);
            groupBox1.Controls.Add(ministryZoomIDTextbox);
            groupBox1.Location = new Point(12, 129);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(324, 107);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Réunion de prédication en semaine";
            // 
            // ministryZoomCodeTextbox
            // 
            ministryZoomCodeTextbox.Location = new Point(6, 59);
            ministryZoomCodeTextbox.Name = "ministryZoomCodeTextbox";
            ministryZoomCodeTextbox.PlaceholderText = "Code demandé par la réunion Zoom";
            ministryZoomCodeTextbox.Size = new Size(312, 23);
            ministryZoomCodeTextbox.TabIndex = 1;
            // 
            // ministryZoomIDTextbox
            // 
            ministryZoomIDTextbox.Location = new Point(6, 30);
            ministryZoomIDTextbox.Name = "ministryZoomIDTextbox";
            ministryZoomIDTextbox.PlaceholderText = "ID de la réunion Zoom";
            ministryZoomIDTextbox.Size = new Size(312, 23);
            ministryZoomIDTextbox.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(groupZoomCodeTextbox);
            groupBox2.Controls.Add(groupZoomIDTextbox);
            groupBox2.Location = new Point(12, 242);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(324, 107);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Groupe de prédication";
            // 
            // groupZoomCodeTextbox
            // 
            groupZoomCodeTextbox.Location = new Point(6, 59);
            groupZoomCodeTextbox.Name = "groupZoomCodeTextbox";
            groupZoomCodeTextbox.PlaceholderText = "Code demandé par la réunion Zoom";
            groupZoomCodeTextbox.Size = new Size(312, 23);
            groupZoomCodeTextbox.TabIndex = 1;
            // 
            // groupZoomIDTextbox
            // 
            groupZoomIDTextbox.Location = new Point(6, 30);
            groupZoomIDTextbox.Name = "groupZoomIDTextbox";
            groupZoomIDTextbox.PlaceholderText = "ID de la réunion Zoom";
            groupZoomIDTextbox.Size = new Size(312, 23);
            groupZoomIDTextbox.TabIndex = 0;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 422);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(saveButton);
            Controls.Add(zoomGroupBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paramètres de VocalConnect";
            zoomGroupBox.ResumeLayout(false);
            zoomGroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button saveButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private GroupBox zoomGroupBox;
        private TextBox zoomCodeTextBox;
        private TextBox kHZoomCodeTextbox;
        private TextBox kHZoomIDTextbox;
        private GroupBox groupBox1;
        private TextBox ministryZoomCodeTextbox;
        private TextBox ministryZoomIDTextbox;
        private GroupBox groupBox2;
        private TextBox groupZoomCodeTextbox;
        private TextBox groupZoomIDTextbox;
    }
}