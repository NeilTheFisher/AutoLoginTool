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

namespace AutoLoginTool
{
    public partial class MainForm : Form
    {
        public readonly static string ext = ".alg";

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
                if (File.Exists(profile.Text + ext))
                    File.Delete(profile.Text + ext);

                steamToolStripMenuItem.DropDownItems.Remove(profile);
            };

            var newProfile = new ToolStripItem[] { login, remove };

            profile.DropDownItems.AddRange(newProfile);

            steamToolStripMenuItem.DropDownItems.Add(profile);

            return true;
        }

        public void GetProfiles()
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);

            foreach (string fileName in files)
            {
                if (fileName.EndsWith(ext))
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
            GetProfiles();
        }

        private void LoginToSteam(string profileSelected)
        {
            if (profileSelected.Length == 0)
                return;

            string path = profileSelected + ext;

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

            var userPass = loginCredentials.Split(':');

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
    }
}
