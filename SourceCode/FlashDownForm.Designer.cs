
namespace FlashDown
{
    partial class FlashDownForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlashDownForm));
            this.aboutLabel = new System.Windows.Forms.Label();
            this.sourceCodeLink = new System.Windows.Forms.LinkLabel();
            this.sourceCodeLabel = new System.Windows.Forms.Label();
            this.instructions1Label = new System.Windows.Forms.Label();
            this.divider = new System.Windows.Forms.Label();
            this.howToUseLabel = new System.Windows.Forms.Label();
            this.flashDownTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.flashDownContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentIPAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.currentIPAddressLabel = new System.Windows.Forms.Label();
            this.instructions2Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flashDownContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutLabel
            // 
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.aboutLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.aboutLabel.Location = new System.Drawing.Point(12, 30);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(503, 52);
            this.aboutLabel.TabIndex = 0;
            this.aboutLabel.Text = "FlashDown is an application that allows you to shutdown, restart, or lock your PC" +
    " screen, remotely from your phone";
            this.aboutLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sourceCodeLink
            // 
            this.sourceCodeLink.AutoSize = true;
            this.sourceCodeLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sourceCodeLink.Location = new System.Drawing.Point(177, 97);
            this.sourceCodeLink.Name = "sourceCodeLink";
            this.sourceCodeLink.Size = new System.Drawing.Size(269, 17);
            this.sourceCodeLink.TabIndex = 1;
            this.sourceCodeLink.TabStop = true;
            this.sourceCodeLink.Text = "https://github.com/future-flash/FlashDown";
            this.sourceCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // sourceCodeLabel
            // 
            this.sourceCodeLabel.AutoSize = true;
            this.sourceCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.sourceCodeLabel.Location = new System.Drawing.Point(79, 97);
            this.sourceCodeLabel.Name = "sourceCodeLabel";
            this.sourceCodeLabel.Size = new System.Drawing.Size(100, 18);
            this.sourceCodeLabel.TabIndex = 2;
            this.sourceCodeLabel.Text = "Source Code:";
            // 
            // instructions1Label
            // 
            this.instructions1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.instructions1Label.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.instructions1Label.Location = new System.Drawing.Point(8, 200);
            this.instructions1Label.Name = "instructions1Label";
            this.instructions1Label.Size = new System.Drawing.Size(513, 190);
            this.instructions1Label.TabIndex = 3;
            this.instructions1Label.Text = resources.GetString("instructions1Label.Text");
            this.instructions1Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // divider
            // 
            this.divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider.Enabled = false;
            this.divider.Location = new System.Drawing.Point(12, 165);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(503, 2);
            this.divider.TabIndex = 4;
            // 
            // howToUseLabel
            // 
            this.howToUseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToUseLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.howToUseLabel.Location = new System.Drawing.Point(12, 172);
            this.howToUseLabel.Name = "howToUseLabel";
            this.howToUseLabel.Size = new System.Drawing.Size(503, 24);
            this.howToUseLabel.TabIndex = 5;
            this.howToUseLabel.Text = "How to Use";
            this.howToUseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flashDownTrayIcon
            // 
            this.flashDownTrayIcon.ContextMenuStrip = this.flashDownContextMenu;
            this.flashDownTrayIcon.Text = "notifyIcon1";
            this.flashDownTrayIcon.Visible = true;
            this.flashDownTrayIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // flashDownContextMenu
            // 
            this.flashDownContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.startWithWindowsToolStripMenuItem,
            this.currentIPAddressToolStripMenuItem});
            this.flashDownContextMenu.Name = "contextMenuStrip1";
            this.flashDownContextMenu.Size = new System.Drawing.Size(177, 92);
            this.flashDownContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.flashDownContextMenu_Opening);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start with Windows";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            // 
            // currentIPAddressToolStripMenuItem
            // 
            this.currentIPAddressToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.currentIPAddressToolStripMenuItem.Enabled = false;
            this.currentIPAddressToolStripMenuItem.Name = "currentIPAddressToolStripMenuItem";
            this.currentIPAddressToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.currentIPAddressToolStripMenuItem.Text = "currentIPAddress";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.versionLabel.Location = new System.Drawing.Point(493, 527);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(28, 13);
            this.versionLabel.TabIndex = 8;
            this.versionLabel.Text = "v1.1";
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(526, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // currentIPAddressLabel
            // 
            this.currentIPAddressLabel.Location = new System.Drawing.Point(16, 122);
            this.currentIPAddressLabel.Name = "currentIPAddressLabel";
            this.currentIPAddressLabel.Size = new System.Drawing.Size(498, 35);
            this.currentIPAddressLabel.TabIndex = 10;
            this.currentIPAddressLabel.Text = "currentIPAddress";
            this.currentIPAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instructions2Label
            // 
            this.instructions2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.instructions2Label.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.instructions2Label.Location = new System.Drawing.Point(12, 397);
            this.instructions2Label.Name = "instructions2Label";
            this.instructions2Label.Size = new System.Drawing.Size(513, 139);
            this.instructions2Label.TabIndex = 11;
            this.instructions2Label.Text = resources.GetString("instructions2Label.Text");
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(11, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 2);
            this.label1.TabIndex = 12;
            // 
            // FlashDownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 545);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.instructions2Label);
            this.Controls.Add(this.currentIPAddressLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.howToUseLabel);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.instructions1Label);
            this.Controls.Add(this.sourceCodeLabel);
            this.Controls.Add(this.sourceCodeLink);
            this.Controls.Add(this.aboutLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FlashDownForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteShutdownForm_FormClosing);
            this.Load += new System.EventHandler(this.RemoteShutdownForm_Load);
            this.flashDownContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.LinkLabel sourceCodeLink;
        private System.Windows.Forms.Label sourceCodeLabel;
        private System.Windows.Forms.Label instructions1Label;
        private System.Windows.Forms.Label divider;
        private System.Windows.Forms.Label howToUseLabel;
        private System.Windows.Forms.ContextMenuStrip flashDownContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon flashDownTrayIcon;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label currentIPAddressLabel;
        private System.Windows.Forms.ToolStripMenuItem currentIPAddressToolStripMenuItem;
        private System.Windows.Forms.Label instructions2Label;
        private System.Windows.Forms.Label label1;
    }
}

