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
    public partial class DictionaryUsers : JournalAppDataForm
    {
        List<User> Users;
        public DictionaryUsers()
        {
            InitializeComponent();
            FillUserList();
        }

        private void FillUserList()
        {
            lvUsers.Items.Clear();
            using (var db = new DB())
            {
                Users = db.Users.ToList();
                foreach (User usr in Users)
                {
                    var lvi = new ListViewItem();
                    lvi.Text = usr.UserName;
                    var types = String.Join(", ", usr.UserTypes.Select(ut => ut.UserTypeName));

                    lvi.SubItems.Add(types);
                    lvi.SubItems.Add(usr.AutoLogonComputerNames);
                    lvi.Tag = usr;
                    lvUsers.Items.Add(lvi);
                }
            }
        }

        private User GetSelectedUser()
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                return lvUsers.SelectedItems[0].Tag as User;
            }
            return null;
        }

        private void tsmiAddUser_Click(object sender, EventArgs e)
        {
            using (var db = new DB())
            {
                var d = new DictionaryShiftStaffUserEdit(new User(), db);
                if (d.ShowDialog() == DialogResult.OK)
                {
                    db.Users.Add(d.EditUser);
                    db.SaveChanges();

                    FillUserList();
                }
            }
        }

        private void tsmiChangeUser_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null) return;
            using (var db = new DB())
            {
                user = db.Users.FirstOrDefault(u => u.UserID == user.UserID);
                var d = new DictionaryShiftStaffUserEdit(user, db);
                if (d.ShowDialog() == DialogResult.OK)
                {
                    user = d.EditUser;
                    var entity = db.Users.Find(user.UserID);
                    if (entity != null)
                    {
                        db.Entry(entity).CurrentValues.SetValues(user);
                        db.SaveChanges();
                    }
                    FillUserList();
                }
            }
        }

        private void tsmiDeleteUser_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null) return;
            if (MessageBox.Show("Вы действительно хотите удалить пользователя \"" + user.UserName + "\"?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var db = new DB())
                {
                    db.Users.Attach(user);
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                FillUserList();
            }
        }

        private void lvUsers_DoubleClick(object sender, EventArgs e)
        {
            tsmiChangeUser.PerformClick();
        }
    }
}
