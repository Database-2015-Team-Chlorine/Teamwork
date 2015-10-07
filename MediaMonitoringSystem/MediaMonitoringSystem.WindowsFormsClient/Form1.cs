namespace MediaMonitoringSystem.WindowsFormsClient
{
    using System;
    using System.IO.Compression;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string zipPath = FD.FileName;
                string extractPath = "../../../ImportedFiles";

                ZipFile.ExtractToDirectory(zipPath, extractPath);

                //FileInfo File = new FileInfo(FD.FileName);
                ////OR
                //StreamReader reader = new StreamReader(fileToOpen);
                ////etc...
            }
        }
    }
}
