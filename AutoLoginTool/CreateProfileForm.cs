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
    public partial class CreateProfileForm : Form
    {
        private MainForm mainForm;
        public CreateProfileForm(MainForm frm)
        {
            mainForm = frm;
            InitializeComponent();
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

            if (mainForm.AddProfile(nameProfile.Text))
            {
                if (!Directory.Exists(MainForm.PROFILE_DIR))
                    Directory.CreateDirectory(MainForm.PROFILE_DIR);

                File.WriteAllText(MainForm.PROFILE_DIR + nameProfile.Text + MainForm.PROFILE_EXT, Encryption.EncryptString(MainForm.ENC_SECRET, textBox1.Text + "\n" + maskedTextBox1.Text));
            }
            else
                MessageBox.Show("Profile already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBox1.Clear();
            maskedTextBox1.Clear();
            nameProfile.Clear();
        }
    }
}
