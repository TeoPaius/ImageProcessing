using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Labs
{
    class Filters
    {
        static float R_param = 0.21f;
        static float B_param = 0.07f;
        static float G_param = 0.72f;

        public static void processImage_intensityThresholding(ref Bitmap original, ref Bitmap newImage, Dictionary<String, String> paramters)
        {
            int threshold = Int32.Parse(paramters["threshold"]);
            for (int i = 0; i < original.Size.Height; ++i)
                for (int j = 0; j < original.Size.Width; ++j)
                {
                    Color c = original.GetPixel(j, i);
                    int intensity = (int)((R_param * c.R + G_param * c.G + B_param * c.B) / (R_param + B_param + G_param));

                    if (intensity < threshold)
                        intensity = 0;
                    else
                        intensity = 255;
                    newImage.SetPixel(j, i, Color.FromArgb(intensity, intensity, intensity));
                }
        }


        public static void getDiff(ref Bitmap bm1, ref Bitmap bm2, ref Bitmap diff)
        {
            for (int i = 0; i < diff.Size.Height; ++i)
                for (int j = 0; j < diff.Size.Width; ++j)
                {
                    Color c1 = bm1.GetPixel(j, i);
                    Color c2 = bm2.GetPixel(j, i);
                    Color c = Color.FromArgb(Math.Abs(c1.R - c2.R), Math.Abs(c1.G - c2.G), Math.Abs(c1.B - c2.B));
                    int intensity = (int)((R_param * c.R + G_param * c.G + B_param * c.B) / (R_param + B_param + G_param));
                    diff.SetPixel(j, i, Color.FromArgb(255 - intensity, 255 - intensity, 255 - intensity));
                }
        }

        public static Int32 rgbToGrayscale(Color c)
        {
            return (int)((R_param * c.R + G_param * c.G + B_param * c.B) / (R_param + B_param + G_param));
        }

        public static void contrastEnhancement(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            int a = Int32.Parse(parameters["a"]);
            int va = Int32.Parse(parameters["va"]);
            int b = Int32.Parse(parameters["b"]);
            int vb = Int32.Parse(parameters["vb"]);

            for (int i = 0; i < bm1.Size.Height; ++i)
                for (int j = 0; j < bm1.Size.Width; ++j)
                {
                    float u = Filters.rgbToGrayscale(bm1.GetPixel(j, i));
                    float v;
                    if (u <= a)
                    {
                        v = u * va / a;
                    }
                    else if (u > b)
                    {
                        v = (u - b) / (255 - b) * (255 - vb) + vb;
                    }
                    else
                    {
                        v = (u - a) / (b - a) * (vb - va) + va;
                    }
                    float improv = 1;
                    if (u != 0)
                        improv = v / u;

                    Color c1 = bm1.GetPixel(j, i);
                    Color c2 = Color.FromArgb(Math.Min((int)(c1.R * improv), 255), Math.Min((int)(c1.G * improv), 255), Math.Min((int)(c1.B * improv), 255));
                    bm2.SetPixel(j, i, c2);

                }
        }
        public static void contrastCompacting(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            double cnst = 255 / Math.Log(256);

            for (int i = 0; i < bm1.Size.Height; ++i)
                for (int j = 0; j < bm1.Size.Width; ++j)
                {
                    float u = Filters.rgbToGrayscale(bm1.GetPixel(j, i));
                    float v;
                    v = (float)(cnst * Math.Log(1 + u));
                    float improv = 1;
                    if (u != 0)
                        improv = v / u;

                    Color c1 = bm1.GetPixel(j, i);
                    Color c2 = Color.FromArgb(Math.Min((int)(c1.R * improv), 255), Math.Min((int)(c1.G * improv), 255), Math.Min((int)(c1.B * improv), 255));
                    bm2.SetPixel(j, i, c2);

                }
        }
        public static void contrastEqualization(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            double cnst = 255 / Math.Log(256);
            int nrPix = bm1.Size.Height * bm1.Size.Width;
            int[] histo = new int[256];

            for (int i = 0; i < bm1.Size.Height; ++i)
                for (int j = 0; j < bm1.Size.Width; ++j)
                {
                    int u = Filters.rgbToGrayscale(bm1.GetPixel(j, i));
                    histo[u]++;
                }
            int[] partSums = new int[256];
            float[] probs = new float[256];
            partSums[0] = histo[0];
            probs[0] = partSums[0] / nrPix;
            for (int i = 1; i < 256; ++i)
            {
                partSums[i] = partSums[i - 1] + histo[i];
                probs[i] = (float)partSums[i] / nrPix;
            }

            int[] newHisto = new int[256];
            for (int i = 0; i < 256; ++i)
            {
                newHisto[i] = (int)(probs[i] * 255);
            }

            for (int i = 0; i < bm1.Size.Height; ++i)
                for (int j = 0; j < bm1.Size.Width; ++j)
                {
                    int u = Filters.rgbToGrayscale(bm1.GetPixel(j, i));
                    float improv = 1;
                    if (u != 0)
                        improv = (float)newHisto[u] / u; ;

                    Color c1 = bm1.GetPixel(j, i);
                    Color c2 = Color.FromArgb(Math.Min((int)(c1.R * improv), 255), Math.Min((int)(c1.G * improv), 255), Math.Min((int)(c1.B * improv), 255));
                    bm2.SetPixel(j, i, c2);

                }
        }

        public static void SpatialBlur3x3(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            float[,] weigths = new float[3, 3] { { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f } };
            int kernelSize = 3;

            for (int i = kernelSize / 2; i < bm1.Size.Height - kernelSize / 2; ++i)
                for (int j = kernelSize / 2; j < bm1.Size.Width - kernelSize / 2; ++j)
                {
                    float sumR = 0;
                    float sumG = 0;
                    float sumB = 0;
                    for (int ii = i - kernelSize / 2; ii <= i + kernelSize / 2; ++ii)
                        for (int jj = j - kernelSize / 2; jj <= j + kernelSize / 2; ++jj)
                        {
                            int offI = ii - i + kernelSize / 2;
                            int offJ = jj - j + kernelSize / 2;


                            sumR += bm1.GetPixel(jj, ii).R * weigths[offJ, offI];
                            sumG += bm1.GetPixel(jj, ii).G * weigths[offJ, offI];
                            sumB += bm1.GetPixel(jj, ii).B * weigths[offJ, offI];
                        }

                    bm2.SetPixel(j, i, Color.FromArgb((Int32)sumR, (Int32)sumG, (Int32)sumB));
                }


        }

        public static void contrastReversing(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            float[,] weigths = new float[3, 3] { { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f } };
            int kernelSize = 3;

            for (int i = kernelSize / 2; i < bm1.Size.Height - kernelSize / 2; ++i)
                for (int j = kernelSize / 2; j < bm1.Size.Width - kernelSize / 2; ++j)
                {
                    double sumR = 0;
                    double sumG = 0;
                    double sumB = 0;
                    for (int ii = i - kernelSize / 2; ii <= i + kernelSize / 2; ++ii)
                        for (int jj = j - kernelSize / 2; jj <= j + kernelSize / 2; ++jj)
                        {
                            int offI = ii - i + kernelSize / 2;
                            int offJ = jj - j + kernelSize / 2;


                            sumR += bm1.GetPixel(jj, ii).R * (1 / 9f);
                            sumG += bm1.GetPixel(jj, ii).G * (1 / 9f);
                            sumB += bm1.GetPixel(jj, ii).B * (1 / 9f);
                        }

                    double sigmR = 0;
                    double sigmG = 0;
                    double sigmB = 0;
                    for (int ii = i - kernelSize / 2; ii <= i + kernelSize / 2; ++ii)
                        for (int jj = j - kernelSize / 2; jj <= j + kernelSize / 2; ++jj)
                        {
                            int offI = ii - i + kernelSize / 2;
                            int offJ = jj - j + kernelSize / 2;


                            sigmR += Math.Pow(bm1.GetPixel(jj, ii).R - sumR, 2) * (1 / 9f);
                            sigmG += Math.Pow(bm1.GetPixel(jj, ii).G - sumG, 2) * (1 / 9f);
                            sigmB += Math.Pow(bm1.GetPixel(jj, ii).B - sumB, 2) * (1 / 9f);
                        }
                    sigmR = Math.Sqrt(sigmR);
                    sigmG = Math.Sqrt(sigmG);
                    sigmB = Math.Sqrt(sigmB);
                    if (sigmR == 0)
                        sigmR = 0.001;
                    if (sigmG == 0)
                        sigmG = 0.001;
                    if (sigmB == 0)
                        sigmB = 0.001;



                    bm2.SetPixel(j, i, Color.FromArgb(Math.Min(255, (Int32)(sumR / sigmR)), Math.Min(255, (Int32)(sumG / sigmG)), Math.Min(255, (Int32)(sumB / sigmB))));
                }


        }


        public static void laplace(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            float[,] weigths = new float[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            int kernelSize = 3;

            for (int i = kernelSize / 2; i < bm1.Size.Height - kernelSize / 2; ++i)
                for (int j = kernelSize / 2; j < bm1.Size.Width - kernelSize / 2; ++j)
                {
                    float sumR = 0;
                    float sumG = 0;
                    float sumB = 0;
                    for (int ii = -1; ii <= 1; ++ii)
                        for (int jj = -1; jj <= 1; ++jj)
                        {


                            sumR += bm1.GetPixel(j + jj, i + ii).R * weigths[ii + 1, jj + 1];
                            sumG += bm1.GetPixel(j + jj, i + ii).G * weigths[ii + 1, jj + 1];
                            sumB += bm1.GetPixel(j + jj, i + ii).B * weigths[ii + 1, jj + 1];
                        }
                    if (sumR < 0)
                        sumR = 0;
                    else if (sumR > 255)
                        sumR = 255;
                    if (sumG < 0)
                        sumG = 0;
                    else if (sumG > 255)
                        sumG = 255;
                    if (sumB < 0)
                        sumB = 0;
                    else if (sumB > 255)
                        sumB = 255;
                    bm2.SetPixel(j, i, Color.FromArgb((Int32)sumR, (Int32)sumG, (Int32)sumB));
                }


        }
        public static void contur(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            int[] iOffsets = new int[] { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
            int[] jOffsets = new int[] { -1, 0, 1, -1, 0, 1, -1, 0, 1, };

            for (int i = 0; i < bm1.Size.Height; ++i)
                for (int j = 0; j < bm1.Size.Width ; ++j)
                {
                    int cnt = 0;
                    int col = 0;
                    if (bm1.GetPixel(j, i).R == 255)
                    {
                        bm2.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                        continue;
                    }
                    for (int k = 0; k < 9; ++k)
                    {
                        int newI = i + iOffsets[k];
                        int newJ = j + jOffsets[k];
                        if (newI == i && newJ == j)
                            continue;
                        if (newI < 0 || newJ < 0 || newI >= bm1.Size.Height || newJ >= bm1.Size.Width)
                            continue;
                        if (bm1.GetPixel(newJ, newI).R == 0)
                            continue;
                        cnt++;

                    }
                    if (cnt == 0)
                        col = 255;
                    bm2.SetPixel(j, i, Color.FromArgb(col,col,col));
                }

        }

        public static void skeletization(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            float[,] weigths = new float[3, 3] { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } };
            int[] iOffsets = new int[] { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
            int[] jOffsets = new int[] { -1, 0, 1, -1, 0, 1, -1, 0, 1, };

            int[] iOffsets2 = new int[] { -1, 0, 1, 0 };
            int[] jOffsets2 = new int[] { 0, 1, 0, -1};


            Queue<Tuple<int, int>> edge = new Queue<Tuple<int, int>>();
            int[,] x = new int[bm1.Width, bm1.Height];

            

            for (int i = 0; i < bm1.Size.Height ; ++i)
                for (int j = 0; j < bm1.Size.Width ; ++j)
                {
                    int cnt = 0;
                    if (bm1.GetPixel(j, i).R == 255)
                    {
                        bm2.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                        continue;
                    }
                    for (int k = 0; k < 4; ++k)
                    {
                        int newI = i + iOffsets2[k];
                        int newJ = j + jOffsets2[k];
                        if (newI == i && newJ == j)
                            continue;
                        if (newI < 0 || newJ < 0 || newI >= bm1.Size.Height || newJ >= bm1.Size.Width)
                            continue;
                        if (bm1.GetPixel(newJ, newI).R == 0)
                            continue;
                        cnt++;

                    }
                    if (cnt != 0)
                    {
                        edge.Enqueue(new Tuple<int, int>(i, j));
                        x[j, i] = 1;

                    }
                    
                }


            while (edge.Count != 0)
            {
                Tuple<int, int> point = edge.Dequeue();
                for (int k = 0; k < 4; ++k)
                {
                    int newI = point.Item1 + iOffsets2[k];
                    int newJ = point.Item2 + jOffsets2[k];
                    if (newI < 0 || newJ < 0 || newI >= bm1.Size.Height || newJ >= bm1.Size.Width)
                        continue;
                    if (x[newJ, newI] != 0)
                        continue;
                    if (bm1.GetPixel(newJ, newI).R == 255)
                        continue;
                    x[newJ, newI] = x[point.Item2, point.Item1] + 1;
                    edge.Enqueue(new Tuple<int, int>(newI, newJ));
                }
            }

            for (int i = 0; i < bm1.Size.Height; ++i)
                for (int j = 0; j < bm1.Size.Width; ++j)
                {
                    //bm2.SetPixel(j, i, Color.FromArgb(x[j, i] % 255, x[j, i] % 255, x[j, i] % 255));
                    int localMax = -1;

                    if (bm1.GetPixel(j, i).R == 255)
                    {
                        bm2.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                        continue;
                    }
                    for (int k = 0; k < 4; ++k)
                    {
                        int newI = i + iOffsets2[k];
                        int newJ = j + jOffsets2[k];
                        if (newI < 0 || newJ < 0 || newI >= bm1.Size.Height || newJ >= bm1.Size.Width)
                            continue;

                        localMax = Math.Max(localMax, x[newJ, newI]);

                    }
                    if (localMax <= x[j, i] && localMax != -1)
                    {
                        bm2.SetPixel(j, i, Color.FromArgb(100, 25, 230));
                    }
                    else
                    {
                        bm2.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                    }
                }
        }

        public static void thinning(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            int[] iOffsets = new int[] { -1, -1, -1, 0, 1, 1,  1,  0};
            int[] jOffsets = new int[] { -1,  0,  1, 1, 1, 0, -1, -1};


            for(int m = 1; m < 2; ++m)
            { 
                for (int i = 0; i < bm1.Size.Height; ++i)
                    for (int j = 0; j < bm1.Size.Width; ++j)
                    {
                        int cnt = 0;
                        int col = 0;
                        int t = 0;
                        if (bm1.GetPixel(j, i).R == 255)
                        {
                            bm2.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                            continue;
                        }
                        for (int k = 0; k < 8; ++k)
                        {
                            int newI = i + iOffsets[k];
                            int newJ = j + jOffsets[k];
                            if (newI == i && newJ == j)
                                continue;
                            if (newI < 0 || newJ < 0 || newI >= bm1.Size.Height || newJ >= bm1.Size.Width)
                                continue;
                            if (bm1.GetPixel(newJ, newI).R == 0)
                                cnt++;

                            int nextI = i + iOffsets[(k+1)%8];
                            int nextJ = j + jOffsets[(k+1)%8];

                            if (nextI < 0 || nextJ < 0 || nextI >= bm1.Size.Height || nextJ >= bm1.Size.Width)
                                continue;
                            if (bm1.GetPixel(newJ, newI).R == 0 && bm1.GetPixel(nextJ, nextI).R == 255)
                                t++;

                        

                        }
                        if (cnt == 1 || cnt > 6 || t != 1)
                            col = 0;
                        else
                            col = 255;
                        bm2.SetPixel(j, i, Color.FromArgb(col, col, col));
                    }
                //bm1 = bm2;
            }
        }


        public static void thinning_morph(ref Bitmap bm1, ref Bitmap bm2, Dictionary<String, String> parameters)
        {
            int[] iOffsets = new int[] { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] jOffsets = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };

            int[] kernel = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };

            for (int m = 1; m < 2; ++m)
            {
                for (int i = 0; i < bm1.Size.Height; ++i)
                    for (int j = 0; j < bm1.Size.Width; ++j)
                    {
                        if(bm1.GetPixel(j, i).R == 255)
                                continue;
                        int unmatches = 0;
                        for (int k = 0; k < 8; ++k)
                        {
                            int newI = i + iOffsets[k];
                            int newJ = j + jOffsets[k];
                            if (newI == i && newJ == j)
                                continue;
                            if (newI < 0 || newJ < 0 || newI >= bm1.Size.Height || newJ >= bm1.Size.Width)
                                continue;
                            

                            if (kernel[k] == -1)
                                continue;
                            if (kernel[k] == 0 && bm1.GetPixel(newJ, newI).R == 0)
                                unmatches++;
                            if (kernel[k] == 1 && bm1.GetPixel(newJ, newI).R == 255)
                                unmatches++;

                        }
                        

                        if(unmatches == 0)
                            bm2.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                        else
                            bm2.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                    }
                //bm1 = bm2;
            }
        }


    }
}
