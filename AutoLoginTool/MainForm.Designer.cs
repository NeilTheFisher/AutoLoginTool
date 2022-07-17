
namespace AutoLoginTool
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
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSecret = new System.Windows.Forms.Button();
            this.enterSecretTextbox = new System.Windows.Forms.TextBox();
            this.confirmSecretTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.validateSecretTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.unlockButton = new System.Windows.Forms.Button();
            this.resetSecretButton = new System.Windows.Forms.Button();
            this.unlockGroup = new System.Windows.Forms.Panel();
            this.setSecretGroup = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.unlockGroup.SuspendLayout();
            this.setSecretGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steamToolStripMenuItem});
            this.profilesToolStripMenuItem.Enabled = false;
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // steamToolStripMenuItem
            // 
            this.steamToolStripMenuItem.Name = "steamToolStripMenuItem";
            this.steamToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.steamToolStripMenuItem.Text = "Steam";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(236, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProfileToolStripMenuItem});
            this.actionsToolStripMenuItem.Enabled = false;
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // createProfileToolStripMenuItem
            // 
            this.createProfileToolStripMenuItem.Name = "createProfileToolStripMenuItem";
            this.createProfileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.createProfileToolStripMenuItem.Text = "Create Profile";
            this.createProfileToolStripMenuItem.Click += new System.EventHandler(this.createProfileToolStripMenuItem_Click);
            // 
            // saveSecret
            // 
            this.saveSecret.Location = new System.Drawing.Point(43, 116);
            this.saveSecret.Name = "saveSecret";
            this.saveSecret.Size = new System.Drawing.Size(100, 23);
            this.saveSecret.TabIndex = 1;
            this.saveSecret.Text = "Save";
            this.saveSecret.UseVisualStyleBackColor = true;
            this.saveSecret.Click += new System.EventHandler(this.saveSecret_Click);
            // 
            // enterSecretTextbox
            // 
            this.enterSecretTextbox.Location = new System.Drawing.Point(43, 33);
            this.enterSecretTextbox.Name = "enterSecretTextbox";
            this.enterSecretTextbox.Size = new System.Drawing.Size(100, 20);
            this.enterSecretTextbox.TabIndex = 2;
            // 
            // confirmSecretTextbox
            // 
            this.confirmSecretTextbox.Location = new System.Drawing.Point(43, 80);
            this.confirmSecretTextbox.Name = "confirmSecretTextbox";
            this.confirmSecretTextbox.Size = new System.Drawing.Size(100, 20);
            this.confirmSecretTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Secret";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Confirm Secret";
            // 
            // validateSecretTextbox
            // 
            this.validateSecretTextbox.Location = new System.Drawing.Point(43, 24);
            this.validateSecretTextbox.Name = "validateSecretTextbox";
            this.validateSecretTextbox.PasswordChar = '*';
            this.validateSecretTextbox.Size = new System.Drawing.Size(100, 20);
            this.validateSecretTextbox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Secret";
            // 
            // unlockButton
            // 
            this.unlockButton.Location = new System.Drawing.Point(43, 50);
            this.unlockButton.Name = "unlockButton";
            this.unlockButton.Size = new System.Drawing.Size(100, 23);
            this.unlockButton.TabIndex = 8;
            this.unlockButton.Text = "Unlock";
            this.unlockButton.UseVisualStyleBackColor = true;
            this.unlockButton.Click += new System.EventHandler(this.unlockButton_Click);
            // 
            // resetSecretButton
            // 
            this.resetSecretButton.Location = new System.Drawing.Point(43, 79);
            this.resetSecretButton.Name = "resetSecretButton";
            this.resetSecretButton.Size = new System.Drawing.Size(100, 23);
            this.resetSecretButton.TabIndex = 9;
            this.resetSecretButton.Text = "Reset Secret";
            this.resetSecretButton.UseVisualStyleBackColor = true;
            this.resetSecretButton.Click += new System.EventHandler(this.resetSecretButton_Click);
            // 
            // unlockGroup
            // 
            this.unlockGroup.Controls.Add(this.label3);
            this.unlockGroup.Controls.Add(this.resetSecretButton);
            this.unlockGroup.Controls.Add(this.validateSecretTextbox);
            this.unlockGroup.Controls.Add(this.unlockButton);
            this.unlockGroup.Location = new System.Drawing.Point(24, 43);
            this.unlockGroup.Name = "unlockGroup";
            this.unlockGroup.Size = new System.Drawing.Size(200, 122);
            this.unlockGroup.TabIndex = 10;
            this.unlockGroup.Visible = false;
            // 
            // setSecretGroup
            // 
            this.setSecretGroup.Controls.Add(this.label2);
            this.setSecretGroup.Controls.Add(this.confirmSecretTextbox);
            this.setSecretGroup.Controls.Add(this.label1);
            this.setSecretGroup.Controls.Add(this.saveSecret);
            this.setSecretGroup.Controls.Add(this.enterSecretTextbox);
            this.setSecretGroup.Location = new System.Drawing.Point(24, 27);
            this.setSecretGroup.Name = "setSecretGroup";
            this.setSecretGroup.Size = new System.Drawing.Size(200, 159);
            this.setSecretGroup.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Secret";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Reset Secret";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Unlock";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 198);
            this.Controls.Add(this.setSecretGroup);
            this.Controls.Add(this.unlockGroup);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Auto Login Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.unlockGroup.ResumeLayout(false);
            this.unlockGroup.PerformLayout();
            this.setSecretGroup.ResumeLayout(false);
            this.setSecretGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem steamToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProfileToolStripMenuItem;
        private System.Windows.Forms.Button saveSecret;
        private System.Windows.Forms.TextBox enterSecretTextbox;
        private System.Windows.Forms.TextBox confirmSecretTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox validateSecretTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button unlockButton;
        private System.Windows.Forms.Button resetSecretButton;
        private System.Windows.Forms.Panel unlockGroup;
        private System.Windows.Forms.Panel setSecretGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

