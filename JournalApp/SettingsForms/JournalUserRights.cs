using JournalDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalApp.SettingsForms
{
    public partial class JournalUserRights : JournalAppDataForm
    {
        DB db;
        public JournalUserRights()
        {
            InitializeComponent();
            db = new DB();
            FillData();
        }

        public void FillData()
        {
            cbJournalTypes.ValueMember = "JournalTypeID";
            cbJournalTypes.DisplayMember = "JournalTypeName";
            cbJournalTypes.DataSource = db.JournalTypes.ToList();
            cbUserTypes.ValueMember = "UserTypeID";
            cbUserTypes.DisplayMember = "UserTypeName";
            cbUserTypes.DataSource = db.UserTypes.ToList();
        }

        private void JournalUserRights_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
            this.Dispose();
        }
        private void ReadRights(int UserTypeID, int JournalTypeID)
        {
            var recRights = db.JournalTypeUserTypeRights.Where(r => r.UserTypeID == UserTypeID && r.JournalTypeID == JournalTypeID).FirstOrDefault();
            int Rights = 0;
            if (recRights != null) Rights = recRights.bUserTypeRight;
            cbReadRight.Checked = (Rights & 1) == 1;
            cbWriteRight.Checked = (Rights & 2) == 2;
            cbPinRight.Checked = (Rights & 4) == 4;
        }
        private void SetRights(int UserTypeID, int JournalTypeID)
        {
            int Rights = (cbReadRight.Checked ? 1 : 0) | (cbWriteRight.Checked ? 1 : 0) << 1 | (cbPinRight.Checked ? 1 : 0) << 2;
            var recRights = db.JournalTypeUserTypeRights.Where(r => r.UserTypeID == UserTypeID && r.JournalTypeID == JournalTypeID).FirstOrDefault();
            if (recRights != null)
            {
                recRights.bUserTypeRight = Rights;
                db.SaveChanges();
            }
            else
            {
                db.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { UserTypeID = UserTypeID, JournalTypeID = JournalTypeID, bUserTypeRight = Rights });
                db.SaveChanges();
            }
        }

        private void btnSetRights_Click(object sender, EventArgs e)
        {
            SetRights((int)cbUserTypes.SelectedValue, (int)cbJournalTypes.SelectedValue);
        }

        private void cbUserTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUserTypes.SelectedItem == null) return;
            if (cbJournalTypes.SelectedItem == null) return;
            ReadRights((int)cbUserTypes.SelectedValue, (int)cbJournalTypes.SelectedValue);
        }

        private void cbJournalTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUserTypes.SelectedItem == null) return;
            if (cbJournalTypes.SelectedItem == null) return;
            ReadRights((int)cbUserTypes.SelectedValue, (int)cbJournalTypes.SelectedValue);
        }
    }
}
