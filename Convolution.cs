using System;

namespace ImageProcessPractice
{
    public class Convolution3x3
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0
        public int MidLeft = 0, Pixel = 1, MidRight = 0
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;

        public int Factor = 1;
        public int Offset = 0;

        // Configuration is an array of 9 integers representing the convolution matrix.
        // I created this so I can create another class with static values of predefined configurations.
        public Convolution3x3(int[] configuration, int factor, int offset)
        {
            this.TopLeft = configuration[0];
            this.TopMid = configuration[1];
            this.TopRight = configuration[2];
            this.MidLeft = configuration[3];
            this.Pixel = configuration[4];
            this.MidRight = configuration[5];
            this.BottomLeft = configuration[6];
            this.BottomMid = configuration[7];
            this.BottomRight = configuration[8];
            this.Factor = factor;
            this.Offset = offset;
        }

        public void SetAll(int nVal)
        {

            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight
             BottomLeft = BottomMid = BottomRight = nVal;
        }

        public static bool apply(Bitmap b, Convolution3x3 m)

        {

            // Avoid divide by zero errors 



            if (0 == m.Factor)

                return false; Bitmap



            // GDI+ still lies to us - the return format is BGR, NOT RGB.  



            bSrc = (Bitmap)b.Clone();

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),

                                ImageLockMode.ReadWrite,

                                PixelFormat.Format24bppRgb);

            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),

                               ImageLockMode.ReadWrite,

                               PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;

            int stride2 = stride * 2;



            System.IntPtr Scan0 = bmData.Scan0;

            System.IntPtr SrcScan0 = bmSrc.Scan0;



            unsafe
            {

                byte* p = (byte*)(void*)Scan0;

                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;

                int nWidth = b.Width - 2;

                int nHeight = b.Height - 2;



                int nPixel;



                for (int y = 0; y < nHeight; ++y)

                {

                    for (int x = 0; x < nWidth; ++x)

                    {

                        nPixel = ((((pSrc[2] * m.TopLeft) +

                            (pSrc[5] * m.TopMid) +

                            (pSrc[8] * m.TopRight) +

                            (pSrc[2 + stride] * m.MidLeft) +

                            (pSrc[5 + stride] * m.Pixel) +

                            (pSrc[8 + stride] * m.MidRight) +

                            (pSrc[2 + stride2] * m.BottomLeft) +

                            (pSrc[5 + stride2] * m.BottomMid) +

                            (pSrc[8 + stride2] * m.BottomRight))

                            / m.Factor) + m.Offset);



                        if (nPixel < 0) nPixel = 0;

                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;



                        nPixel = ((((pSrc[1] * m.TopLeft) +

                            (pSrc[4] * m.TopMid) +

                            (pSrc[7] * m.TopRight) +

                            (pSrc[1 + stride] * m.MidLeft) +

                            (pSrc[4 + stride] * m.Pixel) +

                            (pSrc[7 + stride] * m.MidRight) +

                            (pSrc[1 + stride2] * m.BottomLeft) +

                            (pSrc[4 + stride2] * m.BottomMid) +

                            (pSrc[7 + stride2] * m.BottomRight))

                            / m.Factor) + m.Offset);



                        if (nPixel < 0) nPixel = 0;

                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;



                        nPixel = ((((pSrc[0] * m.TopLeft) +

                                       (pSrc[3] * m.TopMid) +

                                       (pSrc[6] * m.TopRight) +

                                       (pSrc[0 + stride] * m.MidLeft) +

                                       (pSrc[3 + stride] * m.Pixel) +

                                       (pSrc[6 + stride] * m.MidRight) +

                                       (pSrc[0 + stride2] * m.BottomLeft) +

                                       (pSrc[3 + stride2] * m.BottomMid) +

                                       (pSrc[6 + stride2] * m.BottomRight))

                            / m.Factor) + m.Offset);



                        if (nPixel < 0) nPixel = 0;

                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;



                        p += 3;

                        pSrc += 3;

                    }



                    p += nOffset;

                    pSrc += nOffset;

                }

            }



            b.UnlockBits(bmData);

            bSrc.UnlockBits(bmSrc);

            return true;

        }
    }
}
