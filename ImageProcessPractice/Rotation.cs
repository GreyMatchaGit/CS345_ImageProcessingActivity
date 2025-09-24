using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessPractice
{
    public partial class Rotation : Form
    {

        private Bitmap orig;
        int orig_width, orig_height;
        public Rotation(Bitmap b)
        {
            InitializeComponent();
            this.orig = b;
            orig_width = orig.Width;
            orig_height = orig.Height;
            pictureBox1.Image = (Bitmap)b.Clone();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Image = Rotate(trackBar1.Value);
        }

        private Bitmap Rotate(double degrees)
        {
            degrees = degrees * (Math.PI / 180);
            Bitmap rotated = new Bitmap(orig.Width, orig.Height);

            int x0 = orig.Width / 2;
            int y0 = orig.Height / 2;


            for (int y1 = 0; y1 < orig.Height; y1++)
            {
                for (int x1 = 0; x1 < orig.Width; x1++)
                {
                    int x2 = (int)(Math.Cos(degrees) * (x1 - x0) - Math.Sin(degrees) * (y1 - y0) + x0);
                    int y2 = (int)(Math.Sin(degrees) * (x1 - x0) + Math.Cos(degrees) * (y1 - y0) + y0);
                    if (x2 >= 0 && x2 < orig.Width && y2 >= 0 && y2 < orig.Height)
                        rotated.SetPixel(x2, y2, orig.GetPixel(x1, y1));
                }
            }
           
            return rotated;
        }

        private Bitmap RotateEnhanced(double degrees)
        {
            degrees = degrees * (Math.PI / 180);
            Bitmap result = new Bitmap(pictureBox1.Image);

            BitmapData resultBMPD = result.LockBits(
                new Rectangle(0, 0, orig_width, orig_height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb
            );

            BitmapData origBMPD = orig.LockBits(
                new Rectangle(0, 0, orig_width, orig_height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb
             );

            unsafe
            {
                byte* ptrWrite = (byte*)resultBMPD.Scan0;
                byte* ptrRead = (byte*)origBMPD.Scan0;

                int x0 = orig_width / 2, y0 = orig_height / 2;

                for (int y1 = 0; y1 < orig_height; ++y1)
                {
                    for (int x1 = 0; x1 < orig_width; ++x1)
                    {
                        int x2 = (int)(Math.Cos(degrees) * (x1 - x0) - Math.Sin(degrees) * (y1 - y0) + x0);
                        int y2 = (int)(Math.Sin(degrees) * (x1 - x0) + Math.Cos(degrees) * (y1 - y0) + y0);
                        if (x2 >= 0 && x2 < orig_width && y2 >= 0 && y2 < orig_height)
                        {
                            ptrWrite[0] = ptrRead[x2 * 3 + y2 * origBMPD.Stride];
                            ptrWrite[1] = ptrRead[x2 * 3 + y2 * origBMPD.Stride + 1];
                            ptrWrite[2] = ptrRead[x2 * 3 + y2 * origBMPD.Stride + 2];
                            // ptrRead[x][y] = ptrRead[x + y * width]
                            ptrWrite += 3;
                        }
                    }
                }
            }

            orig.UnlockBits(origBMPD);
            result.UnlockBits(resultBMPD);

            return result;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
