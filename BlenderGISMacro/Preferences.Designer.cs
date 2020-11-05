namespace MacroMan
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.toggleSequenceShortcutCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.toggleSequenceShortcutLabel = new System.Windows.Forms.Label();
            this.runSequenceShortcutLabel = new System.Windows.Forms.Label();
            this.sequenceFrameDelayTextBox = new System.Windows.Forms.TextBox();
            this.sequenceFrameDelayLabel = new System.Windows.Forms.Label();
            this.sequenceFrameDelayInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toggleSequenceShortcutCheckedListBox
            // 
            this.toggleSequenceShortcutCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSequenceShortcutCheckedListBox.FormattingEnabled = true;
            this.toggleSequenceShortcutCheckedListBox.IntegralHeight = false;
            this.toggleSequenceShortcutCheckedListBox.Location = new System.Drawing.Point(12, 41);
            this.toggleSequenceShortcutCheckedListBox.Name = "toggleSequenceShortcutCheckedListBox";
            this.toggleSequenceShortcutCheckedListBox.Size = new System.Drawing.Size(120, 233);
            this.toggleSequenceShortcutCheckedListBox.TabIndex = 1;
            this.toggleSequenceShortcutCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.toggleSequenceShortcutCheckedListBox_SelectedIndexChanged);
            this.toggleSequenceShortcutCheckedListBox.DoubleClick += new System.EventHandler(this.toggleSequenceShortcutCheckedListBox_DoubleClick);
            this.toggleSequenceShortcutCheckedListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toggleSequenceShortcutCheckedListBox_KeyPress);
            // 
            // toggleSequenceShortcutLabel
            // 
            this.toggleSequenceShortcutLabel.AutoSize = true;
            this.toggleSequenceShortcutLabel.Location = new System.Drawing.Point(9, 9);
            this.toggleSequenceShortcutLabel.Name = "toggleSequenceShortcutLabel";
            this.toggleSequenceShortcutLabel.Size = new System.Drawing.Size(138, 13);
            this.toggleSequenceShortcutLabel.TabIndex = 2;
            this.toggleSequenceShortcutLabel.Text = "Toggle Sequence Shortcut:";
            // 
            // runSequenceShortcutLabel
            // 
            this.runSequenceShortcutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runSequenceShortcutLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.runSequenceShortcutLabel.Location = new System.Drawing.Point(12, 22);
            this.runSequenceShortcutLabel.Name = "runSequenceShortcutLabel";
            this.runSequenceShortcutLabel.Size = new System.Drawing.Size(249, 16);
            this.runSequenceShortcutLabel.TabIndex = 3;
            this.runSequenceShortcutLabel.Text = "None";
            // 
            // sequenceFrameDelayTextBox
            // 
            this.sequenceFrameDelayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceFrameDelayTextBox.Location = new System.Drawing.Point(141, 57);
            this.sequenceFrameDelayTextBox.Name = "sequenceFrameDelayTextBox";
            this.sequenceFrameDelayTextBox.Size = new System.Drawing.Size(118, 20);
            this.sequenceFrameDelayTextBox.TabIndex = 4;
            this.sequenceFrameDelayTextBox.TextChanged += new System.EventHandler(this.sequenceFrameDelayTextBox_TextChanged);
            // 
            // sequenceFrameDelayLabel
            // 
            this.sequenceFrameDelayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceFrameDelayLabel.AutoSize = true;
            this.sequenceFrameDelayLabel.Location = new System.Drawing.Point(138, 41);
            this.sequenceFrameDelayLabel.Name = "sequenceFrameDelayLabel";
            this.sequenceFrameDelayLabel.Size = new System.Drawing.Size(121, 13);
            this.sequenceFrameDelayLabel.TabIndex = 5;
            this.sequenceFrameDelayLabel.Text = "Sequence Frame Delay:";
            // 
            // sequenceFrameDelayInfoLabel
            // 
            this.sequenceFrameDelayInfoLabel.Location = new System.Drawing.Point(141, 80);
            this.sequenceFrameDelayInfoLabel.Name = "sequenceFrameDelayInfoLabel";
            this.sequenceFrameDelayInfoLabel.Size = new System.Drawing.Size(120, 194);
            this.sequenceFrameDelayInfoLabel.TabIndex = 6;
            this.sequenceFrameDelayInfoLabel.Text = "Warning! Setting this value to zero may cause your device to stop responding when" +
    " the sequence is playing (depending on what kind of sequence you created).";
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 286);
            this.Controls.Add(this.sequenceFrameDelayInfoLabel);
            this.Controls.Add(this.sequenceFrameDelayLabel);
            this.Controls.Add(this.sequenceFrameDelayTextBox);
            this.Controls.Add(this.runSequenceShortcutLabel);
            this.Controls.Add(this.toggleSequenceShortcutLabel);
            this.Controls.Add(this.toggleSequenceShortcutCheckedListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox toggleSequenceShortcutCheckedListBox;
        private System.Windows.Forms.Label toggleSequenceShortcutLabel;
        private System.Windows.Forms.Label runSequenceShortcutLabel;
        private System.Windows.Forms.TextBox sequenceFrameDelayTextBox;
        private System.Windows.Forms.Label sequenceFrameDelayLabel;
        private System.Windows.Forms.Label sequenceFrameDelayInfoLabel;
    }
}