using JournalApp.SettingsForms;
using JournalApp.UserControls;
using JournalDB;
using System.Data.Entity;

namespace JournalApp
{
    public partial class MainForm : Form
    {
        int LoggedUserID;
        FormData CurrentData = new FormData();
        Shift StartShift = new Shift();
        public MainForm(int UserID)
        {
            InitializeComponent();
            using (var db = new DB())
            {
                LoggedUserID = UserID;
                var LoggedUser = db.Users.Where(u => u.UserID == UserID).First();
                CurrentData.CurrentUserID = UserID;
                if (LoggedUser != null && LoggedUser.UserTypes != null && LoggedUser.UserTypes.Count > 0)
                    tsmiSettings.Visible = (LoggedUser.UserTypes?.Count(ut => ut.UserTypeID == 1) ?? 0) > 0;
                else
                    tsmiSettings.Visible = false;
            }
            AddAvailableJournals();
            AutoScaleMode = AutoScaleMode.Font;
        }

        private void ShowNewForm<T>(object data = null) where T : JournalAppDataForm, new()
        {
            this.IsMdiContainer = true;
            CloseWindow<T>();
            OpenWindow<T>(data);
        }

        private void CloseWindow<T>() where T : JournalAppDataForm, new()
        {
            foreach (var form in this.MdiChildren)
            {
                if (form is T)
                {
                    RemoveWindowMenuElement(form);
                    form.Close();
                }
            }
        }
        private void OpenWindow<T>(object data = null) where T : JournalAppDataForm, new()
        {
            var newForm = new T();
            newForm.Tag = data;
            newForm.TopLevel = false;
            var iDictPrep = newForm as IPreparation;
            if (iDictPrep != null)
                iDictPrep.Prepare();
            //newForm.SetCurrentData(CurrentData);
            newForm.MdiParent = this;
            newForm.Show();
            newForm.WindowState = FormWindowState.Normal;
            newForm.WindowState = FormWindowState.Maximized;
            newForm.FormClosed += ChildForm_FormClosed;
            AddWindowMenuElement(newForm);
        }

        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveWindowMenuElement(sender as Form);
        }

        private void AddWindowMenuElement(Form form)
        {
            var newItem = new ToolStripMenuItem(form.Text);
            newItem.Click += NewItem_Click;
            newItem.Tag = form;
            tsmiOpenWindows.DropDownItems.Add(newItem);
        }

        private void RemoveWindowMenuElement(Form form)
        {
            List<ToolStripMenuItem> toRemove = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem mi in tsmiOpenWindows.DropDownItems)
            {
                if (mi.Tag == form) toRemove.Add(mi);
            }
            foreach (var mi in toRemove)
                tsmiOpenWindows.DropDownItems.Remove(mi);
        }
        private void NewItem_Click(object sender, EventArgs e)
        {
            var form = (Form)((ToolStripMenuItem)sender).Tag;
            form.BringToFront();
            form.Focus();
        }

        private void tsmiJournalTypes_Click(object sender, EventArgs e)
        {
            ShowNewForm<DictionaryPlainList>(new DictionaryPlainList.Parameters() { Caption = "Типы журналов", TypeName = "JournalDB.JournalType" });
        }

        private void tsmiUserTypes_Click(object sender, EventArgs e)
        {
            ShowNewForm<DictionaryPlainList>(new DictionaryPlainList.Parameters() { Caption = "Группы пользователей", TypeName = "JournalDB.UserType" });

        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            ShowNewForm<DictionaryUsers>();
        }

        private void tsmiUserRights_Click(object sender, EventArgs e)
        {
            //ShowNewForm<DictionaryPlainList>(new DictionaryPlainList.Parameters() { Caption = "Права групп пользователей в журналах", TypeName = "JournalDB.JournalTypeUserTypeRight" });
            ShowNewForm<JournalUserRights>();
            //var jur = new JournalUserRights();
            //jur.Show();
        }

        private void AddAvailableJournals()
        {
            using (var db = new DB())
            {
                var JournalTypeUserTypeRights = (from u in db.Users
                                                 from ut in u.UserTypes
                                                 join jtutr in db.JournalTypeUserTypeRights on ut.UserTypeID equals jtutr.UserTypeID
                                                 where u.UserID == CurrentData.CurrentUserID
                                                 select jtutr).ToList();
                var journalTypeToRights = new Dictionary<int, int>();
                var journalTypeGroup = JournalTypeUserTypeRights.GroupBy(j => j.JournalTypeID);
                foreach (var journalType in journalTypeGroup)
                {
                    var journalTypeID = journalType.Key;
                    var jtRight = 0;
                    foreach (var userTypeRight in journalType.ToList())
                    {
                        jtRight |= userTypeRight.bUserTypeRight;
                    }
                    journalTypeToRights.Add(journalTypeID, jtRight);
                }
                var allowedJournals = journalTypeToRights.Where(kv => (kv.Value & 1) == 1).Select(j => j.Key).ToList();

                var JournalTypeList = db.JournalTypes.Where(jt => allowedJournals.Contains(jt.JournalTypeID)).ToList();
                var LoggedUser = db.Users.Where(u => u.UserID == LoggedUserID).First();
                foreach (var journalType in JournalTypeList)
                {
                    var newMenu = new ToolStripMenuItem();
                    newMenu.Tag = journalType.JournalTypeID;
                    newMenu.Text = journalType.JournalTypeName;
                    newMenu.Click += JournalTypeMenu_Click;
                    tsmiJournalList.DropDownItems.Add(newMenu);
                }
            }
        }

        private void JournalTypeMenu_Click(object? sender, EventArgs e)
        {
            var tsmiJournal = sender as ToolStripMenuItem;
            if (tsmiJournal != null)
            {
                var JournalTypeID = (int)tsmiJournal.Tag;
                //TODO: Открыть окно сообщений этого журнала
                ShowNewForm<JournalMessages>(new JournalMessages.Parameters() { UserID = CurrentData.CurrentUserID, JournalTypeID = JournalTypeID });
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (StartShift < new Shift())
            {
                if ((DateTime.Now - StartShift.ShiftEndsAt()).TotalMinutes > 30)
                {
                    Close();
                }
            }
        }
    }
}
