using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessPractice
{
    public partial class RemoveBackgroundForm : Form
    {
        ImageEditor origin;
        Bitmap origToProcess;
        Bitmap origBackground;
        Color colorToRemove;
        int greyColorToRemove;
        int orig_width, orig_height;
        public RemoveBackgroundForm(ImageEditor origin, Bitmap toProcess)
        {
            InitializeComponent();
            origToProcess = toProcess;
            orig_width = origToProcess.Width;
            orig_height = origToProcess.Height;

            this.origin = origin;

            // Place holder background, if the user just wants to remove background without replacement
            origBackground = new Bitmap(orig_width, orig_height);


            colorToRemove = Color.FromArgb(0, 255, 0);
            greyColorToRemove = (colorToRemove.R + colorToRemove.G + colorToRemove.B) / 3;

            pictureBox1.Image = origToProcess;
            pictureBox2.Image = RemoveBackground();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = RemoveBackground();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            origBackground = new Bitmap(new Bitmap(openFileDialog1.FileName), orig_width, orig_height);
            pictureBox2.Image = RemoveBackground();
        }

        private Bitmap RemoveBackground()
        {
            Bitmap result = new Bitmap(orig_width, orig_height);

            BitmapData resultData = result.LockBits(
                new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            BitmapData origToProcessData = origToProcess.LockBits(
                new Rectangle(0, 0, origToProcess.Width, origToProcess.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData origBackgroundData = origBackground.LockBits(
                new Rectangle(0, 0, origBackground.Width, origBackground.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int strideWrite = resultData.Stride;
            int strideRead = origToProcessData.Stride;

            unsafe
            {
                byte* ptrWrite = (byte*)resultData.Scan0;
                byte* ptrReadProcess = (byte*)origToProcessData.Scan0;
                byte* ptrReadBackground = (byte*)origBackgroundData.Scan0;


                int threshold = trackBar1.Value;

                for (int y = 0; y < orig_height; y++)
                {
                    byte* rowWrite = ptrWrite + (y * strideWrite);
                    byte* rowReadProcess = ptrReadProcess + (y * strideRead);
                    byte* rowReadBackground = ptrReadBackground + (y * strideRead);

                    for (int x = 0; x < orig_width; x++)
                    {
                        int offset = x * 3;
                        byte b = rowReadProcess[offset];
                        byte g = rowReadProcess[offset + 1];
                        byte r = rowReadProcess[offset + 2];

                        // Using chroma key
                        //int grey = (b + g + r) / 3;
                        //int subtractValue = Math.Abs(grey - greyColorToRemove);

                        // Using Euclidean Distance
                        double subtractValue = Math.Sqrt(
                            Math.Pow(r - colorToRemove.R, 2) +
                            Math.Pow(g - colorToRemove.G, 2) +
                            Math.Pow(b - colorToRemove.B, 2));

                        if (subtractValue > threshold)
                        {
                            rowWrite[offset] = b;
                            rowWrite[offset + 1] = g;
                            rowWrite[offset + 2] = r;
                        }
                        else
                        {
                            rowWrite[offset] = rowReadBackground[offset];
                            rowWrite[offset + 1] = rowReadBackground[offset + 1];
                            rowWrite[offset + 2] = rowReadBackground[offset + 2];
                        }
                    }
                }
            }

            result.UnlockBits(resultData);
            origToProcess.UnlockBits(origToProcessData);
            origBackground.UnlockBits(origBackgroundData);

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            origin.TargetPictureBox.Image = pictureBox2.Image;
            this.Close();
        }
    }
}
