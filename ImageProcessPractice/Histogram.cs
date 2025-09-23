using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessPractice
{
    public partial class Histogram : Form
    {
        public Histogram(Bitmap imageToAnalyze)
        {
            InitializeComponent();
            pictureBox1.Image = analyzeImage(imageToAnalyze);

        }

        private void Histogram_Load(object sender, EventArgs e)
        {

        }

        private Bitmap analyzeImage(Bitmap imageToAnalyze)
        {
            Color pixel;
            int[] frequency = new int[256];
            for (int i = 0; i < 256; ++i) frequency[i] = 0;
            int max = 0;
            for (int i = 0; i < imageToAnalyze.Width; ++i)
            {
                for (int j = 0; j < imageToAnalyze.Height; ++j)
                {
                    pixel = imageToAnalyze.GetPixel(i, j);
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    frequency[average] = ++frequency[average];
                    max = Math.Max(max, frequency[average]);
                }
            }
            Bitmap histogram = new Bitmap(256, max);
            for (int i = 0; i < 256; ++i) {
                for (int j = 0; j < frequency[i]; ++j)
                {
                    histogram.SetPixel(i, max - j - 1, Color.White);
                }
            }

            return histogram;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
