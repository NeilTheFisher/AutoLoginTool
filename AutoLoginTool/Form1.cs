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
    public partial class Form1 : Form
    {
        private const string ext = ".alg";

        void AddProfile(string profileName)
        {
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
        }

        void GetProfiles()
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

        public Form1()
        {
            InitializeComponent();
            GetProfiles();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void steamToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || maskedTextBox1.Text.Length == 0 || nameProfile.Text.Length == 0)
                return;

            AddProfile(nameProfile.Text);

            textBox1.Clear();
            maskedTextBox1.Clear();
            nameProfile.Clear();


            File.WriteAllText(nameProfile.Text + ext, textBox1.Text + ":" + maskedTextBox1.Text);
        }

        private void LoginToSteam(string profileSelected)
        {
            if (profileSelected.Length == 0)
                return;

            string path = profileSelected + ext;

            if (!File.Exists(path))
            {
                foreach (ToolStripItem item in steamToolStripMenuItem.DropDownItems)
                {
                    if (item.Text == profileSelected)
                    {
                        steamToolStripMenuItem.DropDownItems.Remove(item);
                        break;
                    }
                }
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

        private void steamToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
