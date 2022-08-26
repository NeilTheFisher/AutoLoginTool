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
        public const string SECRET_FILENAME = "secret.alt";
        public const string PROFILE_DIR = "profiles\\";
        public const string PROFILE_EXT = ".alp";

        private bool unlocked = false;

        public ToolStripItem FindProfile(string profileName)
        {
            foreach (ToolStripItem item in steamToolStripMenuItem.DropDownItems)
            {
                if (item.Text == profileName)
                    return item;
            }

            return null;
        }

        public MenuItem FindProfileMenu(string profileName)
        {
            foreach (MenuItem item in notifyIcon.ContextMenu.MenuItems[0].MenuItems[0].MenuItems)
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

            MenuItem profileMenu = new MenuItem(profileName);
            ToolStripMenuItem profile = new ToolStripMenuItem(profileName);

            EventHandler LoginHandler = (object sender, EventArgs e) =>
            {
                LoginToSteam(profile.Text);
            };

            EventHandler RemoveHandler = (object sender, EventArgs e) =>
            {
                if (File.Exists(PROFILE_DIR + profile.Text + PROFILE_EXT))
                    File.Delete(PROFILE_DIR + profile.Text + PROFILE_EXT);

                steamToolStripMenuItem.DropDownItems.Remove(profile);
                notifyIcon.ContextMenu.MenuItems[0].MenuItems[0].MenuItems.Remove(profileMenu);
            };

            ToolStripItem login = new ToolStripMenuItem("Login");
            login.Click += LoginHandler;

            ToolStripItem remove = new ToolStripMenuItem("Remove");
            remove.Click += RemoveHandler;

            var newProfile = new ToolStripItem[] { login, remove };

            profile.DropDownItems.AddRange(newProfile);
            profileMenu.MenuItems.AddRange(new MenuItem[] { new MenuItem("Login", LoginHandler), new MenuItem("Remove", RemoveHandler) });

            steamToolStripMenuItem.DropDownItems.Add(profile);
            notifyIcon.ContextMenu.MenuItems[0].MenuItems[0].MenuItems.Add(profileMenu);

            return true;
        }

        public void GetProfiles()
        {
            if (!Directory.Exists(PROFILE_DIR))
                return;

            string[] files = Directory.GetFiles(PROFILE_DIR);

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

            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Profiles", new MenuItem[]{ new MenuItem("Steam", new MenuItem[]{}) }),
                new MenuItem("Actions", new MenuItem[]{ new MenuItem("Create Profile", (object sender, EventArgs e) => { new CreateProfileForm(this).ShowDialog(); }) }),
                new MenuItem("Exit", (object sender, EventArgs e) => { Application.Exit(); })
            });

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
                {
                    steamToolStripMenuItem.DropDownItems.Remove(profileItem);
                }

                var profileMenuItem = FindProfileMenu(profileSelected);

                if (profileMenuItem != null)
                {
                    notifyIcon.ContextMenu.MenuItems[0].MenuItems[0].MenuItems.Remove(profileMenuItem);
                }

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

            ENC_SECRET = enterSecretTextbox.Text;

            File.WriteAllText(SECRET_FILENAME, Encryption.ComputeSha256Hash(ENC_SECRET));

            profilesToolStripMenuItem.Enabled = true;
            actionsToolStripMenuItem.Enabled = true;

            setSecretGroup.Visible = false;
            unlocked = true;
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
            unlocked = true;
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
                unlocked = false;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && unlocked) {
                Hide();
                notifyIcon.Visible = true;
                MessageBox.Show("ALT has been minimized to your tray!", "Auto Login Tool", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
}
