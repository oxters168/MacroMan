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
            this.macroTypeLabel = new System.Windows.Forms.Label();
            this.macroDataSplitContainer = new System.Windows.Forms.SplitContainer();
            this.gotoMacroPanel = new System.Windows.Forms.Panel();
            this.gotoMacroCheckBox = new System.Windows.Forms.CheckBox();
            this.gotoMacroComboBox = new System.Windows.Forms.ComboBox();
            this.gotoMacroLabel = new System.Windows.Forms.Label();
            this.startConditionPanel = new System.Windows.Forms.Panel();
            this.startConditionSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.startConditionSecondSourceComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionSecondMacroIdComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.startConditionFirstSourceComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionFirstMacroIdComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionOperationComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionSecondValueTextBox = new System.Windows.Forms.TextBox();
            this.startConditionFirstValueTextBox = new System.Windows.Forms.TextBox();
            this.startConditionSecondValueComboBox = new System.Windows.Forms.ComboBox();
            this.startConditionFirstValueComboBox = new System.Windows.Forms.ComboBox();
            this.hasStartConditionCheckBox = new System.Windows.Forms.CheckBox();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integersDatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stringsDatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.startConditionSplitContainer2)).BeginInit();
            this.startConditionSplitContainer2.Panel1.SuspendLayout();
            this.startConditionSplitContainer2.Panel2.SuspendLayout();
            this.startConditionSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startConditionSplitContainer1)).BeginInit();
            this.startConditionSplitContainer1.Panel1.SuspendLayout();
            this.startConditionSplitContainer1.Panel2.SuspendLayout();
            this.startConditionSplitContainer1.SuspendLayout();
            this.actionOptionsPanel.SuspendLayout();
            this.propertyValuePanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.macrosListBox.Size = new System.Drawing.Size(131, 360);
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
            this.macrosComboBox.Location = new System.Drawing.Point(3, 362);
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
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
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
            this.splitContainer1.Size = new System.Drawing.Size(454, 398);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 24;
            // 
            // macroEditorPanel
            // 
            this.macroEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroEditorPanel.Controls.Add(this.macroTypeLabel);
            this.macroEditorPanel.Controls.Add(this.macroDataSplitContainer);
            this.macroEditorPanel.Controls.Add(this.addToListButton);
            this.macroEditorPanel.Controls.Add(this.newButton);
            this.macroEditorPanel.Controls.Add(this.macrosComboBox);
            this.macroEditorPanel.Location = new System.Drawing.Point(3, 3);
            this.macroEditorPanel.Name = "macroEditorPanel";
            this.macroEditorPanel.Size = new System.Drawing.Size(299, 388);
            this.macroEditorPanel.TabIndex = 23;
            // 
            // macroTypeLabel
            // 
            this.macroTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroTypeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.macroTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macroTypeLabel.Location = new System.Drawing.Point(0, 0);
            this.macroTypeLabel.Name = "macroTypeLabel";
            this.macroTypeLabel.Size = new System.Drawing.Size(299, 19);
            this.macroTypeLabel.TabIndex = 3;
            this.macroTypeLabel.Text = "Macro Type";
            this.macroTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // macroDataSplitContainer
            // 
            this.macroDataSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroDataSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.macroDataSplitContainer.Location = new System.Drawing.Point(0, 20);
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
            this.macroDataSplitContainer.Size = new System.Drawing.Size(299, 336);
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
            this.gotoMacroPanel.Location = new System.Drawing.Point(2, 289);
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
            this.startConditionPanel.Controls.Add(this.startConditionSplitContainer2);
            this.startConditionPanel.Controls.Add(this.startConditionSplitContainer1);
            this.startConditionPanel.Controls.Add(this.startConditionOperationComboBox);
            this.startConditionPanel.Controls.Add(this.startConditionSecondValueTextBox);
            this.startConditionPanel.Controls.Add(this.startConditionFirstValueTextBox);
            this.startConditionPanel.Controls.Add(this.startConditionSecondValueComboBox);
            this.startConditionPanel.Controls.Add(this.startConditionFirstValueComboBox);
            this.startConditionPanel.Controls.Add(this.hasStartConditionCheckBox);
            this.startConditionPanel.Location = new System.Drawing.Point(2, 42);
            this.startConditionPanel.Name = "startConditionPanel";
            this.startConditionPanel.Size = new System.Drawing.Size(130, 160);
            this.startConditionPanel.TabIndex = 12;
            // 
            // startConditionSplitContainer2
            // 
            this.startConditionSplitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionSplitContainer2.Location = new System.Drawing.Point(3, 106);
            this.startConditionSplitContainer2.Name = "startConditionSplitContainer2";
            // 
            // startConditionSplitContainer2.Panel1
            // 
            this.startConditionSplitContainer2.Panel1.Controls.Add(this.startConditionSecondSourceComboBox);
            // 
            // startConditionSplitContainer2.Panel2
            // 
            this.startConditionSplitContainer2.Panel2.Controls.Add(this.startConditionSecondMacroIdComboBox);
            this.startConditionSplitContainer2.Size = new System.Drawing.Size(122, 21);
            this.startConditionSplitContainer2.SplitterDistance = 58;
            this.startConditionSplitContainer2.TabIndex = 3;
            // 
            // startConditionSecondSourceComboBox
            // 
            this.startConditionSecondSourceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionSecondSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionSecondSourceComboBox.FormattingEnabled = true;
            this.startConditionSecondSourceComboBox.Location = new System.Drawing.Point(0, 0);
            this.startConditionSecondSourceComboBox.Name = "startConditionSecondSourceComboBox";
            this.startConditionSecondSourceComboBox.Size = new System.Drawing.Size(58, 21);
            this.startConditionSecondSourceComboBox.TabIndex = 14;
            this.startConditionSecondSourceComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionSecondSourceComboBox_SelectionChangeCommitted);
            // 
            // startConditionSecondMacroIdComboBox
            // 
            this.startConditionSecondMacroIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionSecondMacroIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionSecondMacroIdComboBox.FormattingEnabled = true;
            this.startConditionSecondMacroIdComboBox.Location = new System.Drawing.Point(2, 0);
            this.startConditionSecondMacroIdComboBox.Name = "startConditionSecondMacroIdComboBox";
            this.startConditionSecondMacroIdComboBox.Size = new System.Drawing.Size(58, 21);
            this.startConditionSecondMacroIdComboBox.TabIndex = 17;
            this.startConditionSecondMacroIdComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionSecondMacroIdComboBox_SelectionChangeCommitted);
            // 
            // startConditionSplitContainer1
            // 
            this.startConditionSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionSplitContainer1.Location = new System.Drawing.Point(3, 26);
            this.startConditionSplitContainer1.Name = "startConditionSplitContainer1";
            // 
            // startConditionSplitContainer1.Panel1
            // 
            this.startConditionSplitContainer1.Panel1.Controls.Add(this.startConditionFirstSourceComboBox);
            // 
            // startConditionSplitContainer1.Panel2
            // 
            this.startConditionSplitContainer1.Panel2.Controls.Add(this.startConditionFirstMacroIdComboBox);
            this.startConditionSplitContainer1.Size = new System.Drawing.Size(122, 21);
            this.startConditionSplitContainer1.SplitterDistance = 59;
            this.startConditionSplitContainer1.TabIndex = 3;
            // 
            // startConditionFirstSourceComboBox
            // 
            this.startConditionFirstSourceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionFirstSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionFirstSourceComboBox.FormattingEnabled = true;
            this.startConditionFirstSourceComboBox.Location = new System.Drawing.Point(0, 0);
            this.startConditionFirstSourceComboBox.Name = "startConditionFirstSourceComboBox";
            this.startConditionFirstSourceComboBox.Size = new System.Drawing.Size(58, 21);
            this.startConditionFirstSourceComboBox.TabIndex = 0;
            this.startConditionFirstSourceComboBox.SelectionChangeCommitted += new System.EventHandler(this.startConditionFirstSourceComboBox_SelectionChangeCommitted);
            // 
            // startConditionFirstMacroIdComboBox
            // 
            this.startConditionFirstMacroIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startConditionFirstMacroIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startConditionFirstMacroIdComboBox.FormattingEnabled = true;
            this.startConditionFirstMacroIdComboBox.Location = new System.Drawing.Point(1, 0);
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
            // actionOptionsPanel
            // 
            this.actionOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actionOptionsPanel.Controls.Add(this.macroActionComboBox);
            this.actionOptionsPanel.Controls.Add(this.macroActionsLabel);
            this.actionOptionsPanel.Location = new System.Drawing.Point(2, 203);
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
            this.propertyValuePanel.Location = new System.Drawing.Point(2, 246);
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
            this.macroPropertiesListBox.Size = new System.Drawing.Size(150, 314);
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
            this.addToListButton.Location = new System.Drawing.Point(220, 360);
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
            this.newButton.Location = new System.Drawing.Point(3, 362);
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
            this.playButton.Location = new System.Drawing.Point(111, 368);
            this.playButton.Name = "playButton";
            this.playButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.playButton.Size = new System.Drawing.Size(23, 23);
            this.playButton.TabIndex = 25;
            this.playButton.Text = "➤";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(61, 369);
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
            this.shiftMacroDownButton.Location = new System.Drawing.Point(32, 369);
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
            this.shiftMacroUpButton.Location = new System.Drawing.Point(3, 369);
            this.shiftMacroUpButton.Name = "shiftMacroUpButton";
            this.shiftMacroUpButton.Size = new System.Drawing.Size(23, 23);
            this.shiftMacroUpButton.TabIndex = 8;
            this.shiftMacroUpButton.Text = "↑";
            this.shiftMacroUpButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.shiftMacroUpButton.UseVisualStyleBackColor = true;
            this.shiftMacroUpButton.Click += new System.EventHandler(this.shiftMacroUpButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(478, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.saveAsToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem1.Text = "Save As";
            this.saveAsToolStripMenuItem1.Click += new System.EventHandler(this.saveAsToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.integersDatabaseToolStripMenuItem1,
            this.stringsDatabaseToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // integersDatabaseToolStripMenuItem1
            // 
            this.integersDatabaseToolStripMenuItem1.Name = "integersDatabaseToolStripMenuItem1";
            this.integersDatabaseToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.integersDatabaseToolStripMenuItem1.Text = "Integers Database";
            this.integersDatabaseToolStripMenuItem1.Click += new System.EventHandler(this.integersDatabaseToolStripMenuItem1_Click);
            // 
            // stringsDatabaseToolStripMenuItem1
            // 
            this.stringsDatabaseToolStripMenuItem1.Name = "stringsDatabaseToolStripMenuItem1";
            this.stringsDatabaseToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.stringsDatabaseToolStripMenuItem1.Text = "Strings Database";
            this.stringsDatabaseToolStripMenuItem1.Click += new System.EventHandler(this.stringsDatabaseToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem1,
            this.aboutToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem1
            // 
            this.preferencesToolStripMenuItem1.Name = "preferencesToolStripMenuItem1";
            this.preferencesToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem1.Text = "Preferences";
            this.preferencesToolStripMenuItem1.Click += new System.EventHandler(this.preferencesToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // MacroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 435);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
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
            this.startConditionSplitContainer2.Panel1.ResumeLayout(false);
            this.startConditionSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startConditionSplitContainer2)).EndInit();
            this.startConditionSplitContainer2.ResumeLayout(false);
            this.startConditionSplitContainer1.Panel1.ResumeLayout(false);
            this.startConditionSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startConditionSplitContainer1)).EndInit();
            this.startConditionSplitContainer1.ResumeLayout(false);
            this.actionOptionsPanel.ResumeLayout(false);
            this.actionOptionsPanel.PerformLayout();
            this.propertyValuePanel.ResumeLayout(false);
            this.propertyValuePanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label macroTypeLabel;
        private System.Windows.Forms.SplitContainer startConditionSplitContainer2;
        private System.Windows.Forms.SplitContainer startConditionSplitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integersDatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stringsDatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

