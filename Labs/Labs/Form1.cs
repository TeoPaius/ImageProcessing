using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Labs
{
    
    public partial class Form1 : Form
    {

        Bitmap im1;
        Bitmap im2;
        Bitmap diffImg;

        delegate void Filter(ref Bitmap a, ref Bitmap b, Dictionary<String, String> parameters);


        public Form1()
        {
            InitializeComponent();
            im2 = new Bitmap(moddifiedPb.Size.Width,moddifiedPb.Size.Height);
            diffImg = new Bitmap(moddifiedPb.Size.Width, moddifiedPb.Size.Height);

        }

        private void loadTsb_Click(object sender, EventArgs e)
        {
            swapButton.Visible = true;
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

        private void applyFilter(ref Bitmap original, ref Bitmap newImage, Filter filter, Dictionary<String, String> parameters)
        {
            filter(ref original, ref newImage, parameters);
            Filters.getDiff(ref original, ref newImage, ref diffImg);
            diffPb.Image = diffImg;
            diffLabel.Visible = true;
        }


        private void intensityThresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter del = Filters.processImage_intensityThresholding;
            applyFilter(ref im1, ref im2, Filters.processImage_intensityThresholding, new Dictionary<string, string> { { "threshold", "128" } });
            moddifiedPb.Image = im2;
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            Bitmap temp = im1;
            im1 = im2;
            im2 = temp;

            refferencePb.Image = im1;
            moddifiedPb.Image = im2;
        }

        private void enhanceContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }


        private Dictionary<String, String> loadParams()
        {
            Dictionary<String, String> res = new Dictionary<String, String>();

            string param = System.IO.File.ReadAllText("params.txt");
            foreach(string s in param.Split('\n'))
            {
                res.Add(s.Split(',')[0], s.Split (',')[1]);
            }

            return res;
        }

        private void increaseDecreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> parameters = loadParams();
            applyFilter(ref im1, ref im2, Filters.contrastEnhancement, parameters);
            moddifiedPb.Image = im2;
        }

        private void compactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.contrastCompacting, null);
            moddifiedPb.Image = im2;
        }

        private void equalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.contrastEqualization, null);
            moddifiedPb.Image = im2;
        }

  
        private void spatialBlurToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.SpatialBlur3x3, null);
            moddifiedPb.Image = im2;
        }

        private void contrastReversingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.contrastReversing, null);
            moddifiedPb.Image = im2;
        }

        private void laplacianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.laplace, null);
            moddifiedPb.Image = im2;
        }

        private void conturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.contur, null);
            moddifiedPb.Image = im2;
        }

        private void skeletizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.skeletization, null);
            moddifiedPb.Image = im2;
        }

        private void thinningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.thinning, null);
            moddifiedPb.Image = im2;
        }

        private void thinningToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            applyFilter(ref im1, ref im2, Filters.thinning_morph, null);
            moddifiedPb.Image = im2;
        }
    }
}
