namespace MacroMan
{
    partial class MacroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.macrosListBox = new System.Windows.Forms.ListBox();
            this.macrosComboBox = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.macroEditorPanel = new System.Windows.Forms.Panel();
            this.macroDataSplitContainer = new System.Windows.Forms.SplitContainer();
            this.propertyOptionsPanel = new System.Windows.Forms.Panel();
            this.propertyOptionsComboBox = new System.Windows.Forms.ComboBox();
            this.propertyValuePanel = new System.Windows.Forms.Panel();
            this.propertyValueLabel = new System.Windows.Forms.Label();
            this.propertyValueTextBox = new System.Windows.Forms.TextBox();
            this.macroIdLabel = new System.Windows.Forms.Label();
            this.macroNameLabel = new System.Windows.Forms.Label();
            this.macroActionComboBox = new System.Windows.Forms.ComboBox();
            this.macroNameTextBox = new System.Windows.Forms.TextBox();
            this.macroActionsLabel = new System.Windows.Forms.Label();
            this.macroPropertiesListBox = new System.Windows.Forms.ListBox();
            this.macroPropertiesLabel = new System.Windows.Forms.Label();
            this.addToListButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.shiftMacroUpButton = new System.Windows.Forms.Button();
            this.shiftMacroDownButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.macroEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataSplitContainer)).BeginInit();
            this.macroDataSplitContainer.Panel1.SuspendLayout();
            this.macroDataSplitContainer.Panel2.SuspendLayout();
            this.macroDataSplitContainer.SuspendLayout();
            this.propertyOptionsPanel.SuspendLayout();
            this.propertyValuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Macro Man";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // macrosListBox
            // 
            this.macrosListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macrosListBox.FormattingEnabled = true;
            this.macrosListBox.IntegralHeight = false;
            this.macrosListBox.Location = new System.Drawing.Point(3, 3);
            this.macrosListBox.Name = "macrosListBox";
            this.macrosListBox.Size = new System.Drawing.Size(127, 274);
            this.macrosListBox.TabIndex = 22;
            this.macrosListBox.SelectedIndexChanged += new System.EventHandler(this.macrosListBox_SelectedIndexChanged);
            this.macrosListBox.DoubleClick += new System.EventHandler(this.macrosListBox_DoubleClick);
            this.macrosListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.macrosListBox_KeyDown);
            // 
            // macrosComboBox
            // 
            this.macrosComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.macrosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.macrosComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.macrosComboBox.FormattingEnabled = true;
            this.macrosComboBox.Location = new System.Drawing.Point(3, 278);
            this.macrosComboBox.Name = "macrosComboBox";
            this.macrosComboBox.Size = new System.Drawing.Size(75, 21);
            this.macrosComboBox.TabIndex = 0;
            this.macrosComboBox.TabStop = false;
            this.macrosComboBox.Visible = false;
            this.macrosComboBox.SelectionChangeCommitted += new System.EventHandler(this.macrosComboBox_SelectionChangeCommitted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.macroEditorPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.playButton);
            this.splitContainer1.Panel2.Controls.Add(this.deleteButton);
            this.splitContainer1.Panel2.Controls.Add(this.shiftMacroDownButton);
            this.splitContainer1.Panel2.Controls.Add(this.shiftMacroUpButton);
            this.splitContainer1.Panel2.Controls.Add(this.macrosListBox);
            this.splitContainer1.Size = new System.Drawing.Size(443, 312);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 24;
            // 
            // macroEditorPanel
            // 
            this.macroEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroEditorPanel.Controls.Add(this.macroDataSplitContainer);
            this.macroEditorPanel.Controls.Add(this.addToListButton);
            this.macroEditorPanel.Controls.Add(this.newButton);
            this.macroEditorPanel.Controls.Add(this.macrosComboBox);
            this.macroEditorPanel.Location = new System.Drawing.Point(3, 3);
            this.macroEditorPanel.Name = "macroEditorPanel";
            this.macroEditorPanel.Size = new System.Drawing.Size(292, 302);
            this.macroEditorPanel.TabIndex = 23;
            // 
            // macroDataSplitContainer
            // 
            this.macroDataSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroDataSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.macroDataSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.macroDataSplitContainer.Name = "macroDataSplitContainer";
            // 
            // macroDataSplitContainer.Panel1
            // 
            this.macroDataSplitContainer.Panel1.Controls.Add(this.propertyOptionsPanel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.propertyValuePanel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroIdLabel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroNameLabel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroActionComboBox);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroNameTextBox);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroActionsLabel);
            // 
            // macroDataSplitContainer.Panel2
            // 
            this.macroDataSplitContainer.Panel2.Controls.Add(this.macroPropertiesListBox);
            this.macroDataSplitContainer.Panel2.Controls.Add(this.macroPropertiesLabel);
            this.macroDataSplitContainer.Size = new System.Drawing.Size(292, 274);
            this.macroDataSplitContainer.SplitterDistance = 134;
            this.macroDataSplitContainer.TabIndex = 7;
            // 
            // propertyOptionsPanel
            // 
            this.propertyOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyOptionsPanel.Controls.Add(this.propertyOptionsComboBox);
            this.propertyOptionsPanel.Location = new System.Drawing.Point(2, 129);
            this.propertyOptionsPanel.Name = "propertyOptionsPanel";
            this.propertyOptionsPanel.Size = new System.Drawing.Size(127, 30);
            this.propertyOptionsPanel.TabIndex = 11;
            // 
            // propertyOptionsComboBox
            // 
            this.propertyOptionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyOptionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propertyOptionsComboBox.FormattingEnabled = true;
            this.propertyOptionsComboBox.Location = new System.Drawing.Point(3, 3);
            this.propertyOptionsComboBox.Name = "propertyOptionsComboBox";
            this.propertyOptionsComboBox.Size = new System.Drawing.Size(119, 21);
            this.propertyOptionsComboBox.TabIndex = 7;
            this.propertyOptionsComboBox.SelectionChangeCommitted += new System.EventHandler(this.propertyOptionsComboBox_SelectionChangeCommitted);
            // 
            // propertyValuePanel
            // 
            this.propertyValuePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyValuePanel.Controls.Add(this.propertyValueLabel);
            this.propertyValuePanel.Controls.Add(this.propertyValueTextBox);
            this.propertyValuePanel.Location = new System.Drawing.Point(2, 86);
            this.propertyValuePanel.Name = "propertyValuePanel";
            this.propertyValuePanel.Size = new System.Drawing.Size(127, 41);
            this.propertyValuePanel.TabIndex = 9;
            // 
            // propertyValueLabel
            // 
            this.propertyValueLabel.AutoSize = true;
            this.propertyValueLabel.Location = new System.Drawing.Point(3, 0);
            this.propertyValueLabel.Name = "propertyValueLabel";
            this.propertyValueLabel.Size = new System.Drawing.Size(37, 13);
            this.propertyValueLabel.TabIndex = 10;
            this.propertyValueLabel.Text = "Value:";
            // 
            // propertyValueTextBox
            // 
            this.propertyValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyValueTextBox.Location = new System.Drawing.Point(3, 16);
            this.propertyValueTextBox.Name = "propertyValueTextBox";
            this.propertyValueTextBox.Size = new System.Drawing.Size(119, 20);
            this.propertyValueTextBox.TabIndex = 8;
            this.propertyValueTextBox.TextChanged += new System.EventHandler(this.propertyValueTextBox_TextChanged);
            // 
            // macroIdLabel
            // 
            this.macroIdLabel.AutoSize = true;
            this.macroIdLabel.Location = new System.Drawing.Point(3, 0);
            this.macroIdLabel.Name = "macroIdLabel";
            this.macroIdLabel.Size = new System.Drawing.Size(24, 13);
            this.macroIdLabel.TabIndex = 4;
            this.macroIdLabel.Text = "id: -";
            // 
            // macroNameLabel
            // 
            this.macroNameLabel.AutoSize = true;
            this.macroNameLabel.BackColor = System.Drawing.Color.White;
            this.macroNameLabel.Enabled = false;
            this.macroNameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.macroNameLabel.Location = new System.Drawing.Point(7, 19);
            this.macroNameLabel.Name = "macroNameLabel";
            this.macroNameLabel.Size = new System.Drawing.Size(35, 13);
            this.macroNameLabel.TabIndex = 6;
            this.macroNameLabel.Text = "Name";
            // 
            // macroActionComboBox
            // 
            this.macroActionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.macroActionComboBox.FormattingEnabled = true;
            this.macroActionComboBox.Location = new System.Drawing.Point(3, 59);
            this.macroActionComboBox.Name = "macroActionComboBox";
            this.macroActionComboBox.Size = new System.Drawing.Size(126, 21);
            this.macroActionComboBox.TabIndex = 0;
            this.macroActionComboBox.SelectionChangeCommitted += new System.EventHandler(this.macroActionComboBox_SelectionChangeCommitted);
            // 
            // macroNameTextBox
            // 
            this.macroNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroNameTextBox.Location = new System.Drawing.Point(3, 16);
            this.macroNameTextBox.Name = "macroNameTextBox";
            this.macroNameTextBox.Size = new System.Drawing.Size(126, 20);
            this.macroNameTextBox.TabIndex = 5;
            this.macroNameTextBox.TextChanged += new System.EventHandler(this.macroNameTextBox_TextChanged);
            // 
            // macroActionsLabel
            // 
            this.macroActionsLabel.AutoSize = true;
            this.macroActionsLabel.Location = new System.Drawing.Point(3, 42);
            this.macroActionsLabel.Name = "macroActionsLabel";
            this.macroActionsLabel.Size = new System.Drawing.Size(40, 13);
            this.macroActionsLabel.TabIndex = 3;
            this.macroActionsLabel.Text = "Action:";
            // 
            // macroPropertiesListBox
            // 
            this.macroPropertiesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroPropertiesListBox.FormattingEnabled = true;
            this.macroPropertiesListBox.IntegralHeight = false;
            this.macroPropertiesListBox.Location = new System.Drawing.Point(3, 17);
            this.macroPropertiesListBox.Name = "macroPropertiesListBox";
            this.macroPropertiesListBox.Size = new System.Drawing.Size(146, 252);
            this.macroPropertiesListBox.TabIndex = 1;
            this.macroPropertiesListBox.SelectedIndexChanged += new System.EventHandler(this.macroPropertiesListBox_SelectedIndexChanged);
            // 
            // macroPropertiesLabel
            // 
            this.macroPropertiesLabel.AutoSize = true;
            this.macroPropertiesLabel.Location = new System.Drawing.Point(3, 1);
            this.macroPropertiesLabel.Name = "macroPropertiesLabel";
            this.macroPropertiesLabel.Size = new System.Drawing.Size(57, 13);
            this.macroPropertiesLabel.TabIndex = 2;
            this.macroPropertiesLabel.Text = "Properties:";
            // 
            // addToListButton
            // 
            this.addToListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addToListButton.Enabled = false;
            this.addToListButton.Location = new System.Drawing.Point(214, 276);
            this.addToListButton.Name = "addToListButton";
            this.addToListButton.Size = new System.Drawing.Size(75, 23);
            this.addToListButton.TabIndex = 2;
            this.addToListButton.Text = "Add to list";
            this.addToListButton.UseVisualStyleBackColor = true;
            this.addToListButton.Click += new System.EventHandler(this.addToListButton_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newButton.Location = new System.Drawing.Point(3, 276);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // shiftMacroUpButton
            // 
            this.shiftMacroUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shiftMacroUpButton.Location = new System.Drawing.Point(3, 279);
            this.shiftMacroUpButton.Name = "shiftMacroUpButton";
            this.shiftMacroUpButton.Size = new System.Drawing.Size(23, 23);
            this.shiftMacroUpButton.TabIndex = 8;
            this.shiftMacroUpButton.Text = "↑";
            this.shiftMacroUpButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.shiftMacroUpButton.UseVisualStyleBackColor = true;
            this.shiftMacroUpButton.Click += new System.EventHandler(this.shiftMacroUpButton_Click);
            // 
            // shiftMacroDownButton
            // 
            this.shiftMacroDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shiftMacroDownButton.Location = new System.Drawing.Point(32, 279);
            this.shiftMacroDownButton.Name = "shiftMacroDownButton";
            this.shiftMacroDownButton.Size = new System.Drawing.Size(23, 23);
            this.shiftMacroDownButton.TabIndex = 23;
            this.shiftMacroDownButton.Text = "↓";
            this.shiftMacroDownButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.shiftMacroDownButton.UseVisualStyleBackColor = true;
            this.shiftMacroDownButton.Click += new System.EventHandler(this.shiftMacroDownButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(61, 279);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteButton.Size = new System.Drawing.Size(23, 23);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.Text = "✕";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Location = new System.Drawing.Point(107, 279);
            this.playButton.Name = "playButton";
            this.playButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.playButton.Size = new System.Drawing.Size(23, 23);
            this.playButton.TabIndex = 25;
            this.playButton.Text = "▷";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // MacroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 334);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MacroForm";
            this.Text = "Macro Man";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MacroForm_FormClosing);
            this.Resize += new System.EventHandler(this.MacroForm_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.macroEditorPanel.ResumeLayout(false);
            this.macroDataSplitContainer.Panel1.ResumeLayout(false);
            this.macroDataSplitContainer.Panel1.PerformLayout();
            this.macroDataSplitContainer.Panel2.ResumeLayout(false);
            this.macroDataSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataSplitContainer)).EndInit();
            this.macroDataSplitContainer.ResumeLayout(false);
            this.propertyOptionsPanel.ResumeLayout(false);
            this.propertyValuePanel.ResumeLayout(false);
            this.propertyValuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListBox macrosListBox;
        private System.Windows.Forms.ComboBox macrosComboBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel macroEditorPanel;
        private System.Windows.Forms.Button addToListButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ComboBox macroActionComboBox;
        private System.Windows.Forms.Label macroActionsLabel;
        private System.Windows.Forms.Label macroPropertiesLabel;
        private System.Windows.Forms.ListBox macroPropertiesListBox;
        private System.Windows.Forms.TextBox macroNameTextBox;
        private System.Windows.Forms.Label macroIdLabel;
        private System.Windows.Forms.SplitContainer macroDataSplitContainer;
        private System.Windows.Forms.Label macroNameLabel;
        private System.Windows.Forms.TextBox propertyValueTextBox;
        private System.Windows.Forms.ComboBox propertyOptionsComboBox;
        private System.Windows.Forms.Panel propertyValuePanel;
        private System.Windows.Forms.Panel propertyOptionsPanel;
        private System.Windows.Forms.Label propertyValueLabel;
        private System.Windows.Forms.Button shiftMacroDownButton;
        private System.Windows.Forms.Button shiftMacroUpButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button deleteButton;
    }
}

