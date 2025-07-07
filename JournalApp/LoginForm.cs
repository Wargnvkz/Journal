using JournalDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JournalApp
{
    public partial class LoginForm : Form
    {
        List<User> Users;
        User LoggedUser;
        string ComputerName;
        bool PreventUsersComboxBoxFromEvent = false;
        public LoginForm()
        {
            InitializeComponent();
            Text = $"Вход в систему (v.{AppVersion.GetVersion()})";
            FillLoginUser();
        }

        private void FillLoginUser()
        {
            txbPassword.Text = "";
            cbUsers.Items.Clear();
            ComputerName = System.Environment.MachineName.ToUpper();
            Users = DB.GetUsersAvailableForComputerName(ComputerName);
            Users = Users.OrderBy(u => u.UserName).ToList();
            for (int i = 0; i < Users.Count; i++)
            {
                cbUsers.Items.Add(Users[i].UserName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CheckLogon();
        }

        private void CheckLogon()
        {
            lblLoginError.Text = "";
            lblLoginError.Visible = false;
            if (LoggedUser != null)
            {
                bool allowToLog = false;
                if (LoggedUser.CheckComputerName(ComputerName))
                {
                    allowToLog = true;
                }
                else
                {
                    var hash = DB.Hash(txbPassword.Text);
                    var CheckLoggedUser = DB.CheckUserPassword(LoggedUser.UserName, hash);
                    if (CheckLoggedUser != null)
                    {
                        allowToLog = true;
                    }
                }
                if (allowToLog)
                {
                    lblLoginError.Visible = false;
                    GotoMainForm(LoggedUser);
                }
                else
                {
                    lblLoginError.Visible = true;
                    lblLoginError.Text = "Ошибка: Неверный пароль";
                }
            }
            else
            {
                lblLoginError.Text = "Ошибка: Не выбран пользователь";
                lblLoginError.Visible = true;
            }
        }

        private void GotoMainForm(User user)
        {
            var mainForm = new MainForm(user.UserID);
            this.Hide();
            try
            {
                mainForm?.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillLoginUser();
            this.Show();
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PreventUsersComboxBoxFromEvent) return;
            var ind = cbUsers.SelectedIndex;
            if (ind >= 0)
            {
                LoggedUser = Users[ind];
                txbPassword.Enabled = !(LoggedUser.ComputerNames.Contains(ComputerName));
            }
        }

        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x0D') { e.Handled = true; CheckLogon(); }
        }
    }
}
