//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Michael Kourlas">
//   namecheap-dynamic-dns
//   Copyright (C) 2017 Michael Kourlas
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Kourlas.NamecheapDynamicDns
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Kourlas.NamecheapDynamicDns.Properties;

    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The dynamic DNS profiles used by the application.
        /// </summary>
        private List<Profile> profiles;

        /// <summary>
        /// The update interval timers for each of the profiles.
        /// </summary>
        private List<Timer> timers;

        /// <summary>
        /// The current mode that the Profiles tab is in.
        /// </summary>
        private ModeEnum mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.profiles = new List<Profile>();
            this.ChangeMode(ModeEnum.NONE);

            if (Settings.Default.Profiles != null)
            {
                var xmlSerializer = new XmlSerializer(typeof(Profile));
                foreach (string profileString in Settings.Default.Profiles)
                {
                    var profileStream = new MemoryStream(
                        Encoding.UTF8.GetBytes(profileString));
                    var profile = (Profile)xmlSerializer.Deserialize(
                        profileStream);
                    this.AddProfile(profile);
                }
            }
        }

        /// <summary>
        /// Represents the mode that the Profiles tab is in.
        /// </summary>
        private enum ModeEnum
        {
            /// <summary>
            /// None mode. The Profiles tab is unused.
            /// </summary>
            NONE,

            /// <summary>
            /// New mode. The Profiles tab is being used to create a new 
            /// profile.
            /// </summary>
            NEW,

            /// <summary>
            /// Edit mode. The Profiles tab is being used to edit a profile.
            /// </summary>
            EDIT
        }

        /// <summary>
        /// Changes the application mode to the specified mode.
        /// </summary>
        /// <param name="mode">The specified mode.</param>
        private void ChangeMode(ModeEnum mode)
        {
            this.mode = mode;

            switch (mode)
            {
                case ModeEnum.NONE:
                    profilesComboBox.SelectedIndex = -1;
                    hostTextBox.Enabled = false;
                    hostTextBox.Text = string.Empty;
                    domainTextBox.Enabled = false;
                    domainTextBox.Text = string.Empty;
                    dynamicDnsPasswordTextBox.Enabled = false;
                    dynamicDnsPasswordTextBox.Text = string.Empty;
                    updateIntervalComboBox.Enabled = false;
                    updateIntervalComboBox.SelectedIndex = -1;
                    autoDetectCheckBox.Enabled = false;
                    autoDetectCheckBox.Checked = false;
                    ipAddressTextBox.Enabled = false;
                    ipAddressTextBox.Text = string.Empty;

                    deleteButton.Enabled = false;
                    saveButton.Enabled = false;
                    cancelButton.Enabled = false;
                    break;
                case ModeEnum.NEW:
                    profilesComboBox.SelectedIndex = -1;
                    hostTextBox.Enabled = true;
                    hostTextBox.Text = string.Empty;
                    domainTextBox.Enabled = true;
                    domainTextBox.Text = string.Empty;
                    dynamicDnsPasswordTextBox.Enabled = true;
                    dynamicDnsPasswordTextBox.Text = string.Empty;
                    updateIntervalComboBox.Enabled = true;
                    updateIntervalComboBox.SelectedIndex = 
                        updateIntervalComboBox.Items.Count - 1;
                    autoDetectCheckBox.Enabled = true;
                    autoDetectCheckBox.Checked = false;
                    ipAddressTextBox.Enabled = true;
                    ipAddressTextBox.Text = string.Empty;

                    deleteButton.Enabled = true;
                    saveButton.Enabled = true;
                    cancelButton.Enabled = true;
                    break;
                case ModeEnum.EDIT:
                    hostTextBox.Enabled = true;
                    hostTextBox.Text = 
                        this.profiles[profilesComboBox.SelectedIndex].Host;
                    domainTextBox.Enabled = true;
                    domainTextBox.Text =
                        this.profiles[profilesComboBox.SelectedIndex].Domain;
                    dynamicDnsPasswordTextBox.Enabled = true;
                    dynamicDnsPasswordTextBox.Text =
                        this.profiles[profilesComboBox.SelectedIndex]
                        .DynamicDnsPassword;
                    updateIntervalComboBox.Enabled = true;
                    updateIntervalComboBox.SelectedIndex =
                        (int)this.profiles[profilesComboBox.SelectedIndex]
                        .UpdateInterval;
                    autoDetectCheckBox.Enabled = true;
                    autoDetectCheckBox.Checked =
                        this.profiles[profilesComboBox.SelectedIndex]
                        .AutoDetectIpAddress;
                    ipAddressTextBox.Enabled = 
                        !this.profiles[profilesComboBox.SelectedIndex]
                        .AutoDetectIpAddress;
                    ipAddressTextBox.Text =
                        this.profiles[profilesComboBox.SelectedIndex]
                        .IpAddress;

                    if (autoDetectCheckBox.Checked)
                    {
                        ipAddressTextBox.Text = string.Empty;
                    }

                    deleteButton.Enabled = true;
                    saveButton.Enabled = true;
                    cancelButton.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// Adds the specified profile to the profiles list.
        /// </summary>
        /// <param name="profile">The specified profile.</param>
        private void AddProfile(Profile profile)
        {
            var profileStatusItem = new ListViewItem(profile.Label);
            profileStatusItem.SubItems.Add(new ListViewItem.ListViewSubItem(
                profileStatusItem, string.Empty));
            profileStatusItem.SubItems.Add(new ListViewItem.ListViewSubItem(
                profileStatusItem, string.Empty));

            this.profiles.Add(profile);
            this.profilesComboBox.Items.Add(profile.Label);
            this.statusListView.Items.Add(profileStatusItem);

            this.PerformDynamicDnsUpdate(profile);
        }

        /// <summary>
        /// Edits the specified profile at the specified index in the profiles
        /// list.
        /// </summary>
        /// <param name="profile">The specified profile.</param>
        /// <param name="index">The specified index.</param>
        private void EditProfile(Profile profile, int index)
        {
            var profileStatusItem = new ListViewItem(profile.Label);
            profileStatusItem.SubItems.Add(new ListViewItem.ListViewSubItem(
                profileStatusItem, string.Empty));
            profileStatusItem.SubItems.Add(new ListViewItem.ListViewSubItem(
                profileStatusItem, string.Empty));

            this.profiles[index] = profile;
            this.profilesComboBox.Items[index] = profile.Label;
            this.statusListView.Items[index] = profileStatusItem;

            this.PerformDynamicDnsUpdate(profile);
        }

        /// <summary>
        /// Performs a dynamic DNS update with the specified profile.
        /// </summary>
        /// <param name="profile">The specified profile.</param>
        private void PerformDynamicDnsUpdate(Profile profile)
        {
            var message = DynamicDns.PerformDynamicDnsUpdate(profile);
            profile.LastSyncTime = DateTime.Now;

            var date = profile.LastSyncTime.ToShortDateString() + " " + 
                profile.LastSyncTime.ToShortTimeString();

            var profileStatusItem = statusListView.Items[this.profiles.IndexOf(
                profile)];
            profileStatusItem.SubItems[1].Text = message;
            profileStatusItem.SubItems[2].Text = date;

            lastActionValueStatusLabel.Text = date;

            timer.Stop();
            timer.Start();
        }

        /// <summary>
        /// Called when the Update All button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UpdateAllButton_Click(object sender, EventArgs e)
        {
            foreach (var profile in this.profiles)
            {
                this.PerformDynamicDnsUpdate(profile);
            }
        }

        /// <summary>
        /// Called when the Stop/Start button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void StopStartButton_Click(object sender, EventArgs e)
        {
            if ((string)stopStartButton.Tag == "Stop All")
            {
                timer.Stop();
                stopStartButton.Tag = "Start";
            }
            else if ((string)stopStartButton.Tag == "Start")
            {
                timer.Start();
                stopStartButton.Text = "Stop";
                stopStartButton.Tag = "Stop";
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Called when the New button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void NewButton_Click(object sender, EventArgs e)
        {
            this.ChangeMode(ModeEnum.NEW);
        }

        /// <summary>
        /// Called when the Delete button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.profiles.RemoveAt(profilesComboBox.SelectedIndex);
            this.ChangeMode(ModeEnum.NONE);
        }

        /// <summary>
        /// Called when the Save button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Profile profile;
            if (this.mode == ModeEnum.NEW)
            {
                profile = new Profile();
            }
            else if (this.mode == ModeEnum.EDIT)
            {
                profile = this.profiles[profilesComboBox.SelectedIndex];
            }
            else
            {
                return;
            }

            profile.Host = hostTextBox.Text;
            profile.Domain = domainTextBox.Text;
            profile.DynamicDnsPassword = dynamicDnsPasswordTextBox.Text;
            profile.UpdateInterval = 
                (UpdateIntervalEnum)updateIntervalComboBox.SelectedIndex;
            profile.IpAddress = ipAddressTextBox.Text;
            profile.AutoDetectIpAddress = autoDetectCheckBox.Checked;

            if (profile.Host == string.Empty || profile.Domain == string.Empty
                || profile.DynamicDnsPassword == string.Empty
                || updateIntervalComboBox.SelectedIndex == -1
                || (profile.IpAddress == string.Empty && 
                !profile.AutoDetectIpAddress))
            {
                MessageBox.Show(
                    "Data validation failed.",
                    "namecheap-dynamic-dns");
                return;
            }

            if (this.mode == ModeEnum.NEW)
            {
                this.AddProfile(profile);
            }
            else if (this.mode == ModeEnum.EDIT)
            {
                this.EditProfile(profile, profilesComboBox.SelectedIndex);
            }

            this.ChangeMode(ModeEnum.NONE);
        }

        /// <summary>
        /// Called when the Cancel button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.ChangeMode(ModeEnum.NONE);
        }

        /// <summary>
        /// Called when the Exit button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Called when the About button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        /// <summary>
        /// Called when the profiles combo box selected index changes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ProfilesComboBox_SelectedIndexChanged(
            object sender, 
            EventArgs e)
        {
            if (profilesComboBox.SelectedIndex != -1)
            {
                this.ChangeMode(ModeEnum.EDIT);
            }
        }

        /// <summary>
        /// Called when the auto detect IP address check box checked status
        /// changes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AutoDetectCheckBox_CheckedChanged(
            object sender,
            EventArgs e)
        {
            ipAddressTextBox.Enabled = !autoDetectCheckBox.Checked;
            if (autoDetectCheckBox.Checked)
            {
                ipAddressTextBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Called when the notify icon is double-clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void NotifyIcon_MouseDoubleClick(
            object sender,
            MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Called when the timer ticks.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var profile in this.profiles)
            {
                if (profile.LastSyncTime +
                    Profile.GetTimeSpanForUpdateInterval(
                        profile.UpdateInterval) <= DateTime.Now)
                {
                    this.PerformDynamicDnsUpdate(profile);
                }
            }
        }

        /// <summary>
        /// Called when the main form is resized.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Called when the main form is closing.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void MainForm_FormClosing(
            object sender, 
            FormClosingEventArgs e)
        {
            var collection = new StringCollection();
            var xmlSerializer = new XmlSerializer(typeof(Profile));
            foreach (Profile profile in this.profiles)
            {
                var profileStream = new MemoryStream();
                xmlSerializer.Serialize(profileStream, profile);
                var profileString = Encoding.UTF8.GetString(
                    profileStream.ToArray());
                collection.Add(profileString);
            }

            Settings.Default.Profiles = collection;
            Settings.Default.Save();
        }
    }
}
