using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace AutoLoginTool
{
    public partial class MainForm : Form
    {
        public static string ENC_SECRET = "";
        public const string SECRET_FILENAME = "secret.al";
        public const string PROFILE_DIR = "profiles\\";
        public const string PROFILE_EXT = ".alp";

        public ToolStripItem FindProfile(string profileName)
        {
            foreach (ToolStripItem item in steamToolStripMenuItem.DropDownItems)
            {
                if (item.Text == profileName)
                    return item;
            }

            return null;
        }

        public bool AddProfile(string profileName)
        {
            // Do not create profile if already exists
            if (FindProfile(profileName) != null)
                return false;

            ToolStripMenuItem profile = new ToolStripMenuItem(profileName);

            var login = new ToolStripMenuItem("Login");
            login.Click += (object sender2, EventArgs e2) =>
            {
                LoginToSteam(profile.Text);
            };

            var remove = new ToolStripMenuItem("Remove");
            remove.Click += (object sender2, EventArgs e2) =>
            {
                if (File.Exists(PROFILE_DIR + profile.Text + PROFILE_EXT))
                    File.Delete(PROFILE_DIR + profile.Text + PROFILE_EXT);

                steamToolStripMenuItem.DropDownItems.Remove(profile);
            };

            var newProfile = new ToolStripItem[] { login, remove };

            profile.DropDownItems.AddRange(newProfile);

            steamToolStripMenuItem.DropDownItems.Add(profile);

            return true;
        }

        public void GetProfiles()
        {
            if (!Directory.Exists(PROFILE_DIR))
                return;

            string[] files = Directory.GetFiles(PROFILE_DIR);

            bool addedProfile = false;

            foreach (string fileName in files)
            {
                if (fileName.EndsWith(PROFILE_EXT))
                {
                    var name = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                    string profileName = name.Substring(0, name.Length - 4);
                    AddProfile(profileName);
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();

            if (File.Exists(SECRET_FILENAME))
            {
                setSecretGroup.Visible = false;
                unlockGroup.Visible = true;
            }
        }

        private void LoginToSteam(string profileSelected)
        {
            if (profileSelected.Length == 0)
                return;

            string path = PROFILE_DIR + profileSelected + PROFILE_EXT;

            if (!File.Exists(path))
            {
                var profileItem = FindProfile(profileSelected);
                if (profileItem != null)
                    steamToolStripMenuItem.DropDownItems.Remove(profileItem);

                return;
            }

            string loginCredentials = File.ReadAllText(path);

            if (loginCredentials.Length == 0)
                return;

            loginCredentials = Encryption.DecryptString(ENC_SECRET, loginCredentials);

            var userPass = loginCredentials.Split('\n');

            if (userPass.Length < 2)
                return;

            SteamLoginer.KillSteam();

            string user = userPass[0];
            string pass = userPass[1];

            SteamLoginer.Login(user, pass);
        }

        private void createProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateProfileForm(this).ShowDialog();
        }

        private void saveSecret_Click(object sender, EventArgs e)
        {
            if (enterSecretTextbox.Text != confirmSecretTextbox.Text)
            {
                MessageBox.Show("The secret passphrases do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (enterSecretTextbox.Text.Length < 8)
            {
                MessageBox.Show("Secret is not complex enough (8 characters min.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ENC_SECRET = enterSecretTextbox.Text;

            File.WriteAllText(SECRET_FILENAME, Encryption.ComputeSha256Hash(ENC_SECRET));

            profilesToolStripMenuItem.Enabled = true;
            actionsToolStripMenuItem.Enabled = true;

            setSecretGroup.Visible = false;
        }

        private void unlockButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(SECRET_FILENAME))
                return;

            string secretHash = File.ReadAllText(SECRET_FILENAME);

            if (Encryption.ComputeSha256Hash(validateSecretTextbox.Text) != secretHash)
            {
                MessageBox.Show("Incorrect secret", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ENC_SECRET = validateSecretTextbox.Text;
            GetProfiles();

            profilesToolStripMenuItem.Enabled = true;
            actionsToolStripMenuItem.Enabled = true;

            unlockGroup.Visible = false;
        }

        private void resetSecretButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to do this?\nThis will result in all profiles being removed.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (Directory.Exists(PROFILE_DIR))
                    Directory.Delete(PROFILE_DIR, true);
                
                File.Delete(SECRET_FILENAME);

                unlockGroup.Visible = false;
                setSecretGroup.Visible = true;
            }
        }
    }
}
