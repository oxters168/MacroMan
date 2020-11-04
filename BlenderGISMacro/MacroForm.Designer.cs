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
            this.gotoMacroPanel = new System.Windows.Forms.Panel();
            this.gotoMacroCheckBox = new System.Windows.Forms.CheckBox();
            this.gotoMacroComboBox = new System.Windows.Forms.ComboBox();
            this.gotoMacroLabel = new System.Windows.Forms.Label();
            this.startConditionPanel = new System.Windows.Forms.Panel();
            this.startConditionSecondMacroIdComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionFirstMacroIdComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionOperationComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionSecondSourceComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionSecondValueTextBox = new System.Windows.Forms.TextBox();
            this.startConditionFirstValueTextBox = new System.Windows.Forms.TextBox();
            this.startConditionSecondValueComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionFirstValueComboBox = new System.Windows.Forms.ComboBox();
            this.hasStartConditionCheckBox = new System.Windows.Forms.CheckBox();
            this.startConditionFirstSourceComboBox = new System.Windows.Forms.ComboBox();
            this.actionOptionsPanel = new System.Windows.Forms.Panel();
            this.macroActionComboBox = new System.Windows.Forms.ComboBox();
            this.macroActionsLabel = new System.Windows.Forms.Label();
            this.propertyValuePanel = new System.Windows.Forms.Panel();
            this.propertyOptionsComboBox = new System.Windows.Forms.ComboBox();
            this.propertyValueLabel = new System.Windows.Forms.Label();
            this.propertyValueTextBox = new System.Windows.Forms.TextBox();
            this.macroIdLabel = new System.Windows.Forms.Label();
            this.macroNameLabel = new System.Windows.Forms.Label();
            this.macroNameTextBox = new System.Windows.Forms.TextBox();
            this.macroPropertiesListBox = new System.Windows.Forms.ListBox();
            this.macroPropertiesLabel = new System.Windows.Forms.Label();
            this.addToListButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.shiftMacroDownButton = new System.Windows.Forms.Button();
            this.shiftMacroUpButton = new System.Windows.Forms.Button();
            this.menuToolStrip = new System.Windows.Forms.ToolStrip();
            this.fileToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.integersDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringsDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.macroEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroDataSplitContainer)).BeginInit();
            this.macroDataSplitContainer.Panel1.SuspendLayout();
            this.macroDataSplitContainer.Panel2.SuspendLayout();
            this.macroDataSplitContainer.SuspendLayout();
            this.gotoMacroPanel.SuspendLayout();
            this.startConditionPanel.SuspendLayout();
            this.actionOptionsPanel.SuspendLayout();
            this.propertyValuePanel.SuspendLayout();
            this.menuToolStrip.SuspendLayout();
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
            this.macrosListBox.Size = new System.Drawing.Size(131, 329);
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
            this.macrosComboBox.Location = new System.Drawing.Point(3, 340);
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
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
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
            this.splitContainer1.Size = new System.Drawing.Size(454, 376);
            this.splitContainer1.SplitterDistance = 309;
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
            this.macroEditorPanel.Size = new System.Drawing.Size(299, 366);
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
            this.macroDataSplitContainer.Panel1.Controls.Add(this.gotoMacroPanel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.startConditionPanel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.actionOptionsPanel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.propertyValuePanel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroIdLabel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroNameLabel);
            this.macroDataSplitContainer.Panel1.Controls.Add(this.macroNameTextBox);
            // 
            // macroDataSplitContainer.Panel2
            // 
            this.macroDataSplitContainer.Panel2.Controls.Add(this.macroPropertiesListBox);
            this.macroDataSplitContainer.Panel2.Controls.Add(this.macroPropertiesLabel);
            this.macroDataSplitContainer.Size = new System.Drawing.Size(299, 334);
            this.macroDataSplitContainer.SplitterDistance = 137;
            this.macroDataSplitContainer.TabIndex = 7;
            // 
            // gotoMacroPanel
            // 
            this.gotoMacroPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gotoMacroPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gotoMacroPanel.Controls.Add(this.gotoMacroCheckBox);
            this.gotoMacroPanel.Controls.Add(this.gotoMacroComboBox);
            this.gotoMacroPanel.Controls.Add(this.gotoMacroLabel);
            this.gotoMacroPanel.Location = new System.Drawing.Point(2, 287);
            this.gotoMacroPanel.Name = "gotoMacroPanel";
            this.gotoMacroPanel.Size = new System.Drawing.Size(130, 41);
            this.gotoMacroPanel.TabIndex = 11;
            // 
            // gotoMacroCheckBox
            // 
            this.gotoMacroCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gotoMacroCheckBox.AutoSize = true;
            this.gotoMacroCheckBox.Location = new System.Drawing.Point(3, 19);
            this.gotoMacroCheckBox.Name = "gotoMacroCheckBox";
            this.gotoMacroCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gotoMacroCheckBox.TabIndex = 18;
            this.gotoMacroCheckBox.UseVisualStyleBackColor = true;
            this.gotoMacroCheckBox.Click += new System.EventHandler(this.gotoMacroCheckBox_Click);
            // 
            // gotoMacroComboBox
            // 
            this.gotoMacroComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gotoMacroComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gotoMacroComboBox.FormattingEnabled = true;
            this.gotoMacroComboBox.Location = new System.Drawing.Point(24, 15);
            this.gotoMacroComboBox.Name = "gotoMacroComboBox";
            this.gotoMacroComboBox.Size = new System.Drawing.Size(101, 21);
            this.gotoMacroComboBox.TabIndex = 7;
            this.gotoMacroComboBox.SelectionChangeCommitted += new System.EventHandler(this.gotoMacroComboBox_SelectionChangeCommitted);
            // 
            // gotoMacroLabel
            // 
            this.gotoMacroLabel.AutoSize = true;
            this.gotoMacroLabel.Location = new System.Drawing.Point(3, 0);
            this.gotoMacroLabel.Name = "gotoMacroLabel";
            this.gotoMacroLabel.Size = new System.Drawing.Size(36, 13);
            this.gotoMacroLabel.TabIndex = 10;
            this.gotoMacroLabel.Text = "Go to:";
            // 
            // startConditionPanel
            // 
            this.startConditionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startConditionPanel.Controls.Add(this.startConditionSecondMacroIdComboBox);
            this.startConditionPanel.Controls.Add(this.startConditionFirstMacroIdComboBox);
            this.startConditionPanel.Controls.Add(this.startConditionOperationComboBox);
            this.startConditionPanel.Controls.Add(this.startConditionSecondSourceComboBox);
            this.startConditionPanel.Controls.Add(this.startConditionSecondValueTextBox);
            this.startConditionPanel.Controls.Add(this.startConditionFirstValueTextBox);
            this.startConditionPanel.Controls.Add(this.startConditionSecondValueComboBox);
            this.startConditionPanel.Controls.Add(this.startConditionFirstValueComboBox);
            this.startConditionPanel.Controls.Add(this.hasStartConditionCheckBox);
            this.startConditionPanel.Controls.Add(this.startConditionFirstSourceComboBox);
            this.startConditionPanel.Location = new System.Drawing.Point(2, 42);
            this.startConditionPanel.Name = "startConditionPanel";
            this.startConditionPanel.Size = new System.Drawing.Size(130, 158);
            this.startConditionPanel.TabIndex = 12;
            // 
            // startConditionSecondMacroIdComboBox
            // 
            this.startConditionSecondMacroIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionSecondMacroIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionSecondMacroIdComboBox.FormattingEnabled = true;
            this.startConditionSecondMacroIdComboBox.Location = new System.Drawing.Point(67, 106);
            this.startConditionSecondMacroIdComboBox.Name = "startConditionSecondMacroIdComboBox";
            this.startConditionSecondMacroIdComboBox.Size = new System.Drawing.Size(58, 21);
            this.startConditionSecondMacroIdComboBox.TabIndex = 17;
            this.startConditionSecondMacroIdComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionSecondMacroIdComboBox_SelectionChangeCommitted);
            // 
            // startConditionFirstMacroIdComboBox
            // 
            this.startConditionFirstMacroIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionFirstMacroIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionFirstMacroIdComboBox.FormattingEnabled = true;
            this.startConditionFirstMacroIdComboBox.Location = new System.Drawing.Point(67, 26);
            this.startConditionFirstMacroIdComboBox.Name = "startConditionFirstMacroIdComboBox";
            this.startConditionFirstMacroIdComboBox.Size = new System.Drawing.Size(58, 21);
            this.startConditionFirstMacroIdComboBox.TabIndex = 16;
            this.startConditionFirstMacroIdComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionFirstMacroIdComboBox_SelectionChangeCommitted);
            // 
            // startConditionOperationComboBox
            // 
            this.startConditionOperationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionOperationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionOperationComboBox.FormattingEnabled = true;
            this.startConditionOperationComboBox.Location = new System.Drawing.Point(3, 79);
            this.startConditionOperationComboBox.Name = "startConditionOperationComboBox";
            this.startConditionOperationComboBox.Size = new System.Drawing.Size(122, 21);
            this.startConditionOperationComboBox.TabIndex = 15;
            this.startConditionOperationComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionOperationComboBox_SelectionChangeCommitted);
            // 
            // startConditionSecondSourceComboBox
            // 
            this.startConditionSecondSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionSecondSourceComboBox.FormattingEnabled = true;
            this.startConditionSecondSourceComboBox.Location = new System.Drawing.Point(3, 106);
            this.startConditionSecondSourceComboBox.Name = "startConditionSecondSourceComboBox";
            this.startConditionSecondSourceComboBox.Size = new System.Drawing.Size(58, 21);
            this.startConditionSecondSourceComboBox.TabIndex = 14;
            this.startConditionSecondSourceComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionSecondSourceComboBox_SelectionChangeCommitted);
            // 
            // startConditionSecondValueTextBox
            // 
            this.startConditionSecondValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionSecondValueTextBox.Location = new System.Drawing.Point(3, 133);
            this.startConditionSecondValueTextBox.Name = "startConditionSecondValueTextBox";
            this.startConditionSecondValueTextBox.Size = new System.Drawing.Size(122, 20);
            this.startConditionSecondValueTextBox.TabIndex = 13;
            this.startConditionSecondValueTextBox.TextChanged += new System.EventHandler(this.startConditionSecondValueTextBox_TextChanged);
            // 
            // startConditionFirstValueTextBox
            // 
            this.startConditionFirstValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionFirstValueTextBox.Location = new System.Drawing.Point(3, 53);
            this.startConditionFirstValueTextBox.Name = "startConditionFirstValueTextBox";
            this.startConditionFirstValueTextBox.Size = new System.Drawing.Size(122, 20);
            this.startConditionFirstValueTextBox.TabIndex = 11;
            this.startConditionFirstValueTextBox.TextChanged += new System.EventHandler(this.startConditionFirstValueTextBox_TextChanged);
            // 
            // startConditionSecondValueComboBox
            // 
            this.startConditionSecondValueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionSecondValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionSecondValueComboBox.FormattingEnabled = true;
            this.startConditionSecondValueComboBox.Location = new System.Drawing.Point(3, 133);
            this.startConditionSecondValueComboBox.Name = "startConditionSecondValueComboBox";
            this.startConditionSecondValueComboBox.Size = new System.Drawing.Size(122, 21);
            this.startConditionSecondValueComboBox.TabIndex = 12;
            this.startConditionSecondValueComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionSecondValueComboBox_SelectionChangeCommitted);
            // 
            // startConditionFirstValueComboBox
            // 
            this.startConditionFirstValueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionFirstValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionFirstValueComboBox.FormattingEnabled = true;
            this.startConditionFirstValueComboBox.Location = new System.Drawing.Point(3, 53);
            this.startConditionFirstValueComboBox.Name = "startConditionFirstValueComboBox";
            this.startConditionFirstValueComboBox.Size = new System.Drawing.Size(122, 21);
            this.startConditionFirstValueComboBox.TabIndex = 11;
            this.startConditionFirstValueComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionFirstValueComboBox_SelectionChangeCommitted);
            // 
            // hasStartConditionCheckBox
            // 
            this.hasStartConditionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hasStartConditionCheckBox.AutoSize = true;
            this.hasStartConditionCheckBox.Location = new System.Drawing.Point(3, 3);
            this.hasStartConditionCheckBox.Name = "hasStartConditionCheckBox";
            this.hasStartConditionCheckBox.Size = new System.Drawing.Size(114, 17);
            this.hasStartConditionCheckBox.TabIndex = 4;
            this.hasStartConditionCheckBox.Text = "Has start condition";
            this.hasStartConditionCheckBox.UseVisualStyleBackColor = true;
            this.hasStartConditionCheckBox.Click += new System.EventHandler(this.hasStartConditionCheckBox_Click);
            // 
            // startConditionFirstSourceComboBox
            // 
            this.startConditionFirstSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionFirstSourceComboBox.FormattingEnabled = true;
            this.startConditionFirstSourceComboBox.Location = new System.Drawing.Point(3, 26);
            this.startConditionFirstSourceComboBox.Name = "startConditionFirstSourceComboBox";
            this.startConditionFirstSourceComboBox.Size = new System.Drawing.Size(58, 21);
            this.startConditionFirstSourceComboBox.TabIndex = 0;
            this.startConditionFirstSourceComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionFirstSourceComboBox_SelectionChangeCommitted);
            // 
            // actionOptionsPanel
            // 
            this.actionOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actionOptionsPanel.Controls.Add(this.macroActionComboBox);
            this.actionOptionsPanel.Controls.Add(this.macroActionsLabel);
            this.actionOptionsPanel.Location = new System.Drawing.Point(2, 201);
            this.actionOptionsPanel.Name = "actionOptionsPanel";
            this.actionOptionsPanel.Size = new System.Drawing.Size(130, 41);
            this.actionOptionsPanel.TabIndex = 11;
            // 
            // macroActionComboBox
            // 
            this.macroActionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.macroActionComboBox.FormattingEnabled = true;
            this.macroActionComboBox.Location = new System.Drawing.Point(3, 15);
            this.macroActionComboBox.Name = "macroActionComboBox";
            this.macroActionComboBox.Size = new System.Drawing.Size(122, 21);
            this.macroActionComboBox.TabIndex = 0;
            this.macroActionComboBox.SelectionChangeCommitted += new System.EventHandler(this.macroActionComboBox_SelectionChangeCommitted);
            // 
            // macroActionsLabel
            // 
            this.macroActionsLabel.AutoSize = true;
            this.macroActionsLabel.Location = new System.Drawing.Point(4, 0);
            this.macroActionsLabel.Name = "macroActionsLabel";
            this.macroActionsLabel.Size = new System.Drawing.Size(40, 13);
            this.macroActionsLabel.TabIndex = 3;
            this.macroActionsLabel.Text = "Action:";
            // 
            // propertyValuePanel
            // 
            this.propertyValuePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyValuePanel.Controls.Add(this.propertyOptionsComboBox);
            this.propertyValuePanel.Controls.Add(this.propertyValueLabel);
            this.propertyValuePanel.Controls.Add(this.propertyValueTextBox);
            this.propertyValuePanel.Location = new System.Drawing.Point(2, 244);
            this.propertyValuePanel.Name = "propertyValuePanel";
            this.propertyValuePanel.Size = new System.Drawing.Size(130, 41);
            this.propertyValuePanel.TabIndex = 9;
            // 
            // propertyOptionsComboBox
            // 
            this.propertyOptionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyOptionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propertyOptionsComboBox.FormattingEnabled = true;
            this.propertyOptionsComboBox.Location = new System.Drawing.Point(3, 15);
            this.propertyOptionsComboBox.Name = "propertyOptionsComboBox";
            this.propertyOptionsComboBox.Size = new System.Drawing.Size(122, 21);
            this.propertyOptionsComboBox.TabIndex = 7;
            this.propertyOptionsComboBox.SelectionChangeCommitted += new System.EventHandler(this.propertyOptionsComboBox_SelectionChangeCommitted);
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
            this.propertyValueTextBox.Size = new System.Drawing.Size(122, 20);
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
            // macroNameTextBox
            // 
            this.macroNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroNameTextBox.Location = new System.Drawing.Point(3, 16);
            this.macroNameTextBox.Name = "macroNameTextBox";
            this.macroNameTextBox.Size = new System.Drawing.Size(129, 20);
            this.macroNameTextBox.TabIndex = 5;
            this.macroNameTextBox.TextChanged += new System.EventHandler(this.macroNameTextBox_TextChanged);
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
            this.macroPropertiesListBox.Size = new System.Drawing.Size(150, 312);
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
            this.addToListButton.Location = new System.Drawing.Point(220, 338);
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
            this.newButton.Location = new System.Drawing.Point(3, 340);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Location = new System.Drawing.Point(111, 346);
            this.playButton.Name = "playButton";
            this.playButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.playButton.Size = new System.Drawing.Size(23, 23);
            this.playButton.TabIndex = 25;
            this.playButton.Text = "▷";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(61, 347);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteButton.Size = new System.Drawing.Size(23, 23);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.Text = "✕";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // shiftMacroDownButton
            // 
            this.shiftMacroDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shiftMacroDownButton.Location = new System.Drawing.Point(32, 347);
            this.shiftMacroDownButton.Name = "shiftMacroDownButton";
            this.shiftMacroDownButton.Size = new System.Drawing.Size(23, 23);
            this.shiftMacroDownButton.TabIndex = 23;
            this.shiftMacroDownButton.Text = "↓";
            this.shiftMacroDownButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.shiftMacroDownButton.UseVisualStyleBackColor = true;
            this.shiftMacroDownButton.Click += new System.EventHandler(this.shiftMacroDownButton_Click);
            // 
            // shiftMacroUpButton
            // 
            this.shiftMacroUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shiftMacroUpButton.Location = new System.Drawing.Point(3, 347);
            this.shiftMacroUpButton.Name = "shiftMacroUpButton";
            this.shiftMacroUpButton.Size = new System.Drawing.Size(23, 23);
            this.shiftMacroUpButton.TabIndex = 8;
            this.shiftMacroUpButton.Text = "↑";
            this.shiftMacroUpButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.shiftMacroUpButton.UseVisualStyleBackColor = true;
            this.shiftMacroUpButton.Click += new System.EventHandler(this.shiftMacroUpButton_Click);
            // 
            // menuToolStrip
            // 
            this.menuToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripDropDownButton,
            this.editToolStripDropDownButton});
            this.menuToolStrip.Location = new System.Drawing.Point(0, 0);
            this.menuToolStrip.Name = "menuToolStrip";
            this.menuToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuToolStrip.ShowItemToolTips = false;
            this.menuToolStrip.Size = new System.Drawing.Size(478, 25);
            this.menuToolStrip.TabIndex = 25;
            this.menuToolStrip.Text = "toolStrip1";
            // 
            // fileToolStripDropDownButton
            // 
            this.fileToolStripDropDownButton.AutoSize = false;
            this.fileToolStripDropDownButton.AutoToolTip = false;
            this.fileToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripDropDownButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileToolStripDropDownButton.Name = "fileToolStripDropDownButton";
            this.fileToolStripDropDownButton.ShowDropDownArrow = false;
            this.fileToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.fileToolStripDropDownButton.Text = "File";
            this.fileToolStripDropDownButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileToolStripDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.AutoSize = false;
            this.saveToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // editToolStripDropDownButton
            // 
            this.editToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.integersDatabaseToolStripMenuItem,
            this.stringsDatabaseToolStripMenuItem});
            this.editToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripDropDownButton.Image")));
            this.editToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripDropDownButton.Name = "editToolStripDropDownButton";
            this.editToolStripDropDownButton.ShowDropDownArrow = false;
            this.editToolStripDropDownButton.Size = new System.Drawing.Size(31, 22);
            this.editToolStripDropDownButton.Text = "Edit";
            // 
            // integersDatabaseToolStripMenuItem
            // 
            this.integersDatabaseToolStripMenuItem.Name = "integersDatabaseToolStripMenuItem";
            this.integersDatabaseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.integersDatabaseToolStripMenuItem.Text = "Integers Database";
            this.integersDatabaseToolStripMenuItem.Click += new System.EventHandler(this.integersDatabaseToolStripMenuItem_Click);
            // 
            // stringsDatabaseToolStripMenuItem
            // 
            this.stringsDatabaseToolStripMenuItem.Name = "stringsDatabaseToolStripMenuItem";
            this.stringsDatabaseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.stringsDatabaseToolStripMenuItem.Text = "Strings Database";
            this.stringsDatabaseToolStripMenuItem.Click += new System.EventHandler(this.stringsDatabaseToolStripMenuItem_Click);
            // 
            // MacroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 414);
            this.Controls.Add(this.menuToolStrip);
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
            this.gotoMacroPanel.ResumeLayout(false);
            this.gotoMacroPanel.PerformLayout();
            this.startConditionPanel.ResumeLayout(false);
            this.startConditionPanel.PerformLayout();
            this.actionOptionsPanel.ResumeLayout(false);
            this.actionOptionsPanel.PerformLayout();
            this.propertyValuePanel.ResumeLayout(false);
            this.propertyValuePanel.PerformLayout();
            this.menuToolStrip.ResumeLayout(false);
            this.menuToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label propertyValueLabel;
        private System.Windows.Forms.Button shiftMacroDownButton;
        private System.Windows.Forms.Button shiftMacroUpButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel actionOptionsPanel;
        private System.Windows.Forms.Panel startConditionPanel;
        private System.Windows.Forms.CheckBox hasStartConditionCheckBox;
        private System.Windows.Forms.ComboBox startConditionFirstSourceComboBox;
        private System.Windows.Forms.TextBox startConditionSecondValueTextBox;
        private System.Windows.Forms.TextBox startConditionFirstValueTextBox;
        private System.Windows.Forms.ComboBox startConditionSecondValueComboBox;
        private System.Windows.Forms.ComboBox startConditionFirstValueComboBox;
        private System.Windows.Forms.ComboBox startConditionSecondSourceComboBox;
        private System.Windows.Forms.ComboBox startConditionOperationComboBox;
        private System.Windows.Forms.ComboBox startConditionSecondMacroIdComboBox;
        private System.Windows.Forms.ComboBox startConditionFirstMacroIdComboBox;
        private System.Windows.Forms.Panel gotoMacroPanel;
        private System.Windows.Forms.CheckBox gotoMacroCheckBox;
        private System.Windows.Forms.ComboBox gotoMacroComboBox;
        private System.Windows.Forms.Label gotoMacroLabel;
        private System.Windows.Forms.ToolStrip menuToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton fileToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton editToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem integersDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringsDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

