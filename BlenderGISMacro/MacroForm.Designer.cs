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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.macroExecutorPanel = new System.Windows.Forms.Panel();
            this.macroActionComboBox = new System.Windows.Forms.ComboBox();
            this.macroPropertiesListBox = new System.Windows.Forms.ListBox();
            this.macroPropertiesLabel = new System.Windows.Forms.Label();
            this.macroActionsLabel = new System.Windows.Forms.Label();
            this.macroTypesLabel = new System.Windows.Forms.Label();
            this.macroIdLabel = new System.Windows.Forms.Label();
            this.macroNameTextBox = new System.Windows.Forms.TextBox();
            this.macroNameLabel = new System.Windows.Forms.Label();
            this.macroDataSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.macroEditorPanel.SuspendLayout();
            this.macroExecutorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataSplitContainer)).BeginInit();
            this.macroDataSplitContainer.Panel1.SuspendLayout();
            this.macroDataSplitContainer.Panel2.SuspendLayout();
            this.macroDataSplitContainer.SuspendLayout();
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
            this.macrosListBox.MultiColumn = true;
            this.macrosListBox.Name = "macrosListBox";
            this.macrosListBox.Size = new System.Drawing.Size(127, 302);
            this.macrosListBox.TabIndex = 22;
            this.macrosListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.macrosListBox_DragDrop);
            this.macrosListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.macrosListBox_DragOver);
            this.macrosListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.macrosListBox_MouseDown);
            // 
            // macrosComboBox
            // 
            this.macrosComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macrosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.macrosComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.macrosComboBox.FormattingEnabled = true;
            this.macrosComboBox.Location = new System.Drawing.Point(3, 16);
            this.macrosComboBox.Name = "macrosComboBox";
            this.macrosComboBox.Size = new System.Drawing.Size(286, 21);
            this.macrosComboBox.TabIndex = 0;
            this.macrosComboBox.SelectedIndexChanged += new System.EventHandler(this.macrosComboBox_SelectedIndexChanged);
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
            this.macroEditorPanel.Controls.Add(this.macroTypesLabel);
            this.macroEditorPanel.Controls.Add(this.macroExecutorPanel);
            this.macroEditorPanel.Controls.Add(this.button3);
            this.macroEditorPanel.Controls.Add(this.button2);
            this.macroEditorPanel.Controls.Add(this.button1);
            this.macroEditorPanel.Controls.Add(this.macrosComboBox);
            this.macroEditorPanel.Location = new System.Drawing.Point(3, 3);
            this.macroEditorPanel.Name = "macroEditorPanel";
            this.macroEditorPanel.Size = new System.Drawing.Size(292, 302);
            this.macroEditorPanel.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(3, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(214, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add to list";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(133, 276);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // macroExecutorPanel
            // 
            this.macroExecutorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroExecutorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.macroExecutorPanel.Controls.Add(this.macroDataSplitContainer);
            this.macroExecutorPanel.Location = new System.Drawing.Point(3, 43);
            this.macroExecutorPanel.Name = "macroExecutorPanel";
            this.macroExecutorPanel.Size = new System.Drawing.Size(286, 227);
            this.macroExecutorPanel.TabIndex = 4;
            // 
            // macroActionComboBox
            // 
            this.macroActionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.macroActionComboBox.FormattingEnabled = true;
            this.macroActionComboBox.Location = new System.Drawing.Point(3, 59);
            this.macroActionComboBox.Name = "macroActionComboBox";
            this.macroActionComboBox.Size = new System.Drawing.Size(127, 21);
            this.macroActionComboBox.TabIndex = 0;
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
            this.macroPropertiesListBox.Size = new System.Drawing.Size(139, 205);
            this.macroPropertiesListBox.TabIndex = 1;
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
            // macroActionsLabel
            // 
            this.macroActionsLabel.AutoSize = true;
            this.macroActionsLabel.Location = new System.Drawing.Point(3, 42);
            this.macroActionsLabel.Name = "macroActionsLabel";
            this.macroActionsLabel.Size = new System.Drawing.Size(45, 13);
            this.macroActionsLabel.TabIndex = 3;
            this.macroActionsLabel.Text = "Actions:";
            // 
            // macroTypesLabel
            // 
            this.macroTypesLabel.AutoSize = true;
            this.macroTypesLabel.Location = new System.Drawing.Point(3, 0);
            this.macroTypesLabel.Name = "macroTypesLabel";
            this.macroTypesLabel.Size = new System.Drawing.Size(34, 13);
            this.macroTypesLabel.TabIndex = 4;
            this.macroTypesLabel.Text = "Type:";
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
            // macroNameTextBox
            // 
            this.macroNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroNameTextBox.Location = new System.Drawing.Point(3, 16);
            this.macroNameTextBox.Name = "macroNameTextBox";
            this.macroNameTextBox.Size = new System.Drawing.Size(127, 20);
            this.macroNameTextBox.TabIndex = 5;
            this.macroNameTextBox.TextChanged += new System.EventHandler(this.macroNameTextBox_TextChanged);
            // 
            // macroNameLabel
            // 
            this.macroNameLabel.AutoSize = true;
            this.macroNameLabel.BackColor = System.Drawing.Color.White;
            this.macroNameLabel.CausesValidation = false;
            this.macroNameLabel.Enabled = false;
            this.macroNameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.macroNameLabel.Location = new System.Drawing.Point(7, 19);
            this.macroNameLabel.Name = "macroNameLabel";
            this.macroNameLabel.Size = new System.Drawing.Size(35, 13);
            this.macroNameLabel.TabIndex = 6;
            this.macroNameLabel.Text = "Name";
            // 
            // macroDataSplitContainer
            // 
            this.macroDataSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroDataSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.macroDataSplitContainer.Location = new System.Drawing.Point(-1, -1);
            this.macroDataSplitContainer.Name = "macroDataSplitContainer";
            // 
            // macroDataSplitContainer.Panel1
            // 
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
            this.macroDataSplitContainer.Size = new System.Drawing.Size(286, 227);
            this.macroDataSplitContainer.SplitterDistance = 135;
            this.macroDataSplitContainer.TabIndex = 7;
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
            this.macroEditorPanel.PerformLayout();
            this.macroExecutorPanel.ResumeLayout(false);
            this.macroDataSplitContainer.Panel1.ResumeLayout(false);
            this.macroDataSplitContainer.Panel1.PerformLayout();
            this.macroDataSplitContainer.Panel2.ResumeLayout(false);
            this.macroDataSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataSplitContainer)).EndInit();
            this.macroDataSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListBox macrosListBox;
        private System.Windows.Forms.ComboBox macrosComboBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel macroEditorPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel macroExecutorPanel;
        private System.Windows.Forms.ComboBox macroActionComboBox;
        private System.Windows.Forms.Label macroTypesLabel;
        private System.Windows.Forms.Label macroActionsLabel;
        private System.Windows.Forms.Label macroPropertiesLabel;
        private System.Windows.Forms.ListBox macroPropertiesListBox;
        private System.Windows.Forms.TextBox macroNameTextBox;
        private System.Windows.Forms.Label macroIdLabel;
        private System.Windows.Forms.SplitContainer macroDataSplitContainer;
        private System.Windows.Forms.Label macroNameLabel;
    }
}

