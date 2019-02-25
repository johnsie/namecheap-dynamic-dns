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
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Kourlas.NamecheapDynamicDns.Properties;

    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Handles the performance and scheduling of dynamic DNS updates and 
        /// informs the UI when they are complete using an event handler.
        /// </summary>
        private DynamicDns dynamicDns;

        /// <summary>
        /// The current mode that the Profiles tab is in.
        /// </summary>
        private ProfilesMode mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.ChangeMode(ProfilesMode.NONE);

            this.dynamicDns = new DynamicDns();
            this.dynamicDns.DynamicDnsUpdateEventHandler += 
                this.OnDynamicDnsUpdate;
            this.LoadProfiles();

            this.labelProductName.Text = this.AssemblyProduct;
            this.labelVersion.Text = string.Format(
                "Version {0}", this.AssemblyVersion);
            this.labelCopyright.Text = this.AssemblyCopyright;
            this.labelCompanyName.Text = this.AssemblyCompany;
            this.textBoxDescription.Text = this.AssemblyDescription;
        }

        /// <summary>
        /// Represents the mode that the Profiles tab is in.
        /// </summary>
        private enum ProfilesMode
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

        #region Assembly Attribute Accessors

        /// <summary>
        /// Gets the assembly title.
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(
                        typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute =
                        (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != string.Empty)
                    {
                        return titleAttribute.Title;
                    }
                }

                return System.IO.Path.GetFileNameWithoutExtension(
                    Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version
                    .ToString();
            }
        }

        /// <summary>
        /// Gets the assembly description.
        /// </summary>
        public string AssemblyDescription
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(
                        typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the assembly product.
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(
                        typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the assembly copyright.
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(
                        typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Gets the assembly company.
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(
                        typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        
        /// <summary>
        /// Changes the application mode to the specified mode.
        /// </summary>
        /// <param name="mode">The specified mode.</param>
        private void ChangeMode(ProfilesMode mode)
        {
            switch (mode)
            {
                case ProfilesMode.NONE:
                    this.ChangeToNoneMode();
                    break;
                case ProfilesMode.NEW:
                    this.ChangeToNewMode();
                    break;
                case ProfilesMode.EDIT:
                    this.ChangeToEditMode();
                    break;
            }
        }

        /// <summary>
        /// Changes the application mode to the none mode.
        /// </summary>
        private void ChangeToNoneMode()
        {
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

            this.mode = ProfilesMode.NONE;
        }

        /// <summary>
        /// Changes the application mode to the new mode.
        /// </summary>
        private void ChangeToNewMode()
        {
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

            this.mode = ProfilesMode.NEW;
        }

        /// <summary>
        /// Changes the application mode to the edit mode.
        /// </summary>
        private void ChangeToEditMode()
        {
            var id = ((ComboBoxItem)profilesComboBox
                .Items[profilesComboBox.SelectedIndex]).Id;
            var profile = this.dynamicDns.GetProfile(id);
            if (profile == null)
            {
                return;
            }

            hostTextBox.Enabled = true;
            hostTextBox.Text = profile.Host;
            domainTextBox.Enabled = true;
            domainTextBox.Text = profile.Domain;
            dynamicDnsPasswordTextBox.Enabled = true;
            dynamicDnsPasswordTextBox.Text = profile.DynamicDnsPassword;
            updateIntervalComboBox.Enabled = true;
            updateIntervalComboBox.SelectedIndex = (int)profile.Interval;
            autoDetectCheckBox.Enabled = true;
            autoDetectCheckBox.Checked = profile.AutoDetectIPAddress;
            ipAddressTextBox.Enabled = !profile.AutoDetectIPAddress;
            ipAddressTextBox.Text = profile.UpdateIPAddress?.ToString() ?? 
                string.Empty;

            if (autoDetectCheckBox.Checked)
            {
                ipAddressTextBox.Text = string.Empty;
            }

            deleteButton.Enabled = true;
            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            this.mode = ProfilesMode.EDIT;
        }

        /// <summary>
        /// Adds the specified profile to the profiles list.
        /// </summary>
        /// <param name="profile">The specified profile.</param>
        /// <returns>A task which completes when the process is 
        /// complete.</returns>
        private async Task AddProfile(DynamicDnsProfile profile)
        {
            var statusItem = new ListViewItem(profile.Label)
            {
                Tag = profile.Id
            };
            statusItem.SubItems.Add(new ListViewItem.ListViewSubItem(
                statusItem, string.Empty));
            statusItem.SubItems.Add(new ListViewItem.ListViewSubItem(
                statusItem, string.Empty));
            this.statusListView.Items.Add(statusItem);

            var profileItem = new ComboBoxItem(profile.Label, profile.Id);
            this.profilesComboBox.Items.Add(profileItem);

            await this.dynamicDns.AddProfile(profile);
        }

        /// <summary>
        /// Replaces the old profile with the specified ID with the specified
        /// new profile.
        /// </summary>
        /// <param name="oldProfileId">The ID of the old profile.</param>
        /// <param name="newProfile">The new profile.</param>
        /// <returns>A task which completes when the process is 
        /// complete.</returns>
        private async Task ReplaceProfile(
            Guid oldProfileId, 
            DynamicDnsProfile newProfile)
        {
            this.DeleteProfile(oldProfileId);
            await this.AddProfile(newProfile);
        }
        
        /// <summary>
        /// Deletes the specified profile.
        /// </summary>
        /// <param name="profileId">The ID of the profile to delete.</param>
        private void DeleteProfile(Guid profileId)
        {
            var statusItems = statusListView.Items.Cast<ListViewItem>();
            var statusItemQuery = from item in statusItems
                                  where (Guid)item.Tag == profileId
                                  select item;
            var statusItemsList = statusItemQuery.ToList();
            foreach (var item in statusItemsList)
            {
                statusListView.Items.Remove(item);
            }
        
            var profileItems = profilesComboBox.Items.Cast<ComboBoxItem>();
            var profileItemQuery = from item in profileItems
                                   where (Guid)item.Id == profileId
                                   select item;
            var profileItemsList = profileItemQuery.ToList();
            foreach (var item in profileItemsList)
            {
                profilesComboBox.Items.Remove(item);
            }

            this.dynamicDns.DeleteProfile(profileId);
        }

        /// <summary>
        /// Loads the dynamic DNS profiles from the application settings.
        /// If deserialization fails, does nothing.
        /// </summary>
        /// <returns>A task which completes when the process is 
        /// complete.</returns>
        private async void LoadProfiles()
        {
            try
            {
                if (Settings.Default.SettingsUpgradeRequired)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.SettingsUpgradeRequired = false;
                    Settings.Default.Save();
                }

                if (Settings.Default.Profiles != null)
                {
                    var xmlSerializer = new XmlSerializer(
                        typeof(DynamicDnsProfile));
                    foreach (string profileString in Settings.Default.Profiles)
                    {
                        var profileStream = new MemoryStream(
                            Encoding.UTF8.GetBytes(profileString));
                        var profileStreamReader = new StreamReader(
                            profileStream, Encoding.UTF8);
                        var profile = (DynamicDnsProfile)
                            xmlSerializer.Deserialize(profileStreamReader);
                        await this.AddProfile(profile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load profiles: {ex.Message}.",
                    "namecheap-dynamic-dns");
            }
        }

        /// <summary>
        /// Saves the dynamic DNS profiles to the application settings.
        /// If serialization fails, does nothing.
        /// </summary>
        private void SaveProfiles()
        {
            try
            {
                // Serialize each profile to an XML string (encoded using
                // UTF-8) and add them to a string collection
                var collection = new StringCollection();
                var xmlSerializer = new XmlSerializer(
                    typeof(DynamicDnsProfile));
                foreach (DynamicDnsProfile profile 
                         in this.dynamicDns.Profiles.Values)
                {
                    using (var profileStream = new MemoryStream())
                    {
                        var profileStreamWriter = new StreamWriter(
                            profileStream,
                            Encoding.UTF8);
                        xmlSerializer.Serialize(profileStreamWriter, profile);
                        var profileString = Encoding.UTF8.GetString(
                            profileStream.ToArray());
                        collection.Add(profileString);
                    }
                }

                // Replace existing string collection with new string 
                // collection and save to settings
                Settings.Default.Profiles = collection;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to save profiles: {ex.Message}.",
                    "namecheap-dynamic-dns");
            }
        }

        /// <summary>
        /// Called when a dynamic DNS update occurs.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDynamicDnsUpdate(
            object sender, DynamicDnsUpdateEventArgs e)
        {
            var date = e.UpdateDateTime.ToShortDateString() + " " +
                e.UpdateDateTime.ToShortTimeString();
            var message = e.Success ?
                $"Update successful ({e.Ip})" :
                $"Update failed ({e.UpdateException.Message})";

            var items = statusListView.Items.Cast<ListViewItem>();
            var statusItemQuery = from item in items
                                  where (Guid)item.Tag == e.UpdateProfile.Id
                                  select item;
            var statusItems = statusItemQuery.ToList();
            if (statusItems.Count == 1)
            {
                var statusItem = statusItems[0];

                statusItem.SubItems[1].Text = message;
                statusItem.SubItems[2].Text = date;

                lastActionValueStatusLabel.Text = 
                    $"{e.UpdateProfile.Label} ({date})";
            }
        }
        
        /// <summary>
        /// Called when the Update button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnUpdateButtonClick(object sender, EventArgs e)
        {
            foreach (int index in statusListView.SelectedIndices)
            {
                var item = this.statusListView.Items[index];
                var profile = this.dynamicDns.GetProfile((Guid)item.Tag);
                if (profile != null)
                {
                    await this.dynamicDns.PerformUpdate(profile);
                }
            }
        }

        /// <summary>
        /// Called when the Update All button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnUpdateAllButtonClick(object sender, EventArgs e)
        {
            await this.dynamicDns.PerformUpdateAll();
        }

        /// <summary>
        /// Called when the New button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnNewButtonClick(object sender, EventArgs e)
        {
            this.ChangeMode(ProfilesMode.NEW);
        }

        /// <summary>
        /// Called when the Delete button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            if (this.mode != ProfilesMode.NEW)
            {
                var id = ((ComboBoxItem)profilesComboBox
                    .Items[profilesComboBox.SelectedIndex]).Id;
                this.DeleteProfile(id);
            }
            
            this.ChangeMode(ProfilesMode.NONE);
        }

        /// <summary>
        /// Called when the Save button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnSaveButtonClick(object sender, EventArgs e)
        {
            var mode = this.mode;
            var index = profilesComboBox.SelectedIndex;

            var profile = new DynamicDnsProfile()
            {
                Host = hostTextBox.Text,
                Domain = domainTextBox.Text,
                DynamicDnsPassword = dynamicDnsPasswordTextBox.Text,
                Interval =
                (UpdateInterval)updateIntervalComboBox.SelectedIndex
            };
            IPAddress.TryParse(ipAddressTextBox.Text, out IPAddress ipAddress);
            profile.UpdateIPAddress = ipAddress?.ToString() ?? string.Empty;
            profile.AutoDetectIPAddress = autoDetectCheckBox.Checked;

            if (profile.Host == string.Empty || profile.Domain == string.Empty
                || profile.DynamicDnsPassword == string.Empty
                || updateIntervalComboBox.SelectedIndex == -1
                || (profile.UpdateIPAddress == string.Empty 
                    && !profile.AutoDetectIPAddress))
            {
                MessageBox.Show(
                    "Profile information validation failed.",
                    "namecheap-dynamic-dns");
                return;
            }

            this.ChangeMode(ProfilesMode.NONE);
            if (mode == ProfilesMode.NEW)
            {
                await this.AddProfile(profile);
            }
            else if (mode == ProfilesMode.EDIT)
            {
                var id = ((ComboBoxItem)profilesComboBox.Items[index]).Id;
                await this.ReplaceProfile(id, profile);
            }
        }

        /// <summary>
        /// Called when the Cancel button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.ChangeMode(ProfilesMode.NONE);
        }

        /// <summary>
        /// Called when the status list view selected index changes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void StatusListViewSelectedIndexChanged(
            object sender, EventArgs e)
        {
            updateButton.Enabled = statusListView.SelectedIndices.Count != 0;
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
                this.ChangeMode(ProfilesMode.EDIT);
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
            this.SaveProfiles();
        }

        /// <summary>
        /// Links dynamic DNS profiles with entries in a combo box.
        /// </summary>
        private class ComboBoxItem
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ComboBoxItem"/>
            /// class.
            /// </summary>
            /// <param name="text">The text associated with the item.</param>
            /// <param name="id">The ID associated with the item.</param>
            public ComboBoxItem(string text, Guid id)
            {
                this.Text = text;
                this.Id = id;
            }

            /// <summary>
            /// Gets or sets the text associated with the item.
            /// </summary>
            public string Text
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets ID associated with the item.
            /// </summary>
            public Guid Id
            {
                get;
                set;
            }

            /// <summary>
            /// Returns the text associated with the item.
            /// </summary>
            /// <returns>The text associated with the item.</returns>
            public override string ToString()
            {
                return this.Text;
            }
        }
    }
}
