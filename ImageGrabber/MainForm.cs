using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageGrabberServices;

namespace ImageGrabber
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            PageInfo info = DataFetcher.FetchPageInfo(UrlBox.Text);
            PageInfoLabel.Text = "";
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(info))
            {
                PageInfoLabel.Text += descriptor.Name + ": " + descriptor.GetValue(info) + "\n";
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderSelector.ShowDialog();
            string folderName;
            if (result == DialogResult.OK)
            {
                folderName = folderSelector.SelectedPath;
                DataFetcher.DownloadImagesFromPageAsync(UrlBox.Text, folderName);
            }
        }
    }
}
