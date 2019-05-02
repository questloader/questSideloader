namespace QuestSideloader
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.lStatus = new System.Windows.Forms.Label();
            this.lDrop = new System.Windows.Forms.Label();
            this.devicesTimer = new System.Windows.Forms.Timer(this.components);
            this.linkToOculus = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lStatus
            // 
            this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lStatus.Location = new System.Drawing.Point(-2, -1);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(634, 56);
            this.lStatus.TabIndex = 0;
            this.lStatus.Text = "Please wait...";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // lDrop
            // 
            this.lDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDrop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lDrop.Location = new System.Drawing.Point(-2, 55);
            this.lDrop.Name = "lDrop";
            this.lDrop.Size = new System.Drawing.Size(634, 299);
            this.lDrop.TabIndex = 1;
            this.lDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // devicesTimer
            // 
            this.devicesTimer.Interval = 1000;
            this.devicesTimer.Tick += new System.EventHandler(this.devicesTimer_Tick);
            // 
            // linkToOculus
            // 
            this.linkToOculus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkToOculus.BackColor = System.Drawing.Color.White;
            this.linkToOculus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkToOculus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.linkToOculus.Location = new System.Drawing.Point(-5, 354);
            this.linkToOculus.Name = "linkToOculus";
            this.linkToOculus.Size = new System.Drawing.Size(654, 49);
            this.linkToOculus.TabIndex = 2;
            this.linkToOculus.TabStop = true;
            this.linkToOculus.Text = "You must enable developer mode on your Oculus account before using this tool. \r\nC" +
    "lick here and follow the instructions, then plug in your device.";
            this.linkToOculus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkToOculus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToOculus_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(20, 363);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(630, 404);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkToOculus);
            this.Controls.Add(this.lDrop);
            this.Controls.Add(this.lStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Quest/Go Sideloader v1.0 - github.com/questloader/questSideloader";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label lDrop;
        private System.Windows.Forms.Timer devicesTimer;
        private System.Windows.Forms.LinkLabel linkToOculus;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

