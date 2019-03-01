using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs
{
    public partial class Form1 : Form
    {

        Bitmap im1;
        Bitmap im2;
        float R_param = 0.21f;
        float B_param = 0.07f;
        float G_param = 0.72f;
        int threshold = 200;


        public Form1()
        {
            InitializeComponent();
            im2 = new Bitmap(moddifiedPb.Size.Width,moddifiedPb.Size.Height);
        }

        private void loadTsb_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    im1 = new Bitmap(dlg.FileName);
                    refferencePb.Image = new Bitmap(im1, refferencePb.Size);
                    im1 = (Bitmap)refferencePb.Image;
                }
            }

            moddifiedPb.Image = im1;
        }



        private void processImage_intensityThresholding(ref Bitmap original, ref Bitmap newImage)
        {
            for(int i = 0; i < original.Size.Height; ++i)
                for(int j = 0; j < original.Size.Width; ++j)
                {
                    Color c = original.GetPixel(j, i);
                    int intensity = (int)(( R_param * c.R + G_param * c.G + B_param * c.B) / (R_param + B_param + G_param));

                    if (intensity < threshold)
                        intensity = 0;
                    else
                        intensity = 255;
                    newImage.SetPixel(j, i, Color.FromArgb(intensity, intensity, intensity));  
                }
        }

        private void saveTsb_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the  
                // File type selected in the dialog box.  
                // NOTE that the FilterIndex property is one-based.  
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        im2.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        im2.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        im2.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        private void intensityThresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processImage_intensityThresholding(ref im1, ref im2);
            moddifiedPb.Image = im2;
        }
    }
}
