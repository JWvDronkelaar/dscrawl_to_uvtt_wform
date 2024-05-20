using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using static DStoUVTT;

namespace dscrawl_to_uvtt_wform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dsFileNameTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void dsFileNameTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string dsFilePath = "";

            if (files.Length > 0)
                dsFilePath = files[0];
                dsFileNameTextBox.Text = dsFilePath;

                SetImageFileFromDSfilePath(dsFilePath);
        }

        private void imageFileNameTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void SetImageFileFromDSfilePath(string dsFilePath)
        {
            string fileNameToMatch = Path.GetFileNameWithoutExtension(dsFilePath);
            string dsFolder = Path.GetDirectoryName(dsFilePath);

            string pattern = Regex.Escape(fileNameToMatch) + @"_\d+x{1}\d+.png$";

            //string pattern = @"_\d+x{1}\d+.png$";

            foreach (string file in Directory.EnumerateFiles(dsFolder))
            {
                string filename = Path.GetFileName(file);

                if (Regex.IsMatch(filename, pattern))
                {
                    imageFileNameTextBox.Text = file;
                    AssignMapResolutionFromImageName(filename);
                }
            }
        }

        private List<int> AssignMapResolutionFromImageName(string imageFileName)
        {
            string pattern = @"(?:_)(\d+)(?:x{1})(\d+)(?=.png$)";
            Match match = Regex.Match(imageFileName, pattern);
            List<int> mapResolution = new List<int>();
            
            if (match.Success)
            {
                mapWidthNumericUpDown.Value = (int.Parse(match.Groups[1].Value));
                mapHeightNumericUpDown.Value = (int.Parse(match.Groups[2].Value));
            }

            return mapResolution;
        }

        private void imageFileNameTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string imageFilePath = "";
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
                imageFilePath = (string)files[0];
                imageFileNameTextBox.Text = files[0];

                List<int> mapResolution = AssignMapResolutionFromImageName(Path.GetFileName(imageFilePath));
        }

        private void openImageFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.InitialDirectory = "c:\\";
            openFileDialog2.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog2.FileName;
                imageFileNameTextBox.Text = filePath;
                // Do something with the selected file path
            }
            else
            {
                imageFileNameTextBox.Text = "No file selected.";
            }
        }

        private void openDSfileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "ds files (*.ds)|*.ds|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                dsFileNameTextBox.Text = filePath;
            }
            else
            {
                dsFileNameTextBox.Text = "No file selected.";
            }
        }

        private bool validateMapFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            using (StreamReader file = new StreamReader(filePath))
            {
                string content = file.ReadToEnd();

                string pattern = @"(?:map)({.*})";
                Match match = Regex.Match(content, pattern);
                return match.Groups[1].Value != "";
            }
        }

        private void execButton_Click(object sender, EventArgs e)
        {
            if (!validateMapFile(dsFileNameTextBox.Text))
            {
                MessageBox.Show("No valid map file supplied!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dscrawlFileName = dsFileNameTextBox.Text;
            int mapWidth = (int) mapWidthNumericUpDown.Value;
            int mapHeight = (int) mapHeightNumericUpDown.Value;
            int tileSize = (int) numericUpDown2.Value;

            string imageFileName = imageFileNameTextBox.Text;
            if (imageFileName != "")
            {
                if (!File.Exists(imageFileName))
                {
                    MessageBox.Show("Image path invalid, supply a valid path or none at all!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DscrawlToUvtt(dscrawlFileName, mapWidth, mapHeight, tileSize, imageFileName);

            MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClearDsFileName_Click(object sender, EventArgs e)
        {
            dsFileNameTextBox.Text = "";
        }

        private void btnClearImgFileName_Click(object sender, EventArgs e)
        {
            imageFileNameTextBox.Text = "";
        }
    }
}
