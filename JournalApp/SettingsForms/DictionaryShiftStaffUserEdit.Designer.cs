namespace JournalApp.SettingsForms
{
    partial class DictionaryShiftStaffUserEdit
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
            lblUserName = new Label();
            txbUserName = new TextBox();
            txbComputers = new TextBox();
            lblComputers = new Label();
            btnChangePassword = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            lblUserType = new Label();
            lvUserTypes = new ListView();
            lvchUserTypeName = new ColumnHeader();
            btnAddUserType = new Button();
            btnDelUserType = new Button();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(3, 9);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(157, 20);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Имя пользователя:";
            // 
            // txbUserName
            // 
            txbUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbUserName.Location = new Point(7, 32);
            txbUserName.Name = "txbUserName";
            txbUserName.Size = new Size(317, 26);
            txbUserName.TabIndex = 1;
            // 
            // txbComputers
            // 
            txbComputers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbComputers.Location = new Point(7, 84);
            txbComputers.Name = "txbComputers";
            txbComputers.Size = new Size(317, 26);
            txbComputers.TabIndex = 3;
            // 
            // lblComputers
            // 
            lblComputers.AutoSize = true;
            lblComputers.Location = new Point(3, 61);
            lblComputers.Margin = new Padding(4, 0, 4, 0);
            lblComputers.Name = "lblComputers";
            lblComputers.Size = new Size(196, 20);
            lblComputers.TabIndex = 2;
            lblComputers.Text = "Компьютеры автовхода:";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChangePassword.Location = new Point(7, 299);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(317, 37);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "Изменить пароль";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(7, 342);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 32);
            btnOK.TabIndex = 9;
            btnOK.Text = "ОК";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(236, 342);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 32);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Location = new Point(7, 113);
            lblUserType.Margin = new Padding(4, 0, 4, 0);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(189, 20);
            lblUserType.TabIndex = 11;
            lblUserType.Text = "Группы пользователей:";
            // 
            // lvUserTypes
            // 
            lvUserTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvUserTypes.Columns.AddRange(new ColumnHeader[] { lvchUserTypeName });
            lvUserTypes.HeaderStyle = ColumnHeaderStyle.None;
            lvUserTypes.Location = new Point(7, 136);
            lvUserTypes.MultiSelect = false;
            lvUserTypes.Name = "lvUserTypes";
            lvUserTypes.Size = new Size(272, 157);
            lvUserTypes.TabIndex = 12;
            lvUserTypes.UseCompatibleStateImageBehavior = false;
            lvUserTypes.View = View.Details;
            // 
            // lvchUserTypeName
            // 
            lvchUserTypeName.Text = "Группа пользователей";
            lvchUserTypeName.Width = 250;
            // 
            // btnAddUserType
            // 
            btnAddUserType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUserType.Location = new Point(285, 136);
            btnAddUserType.Name = "btnAddUserType";
            btnAddUserType.Size = new Size(39, 41);
            btnAddUserType.TabIndex = 13;
            btnAddUserType.Text = "+";
            btnAddUserType.UseVisualStyleBackColor = true;
            btnAddUserType.Click += btnAddUserType_Click;
            // 
            // btnDelUserType
            // 
            btnDelUserType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelUserType.Location = new Point(285, 183);
            btnDelUserType.Name = "btnDelUserType";
            btnDelUserType.Size = new Size(39, 41);
            btnDelUserType.TabIndex = 14;
            btnDelUserType.Text = "-";
            btnDelUserType.UseVisualStyleBackColor = true;
            btnDelUserType.Click += btnDelUserType_Click;
            // 
            // DictionaryShiftStaffUserEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 386);
            Controls.Add(btnDelUserType);
            Controls.Add(btnAddUserType);
            Controls.Add(lvUserTypes);
            Controls.Add(lblUserType);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnChangePassword);
            Controls.Add(txbComputers);
            Controls.Add(lblComputers);
            Controls.Add(txbUserName);
            Controls.Add(lblUserName);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(340, 425);
            Name = "DictionaryShiftStaffUserEdit";
            Text = "DictionaryShiftStaffUserEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbComputers;
        private System.Windows.Forms.Label lblComputers;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Label lblUserType;
        private ListView lvUserTypes;
        private Button btnAddUserType;
        private Button btnDelUserType;
        private ColumnHeader lvchUserTypeName;
    }
}