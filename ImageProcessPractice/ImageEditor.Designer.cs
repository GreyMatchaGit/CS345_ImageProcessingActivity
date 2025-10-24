namespace ImageProcessPractice
{
    partial class ImageEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openImageToolStripMenuItem = new ToolStripMenuItem();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyImageToolStripMenuItem = new ToolStripMenuItem();
            grayScaleToolStripMenuItem = new ToolStripMenuItem();
            invertToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            showHistogramToolStripMenuItem = new ToolStripMenuItem();
            removeBackgroundToolStripMenuItem = new ToolStripMenuItem();
            rotationToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            saveFileDialog1 = new SaveFileDialog();
            videoToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(14, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 600);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(34, 34, 32);
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, undoToolStripMenuItem, videoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1639, 37);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openImageToolStripMenuItem, saveImageToolStripMenuItem });
            fileToolStripMenuItem.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fileToolStripMenuItem.ForeColor = Color.FromArgb(231, 223, 213);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(74, 31);
            fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            openImageToolStripMenuItem.Size = new Size(218, 32);
            openImageToolStripMenuItem.Text = "Open Image";
            openImageToolStripMenuItem.Click += openImageToolStripMenuItem_Click;
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(218, 32);
            saveImageToolStripMenuItem.Text = "Save Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyImageToolStripMenuItem, grayScaleToolStripMenuItem, invertToolStripMenuItem, sepiaToolStripMenuItem, showHistogramToolStripMenuItem, removeBackgroundToolStripMenuItem, rotationToolStripMenuItem });
            editToolStripMenuItem.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            editToolStripMenuItem.ForeColor = Color.FromArgb(231, 223, 213);
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 31);
            editToolStripMenuItem.Text = "Edit";
            // 
            // copyImageToolStripMenuItem
            // 
            copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            copyImageToolStripMenuItem.Size = new Size(302, 32);
            copyImageToolStripMenuItem.Text = "Copy Image";
            copyImageToolStripMenuItem.Click += copyImageToolStripMenuItem_Click;
            // 
            // grayScaleToolStripMenuItem
            // 
            grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            grayScaleToolStripMenuItem.Size = new Size(302, 32);
            grayScaleToolStripMenuItem.Text = "GrayScale";
            grayScaleToolStripMenuItem.Click += grayScaleToolStripMenuItem_Click;
            // 
            // invertToolStripMenuItem
            // 
            invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            invertToolStripMenuItem.Size = new Size(302, 32);
            invertToolStripMenuItem.Text = "Invert";
            invertToolStripMenuItem.Click += invertToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(302, 32);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // showHistogramToolStripMenuItem
            // 
            showHistogramToolStripMenuItem.Name = "showHistogramToolStripMenuItem";
            showHistogramToolStripMenuItem.Size = new Size(302, 32);
            showHistogramToolStripMenuItem.Text = "Show Histogram";
            showHistogramToolStripMenuItem.Click += showHistogramToolStripMenuItem_Click;
            // 
            // removeBackgroundToolStripMenuItem
            // 
            removeBackgroundToolStripMenuItem.Name = "removeBackgroundToolStripMenuItem";
            removeBackgroundToolStripMenuItem.Size = new Size(302, 32);
            removeBackgroundToolStripMenuItem.Text = "Remove Background";
            removeBackgroundToolStripMenuItem.Click += removeBackgroundToolStripMenuItem_Click;
            // 
            // rotationToolStripMenuItem
            // 
            rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            rotationToolStripMenuItem.Size = new Size(302, 32);
            rotationToolStripMenuItem.Text = "Rotation";
            rotationToolStripMenuItem.Click += rotationToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Font = new Font("Cascadia Code SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            undoToolStripMenuItem.ForeColor = Color.FromArgb(231, 223, 213);
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(74, 31);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(825, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(800, 600);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(0, 40);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(11, 13, 11, 13);
            panel1.Size = new Size(1639, 631);
            panel1.TabIndex = 8;
            // 
            // videoToolStripMenuItem
            // 
            videoToolStripMenuItem.Font = new Font("Cascadia Code SemiBold", 12F, FontStyle.Bold);
            videoToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            videoToolStripMenuItem.Size = new Size(86, 31);
            videoToolStripMenuItem.Text = "Video";
            videoToolStripMenuItem.Click += videoToolStripMenuItem_Click;
            // 
            // ImageEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1639, 668);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "ImageEditor";
            Text = "Image Editor";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openImageToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem grayScaleToolStripMenuItem;
        private ToolStripMenuItem invertToolStripMenuItem;
        private PictureBox pictureBox2;
        private ToolStripMenuItem copyImageToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem showHistogramToolStripMenuItem;
        private ToolStripMenuItem removeBackgroundToolStripMenuItem;
        private ToolStripMenuItem rotationToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem videoToolStripMenuItem;
    }
}
