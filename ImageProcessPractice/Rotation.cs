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
    public partial class Rotation : Form
    {

        private Bitmap orig;
        public Rotation(Bitmap b)
        {
            this.orig = b;
            pictureBox1.Image = (Bitmap) b.Clone();
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Image = Rotate(trackBar1.Value);
        }

        private Bitmap Rotate(int degrees)
        {
            Bitmap rotated = new Bitmap(orig.Width, orig.Height);

            int x0 = orig.Width / 2;
            int y0 = orig.Height / 2;

            for (int y1 = 0; y1 < orig.Height; y1++)
            {
                for (int x1 = 0; x1 < orig.Width; x1++)
                {
                    int x2 = (int) (Math.Cos(degrees) * (x1 - x0) - Math.Sin(degrees) * (y1 - y0) + x0);
                    int y2 = (int)(Math.Sin(degrees) * (x1 - x0) + Math.Cos(degrees) * (y1 - y0) + y0);
                    rotated.SetPixel(x2, y2, orig.GetPixel(x1, y1));
                }
            }

            return rotated;
        }
    }
}
