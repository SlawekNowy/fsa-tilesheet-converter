namespace FSA_TileSheet_Converter
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
            this.destPicBox = new System.Windows.Forms.PictureBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.destPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // destPicBox
            // 
            this.destPicBox.Location = new System.Drawing.Point(12, 12);
            this.destPicBox.Name = "destPicBox";
            this.destPicBox.Size = new System.Drawing.Size(256, 1024);
            this.destPicBox.TabIndex = 1;
            this.destPicBox.TabStop = false;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(275, 12);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(275, 222);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.Size = new System.Drawing.Size(202, 468);
            this.textBoxDebug.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(275, 42);
            this.progressBar1.Maximum = 8192;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(202, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.ClientSize = new System.Drawing.Size(543, 712);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.destPicBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.destPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox destPicBox;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

