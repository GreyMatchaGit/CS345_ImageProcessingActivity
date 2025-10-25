using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessPractice
{
    public class Convolution3x3
    {
        public int TopLeft, TopMid, TopRight;
        public int MidLeft, Pixel, MidRight;
        public int BottomLeft, BottomMid, BottomRight;
        public int Factor;
        public int Offset;

        public Convolution3x3(int[] configuration, int factor, int offset)
        {
            TopLeft = configuration[0];
            TopMid = configuration[1];
            TopRight = configuration[2];
            MidLeft = configuration[3];
            Pixel = configuration[4];
            MidRight = configuration[5];
            BottomLeft = configuration[6];
            BottomMid = configuration[7];
            BottomRight = configuration[8];
            Factor = factor;
            Offset = offset;
        }

        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight =
            MidLeft = Pixel = MidRight =
            BottomLeft = BottomMid = BottomRight = nVal;
        }

        public static bool Apply(Bitmap b, Convolution3x3 m)
        {
            if (m.Factor == 0)
                return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            BitmapData bmData = b.LockBits(
                new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            BitmapData bmSrc = bSrc.LockBits(
                new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int width = b.Width;
            int height = b.Height;

            unsafe
            {
                byte* p = (byte*)bmData.Scan0;
                byte* pSrc = (byte*)bmSrc.Scan0;

                int offset = stride - width * 3;

                // Loop through each pixel (excluding borders)
                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        int pos = (y * stride) + (x * 3);

                        int blue = 0, green = 0, red = 0;

                        // Apply 3x3 kernel
                        for (int ky = -1; ky <= 1; ky++)
                        {
                            for (int kx = -1; kx <= 1; kx++)
                            {
                                int kVal = 0;
                                switch ((ky + 1) * 3 + (kx + 1))
                                {
                                    case 0: kVal = m.TopLeft; break;
                                    case 1: kVal = m.TopMid; break;
                                    case 2: kVal = m.TopRight; break;
                                    case 3: kVal = m.MidLeft; break;
                                    case 4: kVal = m.Pixel; break;
                                    case 5: kVal = m.MidRight; break;
                                    case 6: kVal = m.BottomLeft; break;
                                    case 7: kVal = m.BottomMid; break;
                                    case 8: kVal = m.BottomRight; break;
                                }

                                int srcPos = ((y + ky) * stride) + ((x + kx) * 3);
                                blue += pSrc[srcPos + 0] * kVal;
                                green += pSrc[srcPos + 1] * kVal;
                                red += pSrc[srcPos + 2] * kVal;
                            }
                        }

                        blue = (blue / m.Factor) + m.Offset;
                        green = (green / m.Factor) + m.Offset;
                        red = (red / m.Factor) + m.Offset;

                        blue = Math.Min(Math.Max(blue, 0), 255);
                        green = Math.Min(Math.Max(green, 0), 255);
                        red = Math.Min(Math.Max(red, 0), 255);

                        p[pos + 0] = (byte)blue;
                        p[pos + 1] = (byte)green;
                        p[pos + 2] = (byte)red;
                    }
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            bSrc.Dispose();

            return true;
        }
    }
}
