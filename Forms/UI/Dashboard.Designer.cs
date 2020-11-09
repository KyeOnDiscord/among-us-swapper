namespace ProSwapper
{
    partial class Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.patchnotes = new System.Windows.Forms.RichTextBox();
            this.about = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 77);
            this.label3.TabIndex = 65;
            this.label3.Text = "Patch Notes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(663, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 77);
            this.label2.TabIndex = 64;
            this.label2.Text = "About";
            // 
            // patchnotes
            // 
            this.patchnotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(127)))), ((int)(((byte)(229)))));
            this.patchnotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.patchnotes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.patchnotes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.patchnotes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.patchnotes.Location = new System.Drawing.Point(23, 182);
            this.patchnotes.Name = "patchnotes";
            this.patchnotes.ReadOnly = true;
            this.patchnotes.Size = new System.Drawing.Size(383, 405);
            this.patchnotes.TabIndex = 66;
            this.patchnotes.Text = "Update 0.0.1\n\nRelease\n\n";
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(127)))), ((int)(((byte)(229)))));
            this.about.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.about.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.about.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.about.Location = new System.Drawing.Point(561, 182);
            this.about.Name = "about";
            this.about.ReadOnly = true;
            this.about.Size = new System.Drawing.Size(419, 405);
            this.about.TabIndex = 67;
            this.about.Text = "Pro Swapper Among Us is the easiest way to get custom textures for Among Us!";
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.about);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patchnotes);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(995, 606);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox patchnotes;
        private System.Windows.Forms.RichTextBox about;
    }
}
