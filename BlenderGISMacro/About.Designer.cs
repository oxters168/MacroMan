namespace MacroMan
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.oxGamesPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openSourceLabel = new System.Windows.Forms.Label();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.oxGamesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // oxGamesPictureBox
            // 
            this.oxGamesPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oxGamesPictureBox.BackgroundImage = global::BlenderGISMacro.Properties.Resources.OxGames_black_onAlpha;
            this.oxGamesPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.oxGamesPictureBox.InitialImage = null;
            this.oxGamesPictureBox.Location = new System.Drawing.Point(12, 3);
            this.oxGamesPictureBox.Name = "oxGamesPictureBox";
            this.oxGamesPictureBox.Size = new System.Drawing.Size(212, 120);
            this.oxGamesPictureBox.TabIndex = 0;
            this.oxGamesPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Created by";
            // 
            // openSourceLabel
            // 
            this.openSourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openSourceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.openSourceLabel.Location = new System.Drawing.Point(12, 104);
            this.openSourceLabel.Name = "openSourceLabel";
            this.openSourceLabel.Size = new System.Drawing.Size(212, 100);
            this.openSourceLabel.TabIndex = 2;
            this.openSourceLabel.Text = "This software is open source and entirely free to use. If you paid money to use t" +
    "his software, hopefully it was to donate to the developer, or else you were like" +
    "ly ripped off.";
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new System.Drawing.Point(178, 185);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(40, 13);
            this.githubLinkLabel.TabIndex = 3;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "GitHub";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLinkLabel_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 213);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.openSourceLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oxGamesPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.oxGamesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox oxGamesPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label openSourceLabel;
        private System.Windows.Forms.LinkLabel githubLinkLabel;
    }
}