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
            ((System.ComponentModel.ISupportInitialize)(this.refferencePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moddifiedPb)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.moddifiedPb.Size = new System.Drawing.Size(336, 342);
            this.moddifiedPb.TabIndex = 1;
            this.moddifiedPb.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTsb,
            this.saveTsb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.moddifiedPb);
            this.Controls.Add(this.refferencePb);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.refferencePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moddifiedPb)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox refferencePb;
        private System.Windows.Forms.PictureBox moddifiedPb;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadTsb;
        private System.Windows.Forms.ToolStripButton saveTsb;
    }
}

