namespace Labs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


 
     
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.refferencePb = new System.Windows.Forms.PictureBox();
            this.moddifiedPb = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loadTsb = new System.Windows.Forms.ToolStripButton();
            this.saveTsb = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.intensityThresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enhanceContrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseDecreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spatialFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spatialBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastReversingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapButton = new System.Windows.Forms.Button();
            this.diffPb = new System.Windows.Forms.PictureBox();
            this.diffLabel = new System.Windows.Forms.Label();
            this.imageTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skeletizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.refferencePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moddifiedPb)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diffPb)).BeginInit();
            this.SuspendLayout();
            // 
            // refferencePb
            // 
            this.refferencePb.Location = new System.Drawing.Point(27, 96);
            this.refferencePb.Name = "refferencePb";
            this.refferencePb.Size = new System.Drawing.Size(332, 342);
            this.refferencePb.TabIndex = 0;
            this.refferencePb.TabStop = false;
            // 
            // moddifiedPb
            // 
            this.moddifiedPb.Location = new System.Drawing.Point(452, 96);
            this.moddifiedPb.Name = "moddifiedPb";
            this.moddifiedPb.Size = new System.Drawing.Size(332, 342);
            this.moddifiedPb.TabIndex = 1;
            this.moddifiedPb.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTsb,
            this.saveTsb,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1250, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // loadTsb
            // 
            this.loadTsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadTsb.Image = ((System.Drawing.Image)(resources.GetObject("loadTsb.Image")));
            this.loadTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadTsb.Name = "loadTsb";
            this.loadTsb.Size = new System.Drawing.Size(37, 22);
            this.loadTsb.Text = "Load";
            this.loadTsb.Click += new System.EventHandler(this.loadTsb_Click);
            // 
            // saveTsb
            // 
            this.saveTsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveTsb.Image = ((System.Drawing.Image)(resources.GetObject("saveTsb.Image")));
            this.saveTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTsb.Name = "saveTsb";
            this.saveTsb.Size = new System.Drawing.Size(35, 22);
            this.saveTsb.Text = "Save";
            this.saveTsb.Click += new System.EventHandler(this.saveTsb_Click_1);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intensityThresholdingToolStripMenuItem,
            this.enhanceContrastToolStripMenuItem,
            this.spatialFiltersToolStripMenuItem,
            this.imageTransformToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripDropDownButton1.Text = "Filters";
            // 
            // intensityThresholdingToolStripMenuItem
            // 
            this.intensityThresholdingToolStripMenuItem.Name = "intensityThresholdingToolStripMenuItem";
            this.intensityThresholdingToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.intensityThresholdingToolStripMenuItem.Text = "Intensity Thresholding";
            this.intensityThresholdingToolStripMenuItem.Click += new System.EventHandler(this.intensityThresholdingToolStripMenuItem_Click);
            // 
            // enhanceContrastToolStripMenuItem
            // 
            this.enhanceContrastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseDecreaseToolStripMenuItem,
            this.compactToolStripMenuItem,
            this.equalizationToolStripMenuItem});
            this.enhanceContrastToolStripMenuItem.Name = "enhanceContrastToolStripMenuItem";
            this.enhanceContrastToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.enhanceContrastToolStripMenuItem.Text = "Contrast Enhancing";
            this.enhanceContrastToolStripMenuItem.Click += new System.EventHandler(this.enhanceContrastToolStripMenuItem_Click);
            // 
            // increaseDecreaseToolStripMenuItem
            // 
            this.increaseDecreaseToolStripMenuItem.Name = "increaseDecreaseToolStripMenuItem";
            this.increaseDecreaseToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.increaseDecreaseToolStripMenuItem.Text = "Increase/Decrease";
            this.increaseDecreaseToolStripMenuItem.Click += new System.EventHandler(this.increaseDecreaseToolStripMenuItem_Click);
            // 
            // compactToolStripMenuItem
            // 
            this.compactToolStripMenuItem.Name = "compactToolStripMenuItem";
            this.compactToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.compactToolStripMenuItem.Text = "Compact";
            this.compactToolStripMenuItem.Click += new System.EventHandler(this.compactToolStripMenuItem_Click);
            // 
            // equalizationToolStripMenuItem
            // 
            this.equalizationToolStripMenuItem.Name = "equalizationToolStripMenuItem";
            this.equalizationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.equalizationToolStripMenuItem.Text = "Equalization";
            this.equalizationToolStripMenuItem.Click += new System.EventHandler(this.equalizationToolStripMenuItem_Click);
            // 
            // spatialFiltersToolStripMenuItem
            // 
            this.spatialFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spatialBlurToolStripMenuItem,
            this.contrastReversingToolStripMenuItem,
            this.laplacianFilterToolStripMenuItem});
            this.spatialFiltersToolStripMenuItem.Name = "spatialFiltersToolStripMenuItem";
            this.spatialFiltersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.spatialFiltersToolStripMenuItem.Text = "Spatial filters";
            // 
            // spatialBlurToolStripMenuItem
            // 
            this.spatialBlurToolStripMenuItem.Name = "spatialBlurToolStripMenuItem";
            this.spatialBlurToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.spatialBlurToolStripMenuItem.Text = "Spatial blur";
            this.spatialBlurToolStripMenuItem.Click += new System.EventHandler(this.spatialBlurToolStripMenuItem_Click_1);
            // 
            // contrastReversingToolStripMenuItem
            // 
            this.contrastReversingToolStripMenuItem.Name = "contrastReversingToolStripMenuItem";
            this.contrastReversingToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.contrastReversingToolStripMenuItem.Text = "Contrast reversing";
            this.contrastReversingToolStripMenuItem.Click += new System.EventHandler(this.contrastReversingToolStripMenuItem_Click);
            // 
            // laplacianFilterToolStripMenuItem
            // 
            this.laplacianFilterToolStripMenuItem.Name = "laplacianFilterToolStripMenuItem";
            this.laplacianFilterToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.laplacianFilterToolStripMenuItem.Text = "Laplacian filter";
            this.laplacianFilterToolStripMenuItem.Click += new System.EventHandler(this.laplacianFilterToolStripMenuItem_Click);
            // 
            // swapButton
            // 
            this.swapButton.Location = new System.Drawing.Point(365, 251);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(81, 23);
            this.swapButton.TabIndex = 3;
            this.swapButton.Text = "<Swap>";
            this.swapButton.UseVisualStyleBackColor = true;
            this.swapButton.Visible = false;
            this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // diffPb
            // 
            this.diffPb.Location = new System.Drawing.Point(850, 96);
            this.diffPb.Name = "diffPb";
            this.diffPb.Size = new System.Drawing.Size(332, 342);
            this.diffPb.TabIndex = 4;
            this.diffPb.TabStop = false;
            // 
            // diffLabel
            // 
            this.diffLabel.AutoSize = true;
            this.diffLabel.Location = new System.Drawing.Point(978, 57);
            this.diffLabel.Name = "diffLabel";
            this.diffLabel.Size = new System.Drawing.Size(56, 13);
            this.diffLabel.TabIndex = 5;
            this.diffLabel.Text = "Difference";
            this.diffLabel.Visible = false;
            // 
            // imageTransformToolStripMenuItem
            // 
            this.imageTransformToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conturToolStripMenuItem,
            this.skeletizationToolStripMenuItem});
            this.imageTransformToolStripMenuItem.Name = "imageTransformToolStripMenuItem";
            this.imageTransformToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.imageTransformToolStripMenuItem.Text = "Image transform";
            // 
            // conturToolStripMenuItem
            // 
            this.conturToolStripMenuItem.Name = "conturToolStripMenuItem";
            this.conturToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.conturToolStripMenuItem.Text = "Contur";
            this.conturToolStripMenuItem.Click += new System.EventHandler(this.conturToolStripMenuItem_Click);
            // 
            // skeletizationToolStripMenuItem
            // 
            this.skeletizationToolStripMenuItem.Name = "skeletizationToolStripMenuItem";
            this.skeletizationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skeletizationToolStripMenuItem.Text = "Skeletization";
            this.skeletizationToolStripMenuItem.Click += new System.EventHandler(this.skeletizationToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 565);
            this.Controls.Add(this.diffLabel);
            this.Controls.Add(this.diffPb);
            this.Controls.Add(this.swapButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.moddifiedPb);
            this.Controls.Add(this.refferencePb);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.refferencePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moddifiedPb)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diffPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox refferencePb;
        private System.Windows.Forms.PictureBox moddifiedPb;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadTsb;
        private System.Windows.Forms.ToolStripButton saveTsb;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem intensityThresholdingToolStripMenuItem;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.PictureBox diffPb;
        private System.Windows.Forms.Label diffLabel;
        private System.Windows.Forms.ToolStripMenuItem enhanceContrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseDecreaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spatialFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spatialBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastReversingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageTransformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skeletizationToolStripMenuItem;
    }
}

