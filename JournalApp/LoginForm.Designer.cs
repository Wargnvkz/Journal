namespace JournalApp
{
    partial class LoginForm
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
            btnOK = new Button();
            btnCancel = new Button();
            cbUsers = new ComboBox();
            label1 = new Label();
            lblPassword = new Label();
            txbPassword = new TextBox();
            lblLoginError = new Label();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOK.Location = new Point(18, 127);
            btnOK.Margin = new Padding(4, 5, 4, 5);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(112, 35);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(260, 127);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cbUsers
            // 
            cbUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbUsers.FormattingEnabled = true;
            cbUsers.Location = new Point(145, 16);
            cbUsers.Name = "cbUsers";
            cbUsers.Size = new Size(219, 28);
            cbUsers.TabIndex = 2;
            cbUsers.SelectedIndexChanged += cbUsers_SelectedIndexChanged;
            cbUsers.KeyPress += LoginForm_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 19);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 3;
            label1.Text = "Пользователь:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(14, 62);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(71, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль:";
            // 
            // txbPassword
            // 
            txbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbPassword.Location = new Point(145, 59);
            txbPassword.Name = "txbPassword";
            txbPassword.PasswordChar = '*';
            txbPassword.Size = new Size(219, 26);
            txbPassword.TabIndex = 5;
            txbPassword.KeyPress += LoginForm_KeyPress;
            // 
            // lblLoginError
            // 
            lblLoginError.AutoSize = true;
            lblLoginError.ForeColor = Color.Red;
            lblLoginError.Location = new Point(19, 96);
            lblLoginError.Name = "lblLoginError";
            lblLoginError.Size = new Size(98, 20);
            lblLoginError.TabIndex = 6;
            lblLoginError.Text = "lblLoginError";
            lblLoginError.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 181);
            Controls.Add(lblLoginError);
            Controls.Add(txbPassword);
            Controls.Add(lblPassword);
            Controls.Add(label1);
            Controls.Add(cbUsers);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "LoginForm";
            Text = "Вход в систему";
            KeyPress += LoginForm_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label lblLoginError;
    }
}