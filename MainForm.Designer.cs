namespace Kourlas.NamecheapDynamicDns
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
            this.updateButton = new System.Windows.Forms.Button();
            this.updateAllButton = new System.Windows.Forms.Button();
            this.statusListView = new System.Windows.Forms.ListView();
            this.profileHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lastActionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastActionValueStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.statusTabPage.SuspendLayout();
            this.profilesTabPage.SuspendLayout();
            this.aboutTabPage.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.statusTabPage);
            this.tabControl.Controls.Add(this.profilesTabPage);
            this.tabControl.Controls.Add(this.aboutTabPage);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(656, 336);
            this.tabControl.TabIndex = 0;
            // 
            // statusTabPage
            // 
            this.statusTabPage.Controls.Add(this.updateButton);
            this.statusTabPage.Controls.Add(this.updateAllButton);
            this.statusTabPage.Controls.Add(this.statusListView);
            this.statusTabPage.Location = new System.Drawing.Point(4, 25);
            this.statusTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.statusTabPage.Name = "statusTabPage";
            this.statusTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.statusTabPage.Size = new System.Drawing.Size(648, 282);
            this.statusTabPage.TabIndex = 0;
            this.statusTabPage.Text = "Status";
            this.statusTabPage.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Location = new System.Drawing.Point(432, 246);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 28);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.OnUpdateButtonClick);
            // 
            // updateAllButton
            // 
            this.updateAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateAllButton.Location = new System.Drawing.Point(540, 246);
            this.updateAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateAllButton.Name = "updateAllButton";
            this.updateAllButton.Size = new System.Drawing.Size(100, 28);
            this.updateAllButton.TabIndex = 3;
            this.updateAllButton.Text = "Update All";
            this.updateAllButton.UseVisualStyleBackColor = true;
            this.updateAllButton.Click += new System.EventHandler(this.OnUpdateAllButtonClick);
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
            this.statusListView.Location = new System.Drawing.Point(9, 8);
            this.statusListView.Margin = new System.Windows.Forms.Padding(4);
            this.statusListView.Name = "statusListView";
            this.statusListView.Size = new System.Drawing.Size(631, 230);
            this.statusListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.statusListView.TabIndex = 1;
            this.statusListView.UseCompatibleStateImageBehavior = false;
            this.statusListView.View = System.Windows.Forms.View.Details;
            this.statusListView.SelectedIndexChanged += new System.EventHandler(this.StatusListViewSelectedIndexChanged);
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
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 119;
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
            this.profilesTabPage.Location = new System.Drawing.Point(4, 25);
            this.profilesTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.profilesTabPage.Name = "profilesTabPage";
            this.profilesTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.profilesTabPage.Size = new System.Drawing.Size(648, 307);
            this.profilesTabPage.TabIndex = 1;
            this.profilesTabPage.Text = "Profiles";
            this.profilesTabPage.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(432, 271);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(540, 271);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(116, 271);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 28);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
            // 
            // autoDetectCheckBox
            // 
            this.autoDetectCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.autoDetectCheckBox.AutoSize = true;
            this.autoDetectCheckBox.Enabled = false;
            this.autoDetectCheckBox.Location = new System.Drawing.Point(422, 217);
            this.autoDetectCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.autoDetectCheckBox.Name = "autoDetectCheckBox";
            this.autoDetectCheckBox.Size = new System.Drawing.Size(215, 21);
            this.autoDetectCheckBox.TabIndex = 8;
            this.autoDetectCheckBox.Text = "Auto-detect public IP address";
            this.autoDetectCheckBox.UseVisualStyleBackColor = true;
            this.autoDetectCheckBox.CheckedChanged += new System.EventHandler(this.AutoDetectCheckBox_CheckedChanged);
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(5, 194);
            this.ipAddressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(75, 17);
            this.ipAddressLabel.TabIndex = 0;
            this.ipAddressLabel.Text = "IP address";
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipAddressTextBox.Enabled = false;
            this.ipAddressTextBox.Location = new System.Drawing.Point(8, 215);
            this.ipAddressTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(407, 22);
            this.ipAddressTextBox.TabIndex = 7;
            // 
            // updateIntervalLabel
            // 
            this.updateIntervalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.updateIntervalLabel.AutoSize = true;
            this.updateIntervalLabel.Location = new System.Drawing.Point(419, 147);
            this.updateIntervalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.updateIntervalLabel.Name = "updateIntervalLabel";
            this.updateIntervalLabel.Size = new System.Drawing.Size(104, 17);
            this.updateIntervalLabel.TabIndex = 0;
            this.updateIntervalLabel.Text = "Update interval";
            // 
            // updateIntervalComboBox
            // 
            this.updateIntervalComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.updateIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateIntervalComboBox.Enabled = false;
            this.updateIntervalComboBox.FormattingEnabled = true;
            this.updateIntervalComboBox.Items.AddRange(new object[] {
            "1 minute",
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour",
            "3 hours",
            "6 hours",
            "12 hours",
            "24 hours"});
            this.updateIntervalComboBox.Location = new System.Drawing.Point(422, 168);
            this.updateIntervalComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.updateIntervalComboBox.Name = "updateIntervalComboBox";
            this.updateIntervalComboBox.Size = new System.Drawing.Size(218, 24);
            this.updateIntervalComboBox.TabIndex = 6;
            // 
            // dynamicDnsPasswordLabel
            // 
            this.dynamicDnsPasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dynamicDnsPasswordLabel.AutoSize = true;
            this.dynamicDnsPasswordLabel.Location = new System.Drawing.Point(5, 147);
            this.dynamicDnsPasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dynamicDnsPasswordLabel.Name = "dynamicDnsPasswordLabel";
            this.dynamicDnsPasswordLabel.Size = new System.Drawing.Size(159, 17);
            this.dynamicDnsPasswordLabel.TabIndex = 0;
            this.dynamicDnsPasswordLabel.Text = "Dynamic DNS password";
            // 
            // dynamicDnsPasswordTextBox
            // 
            this.dynamicDnsPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dynamicDnsPasswordTextBox.Enabled = false;
            this.dynamicDnsPasswordTextBox.Location = new System.Drawing.Point(8, 168);
            this.dynamicDnsPasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.dynamicDnsPasswordTextBox.Name = "dynamicDnsPasswordTextBox";
            this.dynamicDnsPasswordTextBox.Size = new System.Drawing.Size(406, 22);
            this.dynamicDnsPasswordTextBox.TabIndex = 5;
            // 
            // domainTextBox
            // 
            this.domainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.domainTextBox.Enabled = false;
            this.domainTextBox.Location = new System.Drawing.Point(8, 121);
            this.domainTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(632, 22);
            this.domainTextBox.TabIndex = 4;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hostTextBox.Enabled = false;
            this.hostTextBox.Location = new System.Drawing.Point(8, 74);
            this.hostTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(632, 22);
            this.hostTextBox.TabIndex = 3;
            // 
            // domainLabel
            // 
            this.domainLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.domainLabel.AutoSize = true;
            this.domainLabel.Location = new System.Drawing.Point(5, 100);
            this.domainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new System.Drawing.Size(56, 17);
            this.domainLabel.TabIndex = 0;
            this.domainLabel.Text = "Domain";
            // 
            // hostLabel
            // 
            this.hostLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(4, 53);
            this.hostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(37, 17);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host";
            // 
            // profilesComboBox
            // 
            this.profilesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.profilesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profilesComboBox.FormattingEnabled = true;
            this.profilesComboBox.Location = new System.Drawing.Point(8, 25);
            this.profilesComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.profilesComboBox.Name = "profilesComboBox";
            this.profilesComboBox.Size = new System.Drawing.Size(632, 24);
            this.profilesComboBox.Sorted = true;
            this.profilesComboBox.TabIndex = 1;
            this.profilesComboBox.SelectedIndexChanged += new System.EventHandler(this.ProfilesComboBox_SelectedIndexChanged);
            // 
            // profilesLabel
            // 
            this.profilesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.profilesLabel.AutoSize = true;
            this.profilesLabel.Location = new System.Drawing.Point(4, 4);
            this.profilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.profilesLabel.Name = "profilesLabel";
            this.profilesLabel.Size = new System.Drawing.Size(55, 17);
            this.profilesLabel.TabIndex = 0;
            this.profilesLabel.Text = "Profiles";
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newButton.Location = new System.Drawing.Point(8, 271);
            this.newButton.Margin = new System.Windows.Forms.Padding(4);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(100, 28);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.OnNewButtonClick);
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.tableLayoutPanel);
            this.aboutTabPage.Location = new System.Drawing.Point(4, 25);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTabPage.Size = new System.Drawing.Size(648, 307);
            this.aboutTabPage.TabIndex = 2;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(634, 293);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(8, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(622, 21);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(8, 32);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(622, 21);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(8, 64);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(622, 21);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Location = new System.Drawing.Point(8, 96);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(622, 21);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(8, 132);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(622, 157);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastActionStatusLabel,
            this.lastActionValueStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 353);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(682, 25);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lastActionStatusLabel
            // 
            this.lastActionStatusLabel.Name = "lastActionStatusLabel";
            this.lastActionStatusLabel.Size = new System.Drawing.Size(83, 20);
            this.lastActionStatusLabel.Text = "Last action:";
            // 
            // lastActionValueStatusLabel
            // 
            this.lastActionValueStatusLabel.Name = "lastActionValueStatusLabel";
            this.lastActionValueStatusLabel.Size = new System.Drawing.Size(42, 20);
            this.lastActionValueStatusLabel.Text = "none";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "namecheap-dynamic-dns";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAllToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(150, 52);
            // 
            // updateAllToolStripMenuItem
            // 
            this.updateAllToolStripMenuItem.Name = "updateAllToolStripMenuItem";
            this.updateAllToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.updateAllToolStripMenuItem.Text = "Update All";
            this.updateAllToolStripMenuItem.Click += new System.EventHandler(this.OnUpdateAllButtonClick);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(149, 24);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 378);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "namecheap-dynamic-dns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl.ResumeLayout(false);
            this.statusTabPage.ResumeLayout(false);
            this.profilesTabPage.ResumeLayout(false);
            this.profilesTabPage.PerformLayout();
            this.aboutTabPage.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lastActionStatusLabel;
        private System.Windows.Forms.ListView statusListView;
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
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ToolStripStatusLabel lastActionValueStatusLabel;
        private System.Windows.Forms.Button updateAllButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem updateAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
    }
}

