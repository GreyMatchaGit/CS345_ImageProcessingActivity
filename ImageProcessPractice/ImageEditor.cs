using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ImageProcessPractice
{
    public partial class ImageEditor : Form
    {
        Stack<List<Bitmap>> history = new Stack<List<Bitmap>>();
        private PictureBox targetPictureBox;

        public PictureBox TargetPictureBox { get => targetPictureBox; set => targetPictureBox = value; }
        public ImageEditor()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(800, 600);
            pictureBox2.Image = new Bitmap(800, 600);
            targetPictureBox = pictureBox1;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            history.Push(new List<Bitmap> { new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image) });
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            Bitmap toProcess = new Bitmap(targetPictureBox.Image);
            history.Push(new List<Bitmap> { new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image) });
            for (int i = 0; i < toProcess.Width; i++)
            {
                for (int j = 0; j < toProcess.Height; j++)
                {
                    pixel = toProcess.GetPixel(i, j);
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    pixel = Color.FromArgb(average, average, average);
                    toProcess.SetPixel(i, j, pixel);
                }
            }
            targetPictureBox.Image = toProcess;
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.Push(new List<Bitmap> { new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image) });
            PictureBox nonTargetPictureBox = targetPictureBox == pictureBox1 ? pictureBox2 : pictureBox1;
            nonTargetPictureBox.Image = new Bitmap(targetPictureBox.Image);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (history.Count == 0) return;
            List<Bitmap> previousState = history.Pop();
            pictureBox1.Image = previousState[0];
            pictureBox2.Image = previousState[1];
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            Bitmap toProcess = new Bitmap(targetPictureBox.Image);
            history.Push(new List<Bitmap> { new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image) });
            for (int i = 0; i < toProcess.Width; i++)
            {
                for (int j = 0; j < toProcess.Height; j++)
                {
                    pixel = toProcess.GetPixel(i, j);
                    pixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, pixel.B);
                    toProcess.SetPixel(i, j, pixel);
                }
            }
            targetPictureBox.Image = toProcess;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            Bitmap toProcess = new Bitmap(targetPictureBox.Image);
            history.Push(new List<Bitmap> { new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image) });
            for (int i = 0; i < toProcess.Width; i++)
            {
                for (int j = 0; j < toProcess.Height; j++)
                {
                    pixel = toProcess.GetPixel(i, j);
                    int tr = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    int tg = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    int tb = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);
                    if (tr > 255) tr = 255;
                    if (tg > 255) tg = 255;
                    if (tb > 255) tb = 255;
                    pixel = Color.FromArgb(tr, tg, tb);
                    toProcess.SetPixel(i, j, pixel);
                }
            }
            targetPictureBox.Image = toProcess;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            targetPictureBox = pictureBox1;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            targetPictureBox = pictureBox2;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void showHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var histogramForm = new Histogram(new Bitmap(targetPictureBox.Image));
            histogramForm.Show();
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotation rotation = new Rotation(new Bitmap(targetPictureBox.Image));
            rotation.ShowDialog();
        }

        private void removeBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveBackgroundForm removeBackground = new RemoveBackgroundForm(this, new Bitmap(targetPictureBox.Image));
            removeBackground.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
