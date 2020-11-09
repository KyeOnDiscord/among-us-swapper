namespace ProSwapper
{
    partial class Maps
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.list = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.wait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.linkLabel1.Location = new System.Drawing.Point(453, 423);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(164, 17);
            this.linkLabel1.TabIndex = 77;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Credit to DepresseoCoffee";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // list
            // 
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.list.FormattingEnabled = true;
            this.list.ItemHeight = 17;
            this.list.Location = new System.Drawing.Point(167, 175);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(240, 187);
            this.list.TabIndex = 81;
            this.list.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(419, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 82;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(419, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 37);
            this.button1.TabIndex = 83;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wait
            // 
            this.wait.AutoSize = true;
            this.wait.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.wait.ForeColor = System.Drawing.Color.White;
            this.wait.Location = new System.Drawing.Point(483, 463);
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(105, 20);
            this.wait.TabIndex = 84;
            this.wait.Text = "Please wait...";
            this.wait.Visible = false;
            // 
            // Maps
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(127)))), ((int)(((byte)(229)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.wait);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.list);
            this.Controls.Add(this.linkLabel1);
            this.DoubleBuffered = true;
            this.Name = "Maps";
            this.Size = new System.Drawing.Size(986, 818);
            this.Load += new System.EventHandler(this.Skins_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label wait;
    }
}
