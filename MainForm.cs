using namecheap_dynamic_dns.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace namecheap_dynamic_dns
{
    public partial class MainForm : Form
    {
        private List<Profile> profiles;
        private ModeEnum mode;

        private enum ModeEnum
        {
            NONE,
            NEW,
            EDIT
        }

        private void ChangeMode(ModeEnum mode)
        {
            this.mode = mode;

            switch (mode)
            {
                case ModeEnum.NONE:
                    profilesComboBox.SelectedIndex = -1;
                    hostTextBox.Enabled = false;
                    hostTextBox.Text = "";
                    domainTextBox.Enabled = false;
                    domainTextBox.Text = "";
                    dynamicDnsPasswordTextBox.Enabled = false;
                    dynamicDnsPasswordTextBox.Text = "";
                    updateIntervalComboBox.Enabled = false;
                    updateIntervalComboBox.SelectedIndex = -1;
                    ipAddressTextBox.Enabled = false;
                    ipAddressTextBox.Text = "";
                    autoDetectCheckBox.Enabled = false;
                    autoDetectCheckBox.Checked = false;
                    deleteButton.Enabled = false;
                    saveButton.Enabled = false;
                    cancelButton.Enabled = false;
                    break;
                case ModeEnum.NEW:
                    profilesComboBox.SelectedIndex = -1;
                    hostTextBox.Enabled = true;
                    hostTextBox.Text = "";
                    domainTextBox.Enabled = true;
                    domainTextBox.Text = "";
                    dynamicDnsPasswordTextBox.Enabled = true;
                    dynamicDnsPasswordTextBox.Text = "";
                    updateIntervalComboBox.Enabled = true;
                    updateIntervalComboBox.SelectedIndex = 0;
                    ipAddressTextBox.Enabled = true;
                    ipAddressTextBox.Text = "";
                    autoDetectCheckBox.Enabled = true;
                    autoDetectCheckBox.Checked = false;
                    deleteButton.Enabled = true;
                    saveButton.Enabled = true;
                    cancelButton.Enabled = true;
                    break;
                case ModeEnum.EDIT:
                    hostTextBox.Enabled = true;
                    hostTextBox.Text = profiles[profilesComboBox.SelectedIndex].Host;
                    domainTextBox.Enabled = true;
                    domainTextBox.Text = profiles[profilesComboBox.SelectedIndex].Domain;
                    dynamicDnsPasswordTextBox.Enabled = true;
                    dynamicDnsPasswordTextBox.Text = profiles[profilesComboBox.SelectedIndex].DynamicDnsPassword;
                    updateIntervalComboBox.Enabled = true;
                    updateIntervalComboBox.SelectedIndex = (int)profiles[profilesComboBox.SelectedIndex].UpdateInterval;
                    ipAddressTextBox.Enabled = !profiles[profilesComboBox.SelectedIndex].AutoDetectIpAddress;
                    ipAddressTextBox.Text = profiles[profilesComboBox.SelectedIndex].IpAddress;
                    autoDetectCheckBox.Enabled = true;
                    autoDetectCheckBox.Checked = profiles[profilesComboBox.SelectedIndex].AutoDetectIpAddress;
                    if (autoDetectCheckBox.Checked)
                    {
                        ipAddressTextBox.Text = "";
                    }
                    deleteButton.Enabled = true;
                    saveButton.Enabled = true;
                    cancelButton.Enabled = true;
                    break;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            profiles = new List<Profile>();
            this.ChangeMode(ModeEnum.NONE);

            if (Settings.Default.Profiles != null)
            {
                var xmlSerializer = new XmlSerializer(typeof(Profile));
                foreach (string profileString in Settings.Default.Profiles)
                {
                    var profileStream = new MemoryStream(Encoding.UTF8.GetBytes(profileString));
                    var profile = xmlSerializer.Deserialize(profileStream);
                    AddProfile(profile as Profile);
                    PerformDynamicDnsUpdate(profile as Profile);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var collection = new StringCollection();
            var xmlSerializer = new XmlSerializer(typeof(Profile));
            foreach (Profile profile in profiles)
            {
                var profileStream = new MemoryStream();
                xmlSerializer.Serialize(profileStream, profile);
                var profileString = Encoding.UTF8.GetString(profileStream.ToArray());
                collection.Add(profileString);
            }

            Settings.Default.Profiles = collection;
            Settings.Default.Save();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ChangeMode(ModeEnum.NEW);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            profiles.RemoveAt(profilesComboBox.SelectedIndex);
            ChangeMode(ModeEnum.NONE);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Profile profile;
            if (mode == ModeEnum.NEW)
            {
                profile = new Profile();
            }
            else if (mode == ModeEnum.EDIT)
            {
                profile = profiles[profilesComboBox.SelectedIndex];
            }
            else
            {
                return;
            }

            profile.Host = hostTextBox.Text;
            profile.Domain = domainTextBox.Text;
            profile.DynamicDnsPassword = dynamicDnsPasswordTextBox.Text;
            profile.UpdateInterval = (UpdateIntervalEnum)updateIntervalComboBox.SelectedIndex;
            profile.IpAddress = ipAddressTextBox.Text;
            profile.AutoDetectIpAddress = autoDetectCheckBox.Checked;

            if (profile.Host == "" || profile.Domain == "" || profile.DynamicDnsPassword == "" 
                || updateIntervalComboBox.SelectedIndex == -1 
                || (profile.IpAddress == "" && !profile.AutoDetectIpAddress))
            {
                MessageBox.Show("Data validation failed.", "namecheap-dynamic-dns");
                return;
            }

            if (mode == ModeEnum.NEW)
            {
                AddProfile(profile);
            }
            else if (mode == ModeEnum.EDIT)
            {
                profile = profiles[profilesComboBox.SelectedIndex];
            }
            ChangeMode(ModeEnum.NONE);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ChangeMode(ModeEnum.NONE);
        }

        private void ProfilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profilesComboBox.SelectedIndex != -1)
            {
                ChangeMode(ModeEnum.EDIT);
            }
        }

        private void AutoDetectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ipAddressTextBox.Enabled = !autoDetectCheckBox.Checked;
            if (autoDetectCheckBox.Checked)
            {
                ipAddressTextBox.Text = "";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var profile in profiles)
            {
                if (profile.LastSyncTime > DateTime.Now - Profile.GetTimeSpanForUpdateInterval(profile.UpdateInterval))
                {
                    PerformDynamicDnsUpdate(profile);
                }
            }
        }

        private void StopStartButton_Click(object sender, EventArgs e)
        {
            if (stopStartButton.Tag as String == "Stop")
            {
                timer.Enabled = false;
                stopStartButton.Text = "Start";
                stopStartButton.Tag = "Start";
            }
            else if (stopStartButton.Tag as String == "Start")
            {
                timer.Enabled = true;
                stopStartButton.Text = "Stop";
                stopStartButton.Tag = "Stop";
            }
            else
            {
                throw new Exception();
            }
        }

        private void AddProfile(Profile profile)
        {
            var profileStatusItem = new ListViewItem(profile.Label);
            profileStatusItem.SubItems.Add(new ListViewItem.ListViewSubItem(profileStatusItem, ""));
            profileStatusItem.SubItems.Add(new ListViewItem.ListViewSubItem(profileStatusItem, ""));

            profiles.Add(profile);
            profilesComboBox.Items.Add(profile.Label);
            statusListView.Items.Add(profileStatusItem);
        }

        private void PerformDynamicDnsUpdate(Profile profile)
        {
            var message = DynamicDns.PerformDynamicDnsUpdate(profile);
            profile.LastSyncTime = DateTime.Now;

            var date = profile.LastSyncTime.ToShortDateString() + " " + profile.LastSyncTime.ToShortTimeString();

            var profileStatusItem = statusListView.Items[profiles.IndexOf(profile)];
            profileStatusItem.SubItems[1].Text = message;
            profileStatusItem.SubItems[2].Text = date;

            lastActionValueStatusLabel.Text = date;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void UpdateAllButton_Click(object sender, EventArgs e)
        {
            foreach (var profile in profiles)
            {
                PerformDynamicDnsUpdate(profile);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
