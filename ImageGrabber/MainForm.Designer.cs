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
            this.folderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.PageInfoLabel = new System.Windows.Forms.Label();
            this.PageInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UrlBox
            // 
            this.UrlBox.Location = new System.Drawing.Point(71, 25);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(365, 20);
            this.UrlBox.TabIndex = 0;
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(143, 459);
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
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(287, 459);
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
            this.PageInfoBox.Location = new System.Drawing.Point(71, 62);
            this.PageInfoBox.Name = "PageInfoBox";
            this.PageInfoBox.Size = new System.Drawing.Size(365, 374);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 509);
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
    }
}

