﻿using JournalApp.SettingsForms;
using JournalApp.UserControls;
using JournalDB;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JournalApp
{
    public partial class JournalMessages : JournalAppDataForm, IPreparation
    {
        Parameters parameters;
        bool AllowRead = false;
        bool AllowWrite = false;
        bool AllowPin = false;
        protected List<JournalTypeUserTypeRight>? JournalTypeUserTypeRights;
        ThemePalette CurrentPalette = new ThemePalette();
        Shift SelectedStartShift = new Shift().PreviousShift().PreviousShift();
        Shift SelectedEndShiftIncluded = new Shift().NextShift().NextShift();

        int AllowToEditRecordAfterShift = 30;
        int IsAddingDate = 0;
        FilterParameters CurrentFilter = new FilterParameters();
        FilterParameters PinnedFilter = new FilterParameters();
        int? newMsgID;
        int? SavedSplitterDistance;

        private static readonly Font DateLabelFont = new Font(SystemFonts.DefaultFont.FontFamily, 14);
        private static readonly Padding MessagePadding = new Padding(20, 5, 5, 5);
        private static readonly Padding DateLabelMargin = new Padding(10, 10, 10, 10);

        public JournalMessages()
        {
            InitializeComponent();
            SetDefaultSplitterPosition();
            Load += JournalMessages_Load;
        }

        private void JournalMessages_Load(object? sender, EventArgs e)
        {
            dtpSelectedStartDate.Value = SelectedStartShift.AddShift(-10).ShiftStartsAt();
        }

        public void Prepare()
        {
            using (var Database = new DB())
            {
                if (Tag is Parameters parameters)
                {
                    this.parameters = parameters;
                    var res = 0;
                    JournalTypeUserTypeRights = (from u in Database.Users
                                                 from ut in u.UserTypes
                                                 join jtutr in Database.JournalTypeUserTypeRights on ut.UserTypeID equals jtutr.UserTypeID
                                                 where u.UserID == parameters.UserID && jtutr.JournalTypeID == parameters.JournalTypeID
                                                 select jtutr).ToList();
                    JournalTypeUserTypeRights?.FindAll(j => j.JournalTypeID == parameters.JournalTypeID).ForEach(jt => res |= jt.bUserTypeRight);
                    AllowRead = (res & 1) == 1;
                    AllowWrite = (res & 2) == 2;
                    AllowPin = (res & 4) == 4;

                    var jt = Database.JournalTypes.Where(jt => jt.JournalTypeID == parameters.JournalTypeID).FirstOrDefault();
                    if (jt != null)
                    {
                        this.Text = jt.JournalTypeName;
                    }


                    cbFilterShift.DataSource = new[] { new { Shift = "-", N = 0 }, new { Shift = "Смена 1", N = 1 }, new { Shift = "Смена 2", N = 2 }, new { Shift = "Смена 3", N = 3 }, new { Shift = "Смена 4", N = 4 } };
                    cbFilterShift.DisplayMember = "Shift";
                    cbFilterShift.ValueMember = "N";

                    //TODO:Заменить номер журнала на проверку JournalType.ProductionShiftActive
                    if (parameters.ProductionShiftActive)
                    {
                        lblFilterShift.Visible = true;
                        cbFilterShift.Visible = true;
                    }
                    else
                    {
                        lblFilterShift.Visible = false;
                        cbFilterShift.Visible = false;
                    }
                    Refresh();
                }
                btnCreateMessage.Enabled = AllowWrite;
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            var focusedMessage = GetFocused();
            // Сохраняем текущую позицию прокрутки
            int scrollPosition = tlpMessagesCurrent.VerticalScroll.Value;

            this.AutoScaleMode = AutoScaleMode.None;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.PerformAutoScale();

            this.BackColor = CurrentPalette.BackgroundForm;
            splitContainer1.BackColor = CurrentPalette.BackgroundSplitContainer;
            pnlSearchCurrent.BackColor = CurrentPalette.BackgroundSearchPanel;
            tlpMessagesCurrent.BackColor = CurrentPalette.BackgroundList;
            tlpMessagesPermanent.BackColor = CurrentPalette.BackgroundList;

            var now = DateTime.Now;
            using (var Database = new DB())
            {
                var msglist = Database.Messages.Where(msg => msg.JournalTypeID == parameters.JournalTypeID).ToList();
                var msgcurrent = msglist.FindAll(m =>
                    SelectedStartShift.ShiftStartsAt() < m.CreatingDate
                    &&
                    SelectedEndShiftIncluded.ShiftEndsAt() > m.CreatingDate
                    &&
                    (
                        CurrentFilter.UserID > 0
                        ?
                            m.UserID == CurrentFilter.UserID
                        :
                            true
                    )
                    &&
                    (
                        CurrentFilter.ShiftNumber > 0
                        ?
                            m.Shift.GetShiftNumber() == CurrentFilter.ShiftNumber
                        : true
                    )
                    &&
                    (
                        !string.IsNullOrEmpty(CurrentFilter.ContainsText)
                        ?
                            m.MessageText.Contains(CurrentFilter.ContainsText)
                        : true
                    )
                );

                var pinnedSelectedShiftFrom = new Shift(dtpPermanentFrom.Value.Date, false);
                var pinnedSelectedShiftTo = new Shift(dtpPermanentTo.Value.Date, false).NextShift().NextShift();
                List<JournalDB.Message> msgpinned;
                if (!cbFullPinned.Checked)
                {
                    msgpinned = msglist;
                }
                else
                {
                    var ShiftTo = new Shift(dtpPermanentTo.Value.Date, false);
                    var ShiftFrom = new Shift(dtpPermanentFrom.Value.Date, false);

                    msgpinned = msglist.FindAll(m =>
                        ShiftFrom.ShiftStartsAt() < m.CreatingDate
                        &&
                        ShiftTo.ShiftEndsAt() > m.CreatingDate
                        &&
                        (
                            PinnedFilter.UserID > 0
                            ?
                                m.UserID == PinnedFilter.UserID
                            :
                                true
                        )

                        &&
                        (
                            !string.IsNullOrEmpty(PinnedFilter.ContainsText)
                            ?
                                m.MessageText.Contains(PinnedFilter.ContainsText)
                            : true
                        )
                    );
                }
                FillList(tlpMessagesCurrent, msgcurrent, false);
                var pinnedMessages = msgpinned.Where(m => m.IsPinned);
                bool showallMessages = cbFullPinned.Checked;
                var visibleMessages = showallMessages ? pinnedMessages : pinnedMessages.Where(m => m.StartPin <= now && m.StopPin >= now);
                FillList(tlpMessagesPermanent, visibleMessages.ToList(), true);


                cbFilterUser.SelectedIndexChanged -= cbFilterUser_SelectedIndexChanged;
                cbFilterShift.SelectedIndexChanged -= cbFilterShift_SelectedIndexChanged;
                cbFilterUserPinned.SelectedIndexChanged -= cbFilterUserPinned_SelectedIndexChanged;

                Application.DoEvents();
                ResizeLayoutControls();





                //var userIDs = Database.Messages.Select(m => m.UserID).Distinct().ToList();
                //var users = Database.Users.Where(u => userIDs.Contains(u.UserID)).ToList();
                {
                    var users = (from m in Database.Messages
                                 join u in Database.Users on m.UserID equals u.UserID
                                 where m.JournalTypeID == parameters.JournalTypeID
                                 select u).Distinct().ToList();
                    users.Insert(0, new JournalDB.User() { UserID = 0, UserName = "-" });
                    int savedUserID = 0;
                    try
                    {
                        if (cbFilterUser.SelectedValue != null)
                            savedUserID = (int)cbFilterUser.SelectedValue;
                    }
                    catch { }

                    int UserPositionIndex = 0;
                    if (savedUserID != 0)
                    {
                        UserPositionIndex = users.FindIndex(u => u.UserID == savedUserID);
                    }

                    cbFilterUser.DataSource = users;
                    cbFilterUser.DisplayMember = "UserName";
                    cbFilterUser.ValueMember = "UserID";
                    cbFilterUser.SelectedIndex = UserPositionIndex;
                }
                {
                    var users = (from m in Database.Messages
                                 join u in Database.Users on m.UserID equals u.UserID
                                 where m.JournalTypeID == parameters.JournalTypeID && m.IsPinned
                                 select u).Distinct().ToList();
                    users.Insert(0, new JournalDB.User() { UserID = 0, UserName = "-" });
                    int savedUserID = 0;
                    try
                    {
                        if (cbFilterUserPinned.SelectedValue != null)
                            savedUserID = (int)cbFilterUserPinned.SelectedValue;
                    }
                    catch { }

                    int UserPositionIndex = 0;
                    if (savedUserID != 0)
                    {
                        UserPositionIndex = users.FindIndex(u => u.UserID == savedUserID);
                    }
                    cbFilterUserPinned.DataSource = users;
                    cbFilterUserPinned.DisplayMember = "UserName";
                    cbFilterUserPinned.ValueMember = "UserID";
                    cbFilterUserPinned.SelectedIndex = UserPositionIndex;
                }
                cbFilterUser.SelectedIndexChanged += cbFilterUser_SelectedIndexChanged;
                cbFilterShift.SelectedIndexChanged += cbFilterShift_SelectedIndexChanged;
                cbFilterUserPinned.SelectedIndexChanged += cbFilterUserPinned_SelectedIndexChanged;

                tlpMessagesPermanent.PerformLayout();
                tlpMessagesCurrent.PerformLayout();
                // Восстанавливаем позицию прокрутки
                tlpMessagesCurrent.VerticalScroll.Value = Math.Min(scrollPosition, tlpMessagesCurrent.VerticalScroll.Maximum);
                if (newMsgID != null)
                {
                    SetFocused(newMsgID);
                    newMsgID = null;
                }
                else
                {
                    SetFocused(focusedMessage);
                }
            }
        }

        private void ResizeLayoutControls()
        {
            ResizeAll(tlpMessagesCurrent);
            ResizeAll(tlpMessagesPermanent);
        }

        private void SetFocused(int? msgID)
        {
            if (msgID == null) return;
            for (int i = 0; i < tlpMessagesCurrent.Controls.Count; i++)
            {
                if (tlpMessagesCurrent.Controls[i] is MessageRecordControl mc)
                {
                    if (mc.MessageID == msgID)
                    {
                        tlpMessagesCurrent.PerformLayout();
                        tlpMessagesCurrent.ScrollControlIntoView(tlpMessagesCurrent.Controls[i]);

                        tlpMessagesCurrent.Controls[i].Focus();
                        break;
                    }
                }
            }
        }
        private int? GetFocused()
        {
            for (int i = 0; i < tlpMessagesCurrent.Controls.Count; i++)
            {
                if (tlpMessagesCurrent.Controls[i].Focused)
                {
                    if (tlpMessagesCurrent.Controls[i] is MessageRecordControl mc)
                    {
                        return mc.MessageID;
                    }
                }
            }
            return null;
        }
        private void FillList(TableLayoutPanel layoutPanel, List<JournalDB.Message> messagelist, bool pinned)
        {
            var now = DateTime.Now;
            layoutPanel.SuspendLayout();

            // Собираем список текущих MessageID
            var existingMessages = layoutPanel.Controls
                .OfType<MessageRecordControl>()
                .ToDictionary(m => m.MessageID);

            // Контролы, которые будут оставлены
            var usedControls = new HashSet<Control>();

            // Группировка по сменам
            var messageGroups = messagelist
                .Where(m => m.IsPinned == pinned)
                .OrderByDescending(m => m.CreatingDate)
                .GroupBy(m => new { m.Shift.ShiftDate, m.Shift.IsNight });

            // Временная панель для добавления новых контролов
            var newControls = new List<Control>();

            foreach (var msgGroup in messageGroups)
            {
                var shift = new Shift(msgGroup.Key.ShiftDate, msgGroup.Key.IsNight);

                // Добавим заголовок смены
                if (!pinned)
                {
                    var dateLabel = new Label
                    {
                        Text = parameters.ProductionShiftActive
                            ? $"Смена {shift.GetShiftNumber()}: {shift.ShiftDate:dd-MM-yyyy} {(shift.IsNight ? "Н" : "Д")}"
                            : $"Дата: {shift.ShiftDate:dd-MM-yyyy}",
                        BackColor = CurrentPalette.BackgroundDateLabel,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Height = 36,
                        Margin = DateLabelMargin,
                        Font = DateLabelFont,
                        AutoSize = false,
                        //Dock = DockStyle.Top
                    };
                    newControls.Add(dateLabel);
                }

                foreach (var msg in msgGroup)
                {
                    MessageRecordControl mrControl;

                    if (existingMessages.TryGetValue(msg.MessageID, out var existingControl))
                    {
                        // Повторно используем уже существующий
                        mrControl = existingControl;
                    }
                    else
                    {
                        // Новый контрол
                        mrControl = new MessageRecordControl(msg, pinned, CurrentPalette);
                        mrControl.OnDelete += MrControl_OnDeleteRecord;
                        mrControl.OnChange += MrControl_OnChange;
                    }

                    // Обновление свойств
                    var msgShift = new Shift(msg.CreatingDate);
                    var canWrite = msg.UserID == parameters.UserID
                                   && AllowWrite
                                   && (
                                       parameters.ProductionShiftActive
                                       ? msgShift.GetShiftStartDateTime() < now
                                         && msgShift.NextShift().GetShiftStartDateTime().AddMinutes(AllowToEditRecordAfterShift) > now
                                       : msg.CreatingDate.Date == now.Date
                                   );

                    mrControl.ReadOnly = !canWrite;
                    mrControl.AllowedToPin = AllowPin;
                    mrControl.Margin = MessagePadding;

                    newControls.Add(mrControl);
                    usedControls.Add(mrControl); // помечаем как используемый
                }
            }

            // Удаляем контролы, которых больше нет
            foreach (Control ctrl in layoutPanel.Controls.Cast<Control>().ToList())
            {
                if (!usedControls.Contains(ctrl))
                {
                    ctrl.Dispose();
                    layoutPanel.Controls.Remove(ctrl);
                }
            }

            // Очищаем и добавляем все в правильном порядке
            layoutPanel.Controls.Clear();
            layoutPanel.RowCount = 0;
            foreach (var ctrl in newControls)
            {
                layoutPanel.Controls.Add(ctrl, 0, layoutPanel.RowCount++);
            }

            // Обновляем стили строк
            layoutPanel.RowStyles.Clear();
            for (int i = 0; i < layoutPanel.RowCount; i++)
            {
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            layoutPanel.ResumeLayout(true);
        }
        /*
        private void FillList(TableLayoutPanel layoutPanel, List<JournalDB.Message> messagelist, bool Pinned)
        {
            var now = DateTime.Now;
            foreach (Control ctrl in layoutPanel.Controls)
            {
                ctrl.Dispose();
            }
            layoutPanel.Controls.Clear();
            layoutPanel.RowCount = 0;
            //MessageRecordControl LastMsgRec = null;
            var messageShiftGroup = messagelist.Where(m => m.IsPinned == Pinned).OrderByDescending(m => m.CreatingDate).GroupBy(m => new { m.Shift.ShiftDate, m.Shift.IsNight });
            foreach (var msgGroup in messageShiftGroup)
            {
                var shift = new Shift(msgGroup.Key.ShiftDate, msgGroup.Key.IsNight);

                if (!Pinned)
                {
                    var dateLabel = new Label();
                    //TODO:Заменить номер журнала на проверку JournalType.ProductionShiftActive
                    if (parameters.ProductionShiftActive)
                    {
                        dateLabel.Text = $"Смена {shift.GetShiftNumber()}: {shift.ShiftDate:dd-MM-yyyy} {(!shift.IsNight ? "Д" : "Н")}";
                    }
                    else
                    {
                        dateLabel.Text = $"Дата: {shift.ShiftDate:dd-MM-yyyy}";

                    }
                    dateLabel.BackColor = CurrentPalette.BackgroundDateLabel;
                    dateLabel.TextAlign = ContentAlignment.MiddleCenter;
                    dateLabel.Height = 36;// 24;
                    dateLabel.Margin = new Padding(10, 10, 10, 10);
                    dateLabel.Font = new Font(dateLabel.Font.FontFamily, 14);//12
                    layoutPanel.Controls.Add(dateLabel, 0, layoutPanel.RowCount);
                    layoutPanel.RowCount++;
                }
                var msglist = msgGroup.ToList();

                for (int i = 0; i < msglist.Count; i++)
                {
                    var mrControl = new MessageRecordControl(msglist[i].MessageID, Database, Pinned, CurrentPalette);
                    var msgShift = new Shift(msglist[i].CreatingDate);
                    //TODO:Заменить номер журнала на проверку JournalType.ProductionShiftActive
                    //var CanWrite = msglist[i].UserID != parameters.UserID || !AllowWrite || !(msgShift.GetShiftStartDateTime() < now && msgShift.NextShift().GetShiftStartDateTime().AddMinutes(AllowToEditRecordAfterShift) > now);
                    var CanWrite =
                            msglist[i].UserID == parameters.UserID
                        &&
                            AllowWrite
                        &&
                            (
                                parameters.ProductionShiftActive
                                ?
                                    (
                                        msgShift.GetShiftStartDateTime() < now
                                    &&
                                        msgShift.NextShift().GetShiftStartDateTime().AddMinutes(AllowToEditRecordAfterShift) > now
                                    )
                                :
                                msglist[i].CreatingDate.Date == now.Date
                            )
                        ;
                    mrControl.ReadOnly = !CanWrite;
                    mrControl.AllowedToPin = AllowPin;
                    mrControl.OnDelete += MrControl_OnDeleteRecord;
                    mrControl.OnChange += MrControl_OnChange;
                    mrControl.Margin = new Padding(20, 5, 5, 5);
                    layoutPanel.Controls.Add(mrControl, 0, layoutPanel.RowCount);
                    layoutPanel.RowCount++;
                    //if (!CanWrite) LastMsgRec = mrControl;
                }
            }
            for (int i = 0; i < layoutPanel.RowStyles.Count; i++)
            {
                layoutPanel.RowStyles[i].SizeType = SizeType.AutoSize;

            }
            //if (LastMsgRec != null)
            //    LastMsgRec.Focus();
        }
        */
        private void MrControl_OnChange(MessageRecordControl sender, int MessageID)
        {
            Refresh();
        }

        private void btnCreateMessage_Click(object sender, EventArgs e)
        {
            if (!AllowWrite) return;
            using (var Database = new DB())
            {
                var newMsg = new JournalDB.Message() { UserID = parameters.UserID, JournalTypeID = parameters.JournalTypeID, CreatingDate = DateTime.Now };
                Database.Messages.Add(newMsg);
                Database.SaveChanges();
                newMsgID = newMsg.MessageID;
            }
            Refresh();
        }
        private void MrControl_OnDeleteRecord(MessageRecordControl sender, int MessageID)
        {
            using (var Database = new DB())
            {
                var CurrentMessage = Database.Messages.First(m => m.MessageID == MessageID);
                var files = Database.MessageFiles.Where(airf => airf.MessageID == MessageID).ToList();
                for (int i = 0; i < files.Count; i++)
                {
                    try
                    {
                        Database.MessageFiles.Remove(files[i]);
                    }
                    catch { }
                }
                try
                {
                    Database.Messages.Remove(CurrentMessage);
                }
                catch { }
                if (tlpMessagesPermanent.Controls.Contains(sender))
                    tlpMessagesPermanent.Controls.Remove(sender);
                if (tlpMessagesCurrent.Controls.Contains(sender))
                    tlpMessagesCurrent.Controls.Remove(sender);
                Database.ChangeTracker.DetectChanges();
                foreach (var entry in Database.ChangeTracker.Entries<JournalDB.Message>())
                {
                }
                if (Database.Entry(CurrentMessage).State != System.Data.Entity.EntityState.Deleted)
                    Database.Entry(CurrentMessage).State = System.Data.Entity.EntityState.Deleted;
                for (int i = 0; i < files.Count; i++)
                {
                    if (Database.Entry(files[i]).State != System.Data.Entity.EntityState.Deleted)
                        Database.Entry(files[i]).State = System.Data.Entity.EntityState.Deleted;
                }
                Database.SaveChanges();
            }
            Refresh();
        }

        protected List<JournalDB.Message> GetUserMessagesID()
        {
            using (var Database = new DB())
            {
                return Database.Messages.Where(m => m.UserID == parameters.UserID && m.JournalTypeID == parameters.JournalTypeID).ToList();
            }
        }
        protected List<JournalDB.Message> GetPinnedMessagesID()
        {
            using (var Database = new DB())
            {
                return Database.Messages.Where(m => m.UserID == parameters.UserID && m.JournalTypeID == parameters.JournalTypeID).ToList();
            }
        }
        public class Parameters
        {
            public int JournalTypeID;
            public int UserID;
            public bool ProductionShiftActive;
        }

        public void ResizeAll(TableLayoutPanel tlpPanel)
        {
            if (tlpPanel == null) return;
            foreach (Control ctrl in tlpPanel.Controls)
            {
                if (ctrl is MessageRecordControl mrc)
                {
                    mrc.SetControlHeightByCurrectText();
                }
                ctrl.Size = new Size(tlpPanel.Size.Width - ctrl.Margin.Left - ctrl.Margin.Right, ctrl.Size.Height);
            }
        }

        private void tlpMessages_Resize(object sender, EventArgs e)
        {
            if (sender is TableLayoutPanel pnl)
            {
                ResizeAll(pnl);
            }
        }

        private void cbFullPinned_CheckedChanged(object sender, EventArgs e)
        {
            pnlFilterPermanent.Visible = cbFullPinned.Checked;
            dtpPermanentFrom.Value = DateTime.Now.AddDays(-90);
            dtpPermanentTo.Value = DateTime.Now;

            Refresh();
        }

        private void dtpSelectedDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedStartShift = new Shift(dtpSelectedStartDate.Value.Date, false);
            Refresh();
        }

        private void dtpSelectedEndDateInclude_ValueChanged(object sender, EventArgs e)
        {
            SelectedEndShiftIncluded = new Shift(dtpSelectedStartDate.Value.Date, true);
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }


        private void cbFilterShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterShift.SelectedValue != null)
            {
                CurrentFilter.ShiftNumber = (int)cbFilterShift.SelectedValue;
                Refresh();
            }
        }

        private void cbFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterUser.SelectedValue != null)
            {
                CurrentFilter.UserID = (int)cbFilterUser.SelectedValue;
                Refresh();
            }
        }


        internal class FilterParameters
        {
            public int UserID;
            public int ShiftNumber;
            public string ContainsText = string.Empty;
        }

        private void cbPermanentCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPermanentCurrent.Checked)
            {
                SaveSplitterPosition();
                ExpandSplitterPanel2();
            }
            else
            {
                if (IsSplitterPositionSaved())
                    RestoreSplitterPosition();
                else
                {
                    SetDefaultSplitterPosition();
                }

            }
        }

        private void SetDefaultSplitterPosition()
        {
            splitContainer1.SplitterDistance = splitContainer1.ClientSize.Width * 60 / 100;// 200;
        }

        private void SaveSplitterPosition()
        {
            SavedSplitterDistance = splitContainer1.SplitterDistance;

        }
        private void RestoreSplitterPosition()
        {
            splitContainer1.SplitterDistance = SavedSplitterDistance.Value;
            SavedSplitterDistance = null;

        }
        private bool IsSplitterPositionSaved()
        {
            return SavedSplitterDistance != null;
        }
        private void ExpandSplitterPanel2()
        {
            splitContainer1.SplitterDistance = 0;
        }

        private void dtpPermanentFrom_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dtpPermanentTo_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void cbFilterUserPinned_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterUserPinned.SelectedValue != null)
            {
                PinnedFilter.UserID = (int)cbFilterUserPinned.SelectedValue;
                Refresh();
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ResizeLayoutControls();
        }

        private void cbPermanentCurrent_Resize(object sender, EventArgs e)
        {
            ResizeLayoutControls();
        }

        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            ResizeLayoutControls();
        }
    }

}
