namespace IngenicoPOSAPITest
{
    partial class IngenicoPOSAPI_MAIN
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.initToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionRequestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initToolStripMenuItem,
            this.pollToolStripMenuItem,
            this.terminalStatusToolStripMenuItem,
            this.transactionRequestToolStripMenuItem,
            this.transactionRequestToolStripMenuItem1});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(48, 20);
            this.toolsMenu.Text = "&Tools";
            // 
            // initToolStripMenuItem
            // 
            this.initToolStripMenuItem.Name = "initToolStripMenuItem";
            this.initToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.initToolStripMenuItem.Text = "&Init";
            this.initToolStripMenuItem.Click += new System.EventHandler(this.initToolStripMenuItem_Click);
            // 
            // pollToolStripMenuItem
            // 
            this.pollToolStripMenuItem.Name = "pollToolStripMenuItem";
            this.pollToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.pollToolStripMenuItem.Text = "&Poll";
            // 
            // terminalStatusToolStripMenuItem
            // 
            this.terminalStatusToolStripMenuItem.Name = "terminalStatusToolStripMenuItem";
            this.terminalStatusToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.terminalStatusToolStripMenuItem.Text = "&Terminal Status";
            this.terminalStatusToolStripMenuItem.Click += new System.EventHandler(this.terminalStatusToolStripMenuItem_Click);
            // 
            // transactionRequestToolStripMenuItem
            // 
            this.transactionRequestToolStripMenuItem.Name = "transactionRequestToolStripMenuItem";
            this.transactionRequestToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.transactionRequestToolStripMenuItem.Text = "Report Request";
            this.transactionRequestToolStripMenuItem.Click += new System.EventHandler(this.transactionRequestToolStripMenuItem_Click);
            // 
            // transactionRequestToolStripMenuItem1
            // 
            this.transactionRequestToolStripMenuItem1.Name = "transactionRequestToolStripMenuItem1";
            this.transactionRequestToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.transactionRequestToolStripMenuItem1.Text = "Transaction Re&quest";
            this.transactionRequestToolStripMenuItem1.Click += new System.EventHandler(this.transactionRequestToolStripMenuItem1_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // IngenicoPOSAPI_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "IngenicoPOSAPI_MAIN";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Friends POSAPI ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem initToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminalStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionRequestToolStripMenuItem1;
    }
}



