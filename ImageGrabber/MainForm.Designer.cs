namespace ImageGrabber
{
    partial class MainForm
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
            this.UrlBox = new System.Windows.Forms.TextBox();
            this.CheckButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.PageInfoBox = new System.Windows.Forms.GroupBox();
            this.PageInfoLabel = new System.Windows.Forms.Label();
            this.folderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.DownloadingLabel = new System.Windows.Forms.Label();
            this.PageInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UrlBox
            // 
            this.UrlBox.Location = new System.Drawing.Point(61, 25);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(365, 20);
            this.UrlBox.TabIndex = 0;
            this.UrlBox.Text = "https://en.wikipedia.org/wiki/Bill_Gates";
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(112, 332);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(114, 38);
            this.CheckButton.TabIndex = 1;
            this.CheckButton.Text = "Check URL";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(256, 332);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(112, 37);
            this.DownloadButton.TabIndex = 3;
            this.DownloadButton.Text = "Download Images";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // PageInfoBox
            // 
            this.PageInfoBox.Controls.Add(this.PageInfoLabel);
            this.PageInfoBox.Location = new System.Drawing.Point(61, 62);
            this.PageInfoBox.Name = "PageInfoBox";
            this.PageInfoBox.Size = new System.Drawing.Size(365, 225);
            this.PageInfoBox.TabIndex = 4;
            this.PageInfoBox.TabStop = false;
            this.PageInfoBox.Text = "Page Info";
            // 
            // PageInfoLabel
            // 
            this.PageInfoLabel.AutoSize = true;
            this.PageInfoLabel.Location = new System.Drawing.Point(18, 27);
            this.PageInfoLabel.Name = "PageInfoLabel";
            this.PageInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.PageInfoLabel.TabIndex = 0;
            // 
            // DownloadingLabel
            // 
            this.DownloadingLabel.AutoSize = true;
            this.DownloadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadingLabel.Location = new System.Drawing.Point(164, 300);
            this.DownloadingLabel.Name = "DownloadingLabel";
            this.DownloadingLabel.Size = new System.Drawing.Size(158, 20);
            this.DownloadingLabel.TabIndex = 5;
            this.DownloadingLabel.Text = "Downloading Images";
            this.DownloadingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DownloadingLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 388);
            this.Controls.Add(this.DownloadingLabel);
            this.Controls.Add(this.PageInfoBox);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.UrlBox);
            this.Name = "MainForm";
            this.Text = "Image Grabber";
            this.PageInfoBox.ResumeLayout(false);
            this.PageInfoBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlBox;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.GroupBox PageInfoBox;
        private System.Windows.Forms.Label PageInfoLabel;
        private System.Windows.Forms.FolderBrowserDialog folderSelector;
        private System.Windows.Forms.Label DownloadingLabel;
    }
}

