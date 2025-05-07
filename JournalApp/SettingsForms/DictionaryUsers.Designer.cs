namespace JournalApp.SettingsForms
{
    partial class DictionaryUsers
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
            components = new System.ComponentModel.Container();
            lvUsers = new ListView();
            chUserName = new ColumnHeader();
            chUserTypes = new ColumnHeader();
            chComputers = new ColumnHeader();
            cmsUserMenu = new ContextMenuStrip(components);
            tsmiAddUser = new ToolStripMenuItem();
            tsmiChangeUser = new ToolStripMenuItem();
            tsmiDeleteUser = new ToolStripMenuItem();
            cmsUserMenu.SuspendLayout();
            SuspendLayout();
            // 
            // lvUsers
            // 
            lvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvUsers.Columns.AddRange(new ColumnHeader[] { chUserName, chUserTypes, chComputers });
            lvUsers.ContextMenuStrip = cmsUserMenu;
            lvUsers.FullRowSelect = true;
            lvUsers.Location = new Point(2, 0);
            lvUsers.Margin = new Padding(4, 5, 4, 5);
            lvUsers.MultiSelect = false;
            lvUsers.Name = "lvUsers";
            lvUsers.Size = new Size(765, 426);
            lvUsers.TabIndex = 0;
            lvUsers.UseCompatibleStateImageBehavior = false;
            lvUsers.View = View.Details;
            lvUsers.DoubleClick += lvUsers_DoubleClick;
            // 
            // chUserName
            // 
            chUserName.Text = "Имя пользователя";
            chUserName.Width = 200;
            // 
            // chUserTypes
            // 
            chUserTypes.Text = "Группы";
            chUserTypes.Width = 250;
            // 
            // chComputers
            // 
            chComputers.Text = "Доступные компьютеры для автоматического входа";
            chComputers.Width = 300;
            // 
            // cmsUserMenu
            // 
            cmsUserMenu.Font = new Font("Segoe UI", 13F);
            cmsUserMenu.Items.AddRange(new ToolStripItem[] { tsmiAddUser, tsmiChangeUser, tsmiDeleteUser });
            cmsUserMenu.Name = "cmsUserMenu";
            cmsUserMenu.Size = new Size(292, 116);
            // 
            // tsmiAddUser
            // 
            tsmiAddUser.Name = "tsmiAddUser";
            tsmiAddUser.Size = new Size(291, 30);
            tsmiAddUser.Text = "Добавить пользователя...";
            tsmiAddUser.Click += tsmiAddUser_Click;
            // 
            // tsmiChangeUser
            // 
            tsmiChangeUser.Name = "tsmiChangeUser";
            tsmiChangeUser.Size = new Size(291, 30);
            tsmiChangeUser.Text = "Изменить пользователя...";
            tsmiChangeUser.Click += tsmiChangeUser_Click;
            // 
            // tsmiDeleteUser
            // 
            tsmiDeleteUser.Name = "tsmiDeleteUser";
            tsmiDeleteUser.Size = new Size(291, 30);
            tsmiDeleteUser.Text = "Удалить пользователя";
            tsmiDeleteUser.Click += tsmiDeleteUser_Click;
            // 
            // DictionaryUsers
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 425);
            Controls.Add(lvUsers);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 5, 4, 5);
            Name = "DictionaryUsers";
            Text = "DictionaryUsers";
            cmsUserMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ContextMenuStrip cmsUserMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteUser;
        private System.Windows.Forms.ColumnHeader chUserName;
        private System.Windows.Forms.ColumnHeader chUserTypes;
        private System.Windows.Forms.ColumnHeader chComputers;
    }
}