namespace PlainTextReader
{
    partial class frmPrincipalScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipalScreen));
            this.btnTxt = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.btnRtf = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTxt
            // 
            this.btnTxt.BackColor = System.Drawing.Color.White;
            this.btnTxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTxt.BackgroundImage")));
            this.btnTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTxt.Font = new System.Drawing.Font("Signika Negative", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTxt.ForeColor = System.Drawing.Color.White;
            this.btnTxt.Location = new System.Drawing.Point(30, 35);
            this.btnTxt.Name = "btnTxt";
            this.btnTxt.Size = new System.Drawing.Size(129, 51);
            this.btnTxt.TabIndex = 0;
            this.btnTxt.Text = ".txt";
            this.btnTxt.UseVisualStyleBackColor = false;
            this.btnTxt.Click += new System.EventHandler(this.btnTxt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(196, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 311);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pbTitle
            // 
            this.pbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(208)))), ((int)(((byte)(120)))));
            this.pbTitle.Image = ((System.Drawing.Image)(resources.GetObject("pbTitle.Image")));
            this.pbTitle.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbTitle.InitialImage")));
            this.pbTitle.Location = new System.Drawing.Point(243, 110);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(186, 90);
            this.pbTitle.TabIndex = 7;
            this.pbTitle.TabStop = false;
            // 
            // btnRtf
            // 
            this.btnRtf.BackColor = System.Drawing.Color.White;
            this.btnRtf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRtf.BackgroundImage")));
            this.btnRtf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRtf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRtf.Font = new System.Drawing.Font("Signika Negative", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRtf.ForeColor = System.Drawing.Color.White;
            this.btnRtf.Location = new System.Drawing.Point(30, 98);
            this.btnRtf.Name = "btnRtf";
            this.btnRtf.Size = new System.Drawing.Size(129, 51);
            this.btnRtf.TabIndex = 1;
            this.btnRtf.Text = ".rtf";
            this.btnRtf.UseVisualStyleBackColor = false;
            this.btnRtf.Click += new System.EventHandler(this.btnRtf_Click);
            // 
            // btnCsv
            // 
            this.btnCsv.BackColor = System.Drawing.Color.White;
            this.btnCsv.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCsv.BackgroundImage")));
            this.btnCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCsv.Font = new System.Drawing.Font("Signika Negative", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCsv.ForeColor = System.Drawing.Color.White;
            this.btnCsv.Location = new System.Drawing.Point(30, 161);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(129, 51);
            this.btnCsv.TabIndex = 2;
            this.btnCsv.Text = ".csv";
            this.btnCsv.UseVisualStyleBackColor = false;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // btnXml
            // 
            this.btnXml.BackColor = System.Drawing.Color.White;
            this.btnXml.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXml.BackgroundImage")));
            this.btnXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXml.Font = new System.Drawing.Font("Signika Negative", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXml.ForeColor = System.Drawing.Color.White;
            this.btnXml.Location = new System.Drawing.Point(30, 224);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(129, 51);
            this.btnXml.TabIndex = 3;
            this.btnXml.Text = ".xml";
            this.btnXml.UseVisualStyleBackColor = false;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // frmPrincipalScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 311);
            this.Controls.Add(this.btnRtf);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.btnXml);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnTxt);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipalScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnTxt;
        private PictureBox pictureBox1;
        private PictureBox pbTitle;
        private Button btnRtf;
        private Button btnCsv;
        private Button btnXml;
    }
}