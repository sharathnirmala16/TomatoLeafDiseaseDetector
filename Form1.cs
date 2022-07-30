using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net.Sockets;
using System.IO;

namespace TLDDetector
{
    public partial class Form1 : Form
    {
        string filePath;

        public Form1()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = file.FileName;
                Image image = Image.FromFile(filePath);
                pictureBox1.Image = image;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Performing Analysis...\nResults:\n";
            string cwd = Directory.GetCurrentDirectory().Replace('\\', '/');
            string readFilePath = cwd + "/commPW.txt";
            string writeFilePath = cwd + "/commPR.txt";
            File.WriteAllText(writeFilePath, String.Empty);
            File.WriteAllText(writeFilePath, filePath);
            System.Diagnostics.Process.Start(cwd + "/Tomato Leaf Disease Detector.py");
            System.Threading.Thread.Sleep(15000);
            richTextBox1.Text += File.ReadAllText(readFilePath);
        }
    }
}
