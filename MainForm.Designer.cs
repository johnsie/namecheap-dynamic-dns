namespace namecheap_dynamic_dns
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.statusTabPage = new System.Windows.Forms.TabPage();
            this.statusListView = new System.Windows.Forms.ListView();
            this.profileHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stopStartButton = new System.Windows.Forms.Button();
            this.profilesTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.autoDetectCheckBox = new System.Windows.Forms.CheckBox();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.updateIntervalLabel = new System.Windows.Forms.Label();
            this.updateIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.dynamicDnsPasswordLabel = new System.Windows.Forms.Label();
            this.dynamicDnsPasswordTextBox = new System.Windows.Forms.TextBox();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.domainLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.profilesComboBox = new System.Windows.Forms.ComboBox();
            this.profilesLabel = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lastActionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastActionValueStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateAllButton = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.statusTabPage.SuspendLayout();
            this.profilesTabPage.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.statusTabPage);
            this.tabControl.Controls.Add(this.profilesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 230);
            this.tabControl.TabIndex = 0;
            // 
            // statusTabPage
            // 
            this.statusTabPage.Controls.Add(this.updateAllButton);
            this.statusTabPage.Controls.Add(this.statusListView);
            this.statusTabPage.Controls.Add(this.stopStartButton);
            this.statusTabPage.Location = new System.Drawing.Point(4, 22);
            this.statusTabPage.Name = "statusTabPage";
            this.statusTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.statusTabPage.Size = new System.Drawing.Size(476, 204);
            this.statusTabPage.TabIndex = 0;
            this.statusTabPage.Text = "Status";
            this.statusTabPage.UseVisualStyleBackColor = true;
            // 
            // statusListView
            // 
            this.statusListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.profileHeader,
            this.statusHeader,
            this.dateHeader});
            this.statusListView.FullRowSelect = true;
            this.statusListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.statusListView.Location = new System.Drawing.Point(6, 6);
            this.statusListView.Name = "statusListView";
            this.statusListView.Size = new System.Drawing.Size(464, 163);
            this.statusListView.TabIndex = 1;
            this.statusListView.UseCompatibleStateImageBehavior = false;
            this.statusListView.View = System.Windows.Forms.View.Details;
            // 
            // profileHeader
            // 
            this.profileHeader.Text = "Profile";
            this.profileHeader.Width = 136;
            // 
            // statusHeader
            // 
            this.statusHeader.Text = "Status";
            this.statusHeader.Width = 205;
            // 
            // stopStartButton
            // 
            this.stopStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopStartButton.Location = new System.Drawing.Point(395, 175);
            this.stopStartButton.Name = "stopStartButton";
            this.stopStartButton.Size = new System.Drawing.Size(75, 23);
            this.stopStartButton.TabIndex = 3;
            this.stopStartButton.Tag = "Stop";
            this.stopStartButton.Text = "Stop";
            this.stopStartButton.UseVisualStyleBackColor = true;
            this.stopStartButton.Click += new System.EventHandler(this.stopStartButton_Click);
            // 
            // profilesTabPage
            // 
            this.profilesTabPage.Controls.Add(this.saveButton);
            this.profilesTabPage.Controls.Add(this.cancelButton);
            this.profilesTabPage.Controls.Add(this.deleteButton);
            this.profilesTabPage.Controls.Add(this.autoDetectCheckBox);
            this.profilesTabPage.Controls.Add(this.ipAddressLabel);
            this.profilesTabPage.Controls.Add(this.ipAddressTextBox);
            this.profilesTabPage.Controls.Add(this.updateIntervalLabel);
            this.profilesTabPage.Controls.Add(this.updateIntervalComboBox);
            this.profilesTabPage.Controls.Add(this.dynamicDnsPasswordLabel);
            this.profilesTabPage.Controls.Add(this.dynamicDnsPasswordTextBox);
            this.profilesTabPage.Controls.Add(this.domainTextBox);
            this.profilesTabPage.Controls.Add(this.hostTextBox);
            this.profilesTabPage.Controls.Add(this.domainLabel);
            this.profilesTabPage.Controls.Add(this.hostLabel);
            this.profilesTabPage.Controls.Add(this.profilesComboBox);
            this.profilesTabPage.Controls.Add(this.profilesLabel);
            this.profilesTabPage.Controls.Add(this.newButton);
            this.profilesTabPage.Location = new System.Drawing.Point(4, 22);
            this.profilesTabPage.Name = "profilesTabPage";
            this.profilesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.profilesTabPage.Size = new System.Drawing.Size(476, 204);
            this.profilesTabPage.TabIndex = 1;
            this.profilesTabPage.Text = "Profiles";
            this.profilesTabPage.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(314, 175);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(395, 175);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(6, 175);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // autoDetectCheckBox
            // 
            this.autoDetectCheckBox.AutoSize = true;
            this.autoDetectCheckBox.Enabled = false;
            this.autoDetectCheckBox.Location = new System.Drawing.Point(305, 140);
            this.autoDetectCheckBox.Name = "autoDetectCheckBox";
            this.autoDetectCheckBox.Size = new System.Drawing.Size(165, 17);
            this.autoDetectCheckBox.TabIndex = 8;
            this.autoDetectCheckBox.Text = "Auto-detect public IP address";
            this.autoDetectCheckBox.UseVisualStyleBackColor = true;
            this.autoDetectCheckBox.CheckedChanged += new System.EventHandler(this.autoDetectCheckBox_CheckedChanged);
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(3, 122);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(57, 13);
            this.ipAddressLabel.TabIndex = 0;
            this.ipAddressLabel.Text = "IP address";
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Enabled = false;
            this.ipAddressTextBox.Location = new System.Drawing.Point(6, 138);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(293, 20);
            this.ipAddressTextBox.TabIndex = 7;
            // 
            // updateIntervalLabel
            // 
            this.updateIntervalLabel.AutoSize = true;
            this.updateIntervalLabel.Location = new System.Drawing.Point(353, 82);
            this.updateIntervalLabel.Name = "updateIntervalLabel";
            this.updateIntervalLabel.Size = new System.Drawing.Size(79, 13);
            this.updateIntervalLabel.TabIndex = 0;
            this.updateIntervalLabel.Text = "Update interval";
            // 
            // updateIntervalComboBox
            // 
            this.updateIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateIntervalComboBox.Enabled = false;
            this.updateIntervalComboBox.FormattingEnabled = true;
            this.updateIntervalComboBox.Items.AddRange(new object[] {
            "15 minutes",
            "30 minutes",
            "1 hour",
            "3 hours",
            "6 hours",
            "24 hours"});
            this.updateIntervalComboBox.Location = new System.Drawing.Point(356, 98);
            this.updateIntervalComboBox.Name = "updateIntervalComboBox";
            this.updateIntervalComboBox.Size = new System.Drawing.Size(114, 21);
            this.updateIntervalComboBox.TabIndex = 6;
            // 
            // dynamicDnsPasswordLabel
            // 
            this.dynamicDnsPasswordLabel.AutoSize = true;
            this.dynamicDnsPasswordLabel.Location = new System.Drawing.Point(3, 83);
            this.dynamicDnsPasswordLabel.Name = "dynamicDnsPasswordLabel";
            this.dynamicDnsPasswordLabel.Size = new System.Drawing.Size(122, 13);
            this.dynamicDnsPasswordLabel.TabIndex = 0;
            this.dynamicDnsPasswordLabel.Text = "Dynamic DNS password";
            // 
            // dynamicDnsPasswordTextBox
            // 
            this.dynamicDnsPasswordTextBox.Enabled = false;
            this.dynamicDnsPasswordTextBox.Location = new System.Drawing.Point(6, 99);
            this.dynamicDnsPasswordTextBox.Name = "dynamicDnsPasswordTextBox";
            this.dynamicDnsPasswordTextBox.Size = new System.Drawing.Size(344, 20);
            this.dynamicDnsPasswordTextBox.TabIndex = 5;
            // 
            // domainTextBox
            // 
            this.domainTextBox.Enabled = false;
            this.domainTextBox.Location = new System.Drawing.Point(241, 59);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(229, 20);
            this.domainTextBox.TabIndex = 4;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Enabled = false;
            this.hostTextBox.Location = new System.Drawing.Point(6, 59);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(229, 20);
            this.hostTextBox.TabIndex = 3;
            // 
            // domainLabel
            // 
            this.domainLabel.AutoSize = true;
            this.domainLabel.Location = new System.Drawing.Point(238, 43);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new System.Drawing.Size(43, 13);
            this.domainLabel.TabIndex = 0;
            this.domainLabel.Text = "Domain";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(3, 43);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(29, 13);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host";
            // 
            // profilesComboBox
            // 
            this.profilesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profilesComboBox.FormattingEnabled = true;
            this.profilesComboBox.Location = new System.Drawing.Point(6, 19);
            this.profilesComboBox.Name = "profilesComboBox";
            this.profilesComboBox.Size = new System.Drawing.Size(383, 21);
            this.profilesComboBox.TabIndex = 1;
            this.profilesComboBox.SelectedIndexChanged += new System.EventHandler(this.profilesComboBox_SelectedIndexChanged);
            // 
            // profilesLabel
            // 
            this.profilesLabel.AutoSize = true;
            this.profilesLabel.Location = new System.Drawing.Point(3, 3);
            this.profilesLabel.Name = "profilesLabel";
            this.profilesLabel.Size = new System.Drawing.Size(41, 13);
            this.profilesLabel.TabIndex = 0;
            this.profilesLabel.Text = "Profiles";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(395, 18);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(484, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastActionStatusLabel,
            this.lastActionValueStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 254);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lastActionStatusLabel
            // 
            this.lastActionStatusLabel.Name = "lastActionStatusLabel";
            this.lastActionStatusLabel.Size = new System.Drawing.Size(67, 17);
            this.lastActionStatusLabel.Text = "Last action:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "namecheap-dynamic-dns";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 900000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 119;
            // 
            // lastActionValueStatusLabel
            // 
            this.lastActionValueStatusLabel.Name = "lastActionValueStatusLabel";
            this.lastActionValueStatusLabel.Size = new System.Drawing.Size(34, 17);
            this.lastActionValueStatusLabel.Text = "none";
            // 
            // updateAllButton
            // 
            this.updateAllButton.Location = new System.Drawing.Point(6, 175);
            this.updateAllButton.Name = "updateAllButton";
            this.updateAllButton.Size = new System.Drawing.Size(75, 23);
            this.updateAllButton.TabIndex = 4;
            this.updateAllButton.Text = "Update All";
            this.updateAllButton.UseVisualStyleBackColor = true;
            this.updateAllButton.Click += new System.EventHandler(this.updateAllButton_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAllToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(130, 48);
            // 
            // updateAllToolStripMenuItem
            // 
            this.updateAllToolStripMenuItem.Name = "updateAllToolStripMenuItem";
            this.updateAllToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.updateAllToolStripMenuItem.Text = "Update All";
            this.updateAllToolStripMenuItem.Click += new System.EventHandler(this.updateAllButton_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 276);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "namecheap-dynamic-dns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl.ResumeLayout(false);
            this.statusTabPage.ResumeLayout(false);
            this.profilesTabPage.ResumeLayout(false);
            this.profilesTabPage.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage statusTabPage;
        private System.Windows.Forms.TabPage profilesTabPage;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lastActionStatusLabel;
        private System.Windows.Forms.ListView statusListView;
        private System.Windows.Forms.Button stopStartButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox autoDetectCheckBox;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.Label updateIntervalLabel;
        private System.Windows.Forms.ComboBox updateIntervalComboBox;
        private System.Windows.Forms.Label dynamicDnsPasswordLabel;
        private System.Windows.Forms.TextBox dynamicDnsPasswordTextBox;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label domainLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.ComboBox profilesComboBox;
        private System.Windows.Forms.Label profilesLabel;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ColumnHeader profileHeader;
        private System.Windows.Forms.ColumnHeader statusHeader;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ToolStripStatusLabel lastActionValueStatusLabel;
        private System.Windows.Forms.Button updateAllButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem updateAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

