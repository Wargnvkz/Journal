using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JournalDB;

namespace JournalApp.SettingsForms
{
    public partial class DictionaryShiftStaffUserEdit : Form
    {
        private User _User;
        private DB db;
        public User EditUser
        {
            get
            {
                GetData();
                return _User;
            }
            set
            {
                _User = value;
                FillData();
                FillUserTypes();
            }
        }
        public DictionaryShiftStaffUserEdit(User user, DB db)
        {
            InitializeComponent();
            if (user == null)
            {
                EditUser = new User();
            }
            else
            {
                EditUser = user;
            }

            this.db = db;
        }

        public void FillData()
        {
            txbUserName.Text = _User.UserName;
            txbComputers.Text = _User.AutoLogonComputerNames;
        }

        protected void FillUserTypes()
        {
            lvUserTypes.Items.Clear();
            foreach (var ut in _User.UserTypes)
            {
                lvUserTypes.Items.Add(ut.UserTypeName);
            }
        }
        public void GetData()
        {
            _User.UserName = txbUserName.Text;
            _User.AutoLogonComputerNames = txbComputers.Text;

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var password = "";
            if (Prompt.ShowDialog(ref password, "Новый пароль:", "Изменение пароля", true))
            {
                _User.PasswordHash = DB.Hash(password);
            }

        }

        private void btnAddUserType_Click(object sender, EventArgs e)
        {
            var userTypeSelectForm = new DictionaryPlainList();
            userTypeSelectForm.Prepare(new DictionaryPlainList.Parameters() { Caption = "Группы пользователей", Context = db, TypeName = "JournalDB.UserType", SelectMode = true });
            userTypeSelectForm.ShowDialog();
            if (userTypeSelectForm.SelectedResult != null)
            {
                var result = (JournalDB.UserType)userTypeSelectForm.SelectedResult;
                var usertype = db.UserTypes.Where(ut => ut.UserTypeID == result.UserTypeID).FirstOrDefault();
                if (usertype != null)
                    _User.UserTypes.Add(usertype);
                FillUserTypes();
            }

        }

        private void btnDelUserType_Click(object sender, EventArgs e)
        {
            List<UserType> userTypes = new List<UserType>();
            foreach (int index in lvUserTypes.SelectedIndices)
            {
                userTypes.Add(_User.UserTypes[index]);
            }
            foreach (UserType ut in userTypes)
            {
                _User.UserTypes.Remove(ut);
            }
            FillUserTypes();
        }


    }
}
