namespace JournalApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            msMainMenu = new MenuStrip();
            tsmiJournalList = new ToolStripMenuItem();
            tsmiSettings = new ToolStripMenuItem();
            tsmiJournalTypes = new ToolStripMenuItem();
            tsmiUserTypes = new ToolStripMenuItem();
            tsmiUsers = new ToolStripMenuItem();
            tsmiUserRights = new ToolStripMenuItem();
            tsmiOpenWindows = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            msMainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // msMainMenu
            // 
            msMainMenu.Items.AddRange(new ToolStripItem[] { tsmiJournalList, tsmiSettings, tsmiOpenWindows });
            msMainMenu.Location = new Point(0, 0);
            msMainMenu.Name = "msMainMenu";
            msMainMenu.Padding = new Padding(7, 3, 0, 3);
            msMainMenu.Size = new Size(1303, 25);
            msMainMenu.TabIndex = 0;
            // 
            // tsmiJournalList
            // 
            tsmiJournalList.Name = "tsmiJournalList";
            tsmiJournalList.Size = new Size(72, 19);
            tsmiJournalList.Text = "Журналы";
            // 
            // tsmiSettings
            // 
            tsmiSettings.DropDownItems.AddRange(new ToolStripItem[] { tsmiJournalTypes, tsmiUserTypes, tsmiUsers, tsmiUserRights });
            tsmiSettings.Name = "tsmiSettings";
            tsmiSettings.Size = new Size(79, 19);
            tsmiSettings.Text = "Настройки";
            // 
            // tsmiJournalTypes
            // 
            tsmiJournalTypes.Name = "tsmiJournalTypes";
            tsmiJournalTypes.Size = new Size(202, 22);
            tsmiJournalTypes.Text = "Виды журналов...";
            tsmiJournalTypes.Click += tsmiJournalTypes_Click;
            // 
            // tsmiUserTypes
            // 
            tsmiUserTypes.Name = "tsmiUserTypes";
            tsmiUserTypes.Size = new Size(202, 22);
            tsmiUserTypes.Text = "Типы пользователей...";
            tsmiUserTypes.Click += tsmiUserTypes_Click;
            // 
            // tsmiUsers
            // 
            tsmiUsers.Name = "tsmiUsers";
            tsmiUsers.Size = new Size(202, 22);
            tsmiUsers.Text = "Пользователи...";
            tsmiUsers.Click += tsmiUsers_Click;
            // 
            // tsmiUserRights
            // 
            tsmiUserRights.Name = "tsmiUserRights";
            tsmiUserRights.Size = new Size(202, 22);
            tsmiUserRights.Text = "Права пользователей...";
            tsmiUserRights.Click += tsmiUserRights_Click;
            // 
            // tsmiOpenWindows
            // 
            tsmiOpenWindows.Name = "tsmiOpenWindows";
            tsmiOpenWindows.Size = new Size(47, 19);
            tsmiOpenWindows.Text = "Окна";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 60000;
            timer1.Tick += timer1_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1303, 600);
            Controls.Add(msMainMenu);
            IsMdiContainer = true;
            MainMenuStrip = msMainMenu;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Журналы";
            msMainMenu.ResumeLayout(false);
            msMainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMainMenu;
        private ToolStripMenuItem tsmiJournalList;
        private ToolStripMenuItem tsmiSettings;
        private ToolStripMenuItem tsmiJournalTypes;
        private ToolStripMenuItem tsmiUserTypes;
        private ToolStripMenuItem tsmiUsers;
        private ToolStripMenuItem tsmiUserRights;
        private ToolStripMenuItem tsmiOpenWindows;
        private System.Windows.Forms.Timer timer1;
    }
}
