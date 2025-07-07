using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JournalDB;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JournalApp.UserControls
{
    public partial class MessageRecordControl : UserControl
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);
        // Импорт SendMessage из user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        // Константа для WM_MOUSEWHEEL
        private const int WM_MOUSEWHEEL = 0x020A;


        public delegate void OnMessageRecordEvent(MessageRecordControl sender, JournalDB.Message CurrentMessage);
        public int MessageID { get; private set; }
        public JournalDB.Message CurrentMessage { get; private set; }
        DB Database;
        private ImageList imageList;
        bool isRefreshing = false;
        bool _ReadOnly = false;
        public event OnMessageRecordEvent OnDelete;
        public event OnMessageRecordEvent OnChange;
        ThemePalette CurrentPalette;
        public bool ReadOnly
        {
            get => _ReadOnly;
            set
            {
                _ReadOnly = value;
                VisualizeReadonlyStatus(_ReadOnly);
                Refresh();
            }
        }
        private bool _AllowedToPin;
        public bool AllowedToPin
        {
            get => _AllowedToPin;
            set
            {
                _AllowedToPin = value;
                VisualizePinStatus(_AllowedToPin);
                Refresh();
            }
        }
        public MessageRecordControl(int messageID, DB database, bool isPinned, ThemePalette palette)
        {
            InitializeComponent();
            MessageID = messageID;
            Database = database;
            CurrentMessage = Database.Messages.Where(air => air.MessageID == MessageID).FirstOrDefault();
            CurrentPalette = palette;
            txbText.Font = isPinned ? palette.PinnedMessageFont : palette.MessageFont;
            txbText.ForeColor = palette.TextPrimary;
            txbText.GotFocus += TxbText_GotFocus;
            txbText.MouseWheel += TxbText_MouseWheel;
            lblUser.ForeColor = palette.TextSecondary;
            lblDateTimeCreate.ForeColor = palette.TextSecondary;
            lblUser.Font = palette.SecondaryTextFont;
            lblDateTimeCreate.Font = palette.SecondaryTextFont;
            BackColor = isPinned ? palette.BackgroundPinnedMessage : palette.BackgroundMessage;
            Refresh();
        }

        private void TxbText_MouseWheel(object? sender, MouseEventArgs e)
        {
            // Передаём событие родителю (UserControl или TableLayoutPanel)
            if (this.Parent != null)
            {
                // Формируем параметры для WM_MOUSEWHEEL
                IntPtr wParam = (IntPtr)(((e.Delta << 16) | ((int)Control.ModifierKeys << 8))); // Delta и модификаторы
                IntPtr lParam = (IntPtr)(e.X | (e.Y << 16)); // Координаты мыши

                // Отправляем сообщение родителю (TableLayoutPanel)
                SendMessage(this.Parent.Handle, WM_MOUSEWHEEL, wParam, lParam);
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            isRefreshing = true;
            try
            {
                if (CurrentMessage == null) return;
                var userrec = Database.Users.Where(u => u.UserID == CurrentMessage.UserID).FirstOrDefault();
                var username = userrec?.UserName ?? $"Неизвестно(UserID={CurrentMessage.UserID})";
                lblUser.Text = username;
                txbText.Text = CurrentMessage.MessageText;
                lblDateTimeCreate.Text = CurrentMessage.CreatingDate.ToString("dd-MM-yyyy HH\\:mm\\:ss");
                cbPin.Checked = CurrentMessage.IsPinned;
                imageList = new ImageList
                {
                    ImageSize = new Size(32, 32) // Размер иконок
                };
                lvFiles.Items.Clear();
                lvFiles.LargeImageList = imageList; // Привязываем ImageList к ListView
                var files = Database.MessageFiles.Where(airf => airf.MessageID == MessageID).ToList();
                for (int i = 0; i < files.Count(); i++)
                {
                    var fileName = String.IsNullOrWhiteSpace(files[i].Filename) ? $"{i}.jpg" : files[i].Filename;
                    Icon fileIcon = FileIconHelper.GetIconByExtension(Path.GetExtension(fileName));// Icon.ExtractAssociatedIcon(fileName);
                    if (fileIcon != null)
                    {
                        imageList.Images.Add(fileName, fileIcon);
                    }
                    var lvi = new ListViewItem()
                    {
                        Text = fileName,
                        ImageKey = fileName
                    };
                    lvi.Tag = files[i].MessageFileID;
                    lvFiles.Items.Add(lvi);
                }
                SetElementsPosition();

            }
            finally
            {
                isRefreshing = false;
            }

        }
        protected void SetElementsPosition()
        {
            /*if (lvFiles.Items.Count > 0)
            {
                lvFiles.Visible = true;
                txbText.Size = new Size(txbText.Size.Width, lvFiles.Top - txbText.Top - 7);
            }
            else
            {
                lvFiles.Visible = false;
                txbText.Size = new Size(txbText.Size.Width, this.ClientSize.Height - txbText.Top - 5);
            }*/
        }

        private void lvFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (ReadOnly) return;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                foreach (string filePath in files)
                {
                    using (var file = File.OpenRead(filePath))
                    {
                        var newFile = new JournalDB.MessageFile() { MessageID = MessageID };
                        var data = new byte[file.Length];
                        file.Read(data, 0, data.Length);
                        newFile.Data = data;
                        newFile.Filename = Path.GetFileName(filePath);
                        Database.MessageFiles.Add(newFile);
                        Database.ChangeTracker.DetectChanges();
                        foreach (var entry in Database.ChangeTracker.Entries<JournalDB.MessageFile>())
                        {
                            //Console.WriteLine($"Состояние: {entry.State}"); // Должно быть Added
                        }
                        if (Database.Entry(newFile).State != System.Data.Entity.EntityState.Added)
                            Database.Entry(newFile).State = System.Data.Entity.EntityState.Added;
                        Database.SaveChanges();
                    }
                }
                Refresh();
            }

        }

        private void lvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (ReadOnly) return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Разрешаем копирование файлов
            }

        }

        private void txbText_TextChanged(object sender, EventArgs e)
        {
            // Вычисляем необходимый размер для текста
            SetControlHeightByCurrectText();
            if (ReadOnly) return;
            if (!isRefreshing)
            {
                CurrentMessage.MessageText = txbText.Text;
                Database.ChangeTracker.DetectChanges();
                foreach (var entry in Database.ChangeTracker.Entries<JournalDB.MessageFile>())
                {
                }
                if (Database.Entry(CurrentMessage).State != System.Data.Entity.EntityState.Modified)
                    Database.Entry(CurrentMessage).State = System.Data.Entity.EntityState.Modified;
                Database.SaveChanges();
                Refresh();

            }
        }

        public void SetControlHeightByCurrectText()
        {
            Size size = TextRenderer.MeasureText(txbText.Text, txbText.Font, new Size((int)(txbText.ClientSize.Width * 0.9), int.MaxValue), TextFormatFlags.WordBreak);
            txbText.Height = Math.Max(size.Height, 48);
            this.Height = txbText.Top + txbText.Height + 24;
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0) return; // Если ничего не выбрано, выходим

            ListViewItem item = lvFiles.SelectedItems[0];
            string fileName = item.Text; // Имя файла (из базы)
            int fileID = (int)item.Tag; // Имя файла (из базы)

            // Получаем файл из базы
            JournalDB.MessageFile fileData = Database.MessageFiles
                .FirstOrDefault(f => f.MessageFileID == fileID);

            if (fileData == null)
            {
                MessageBox.Show("Файл не найден в базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создаём временный файл с нужным расширением
            string tempPath = Path.Combine(Path.GetTempPath(), fileName);
            if (File.Exists(tempPath))
            {
                try
                {
                    File.Delete(tempPath);
                }
                catch
                {
                    tempPath = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(tempPath));
                }
            }
            File.WriteAllBytes(tempPath, fileData.Data);

            // Открываем его через ассоциированное приложение
            try
            {
                Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VisualizeReadonlyStatus(bool ReadOnly)
        {
            if (ReadOnly)
            {
                txbText.ReadOnly = true;
                txbText.BackColor = this.BackColor;
                txbText.BorderStyle = BorderStyle.None;
                lvFiles.BackColor = this.BackColor;
                lvFiles.BorderStyle = BorderStyle.None;
                btnDelete.Visible = false;
                tsmiDeleteFile.Enabled = false;
            }
            else
            {
                txbText.ReadOnly = false;
                txbText.BackColor = SystemColors.Window;
                txbText.BorderStyle = BorderStyle.FixedSingle;
                lvFiles.BackColor = this.BackColor;
                lvFiles.BorderStyle = BorderStyle.None;
                btnDelete.Visible = true;
                tsmiDeleteFile.Enabled = true;

            }
        }

        private void VisualizePinStatus(bool allowedToPin)
        {
            if (allowedToPin)
            {
                tsmiPinMessage.Enabled = true;
                cbPin.Visible = true;
            }
            else
            {
                tsmiPinMessage.Enabled = false;
                cbPin.Visible = false;

            }
        }
        private void TxbText_GotFocus(object? sender, EventArgs e)
        {
            if (_ReadOnly)
            {
                HideCaret(txbText.Handle);
                txbText.SelectionLength = 0;
                txbText.SelectionStart = 0;
            }
            else
            {
                ShowCaret(txbText.Handle);
                txbText.SelectionLength = 0;
                txbText.SelectionStart = txbText.Text.Length;
            }

        }

        public new void Focus()
        {
            if (!_ReadOnly)
                txbText.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_ReadOnly) return;
            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтвержение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OnDelete(this, CurrentMessage);
                Refresh();
            }
        }

        private void lvFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (_ReadOnly) return;
                DeleteSelectedFile();
            }
        }
        private void DeleteSelectedFile()
        {
            if (_ReadOnly) return;
            if (lvFiles.SelectedItems == null) return;
            var selectedFile = lvFiles.SelectedItems[0];
            if (MessageBox.Show($"Вы действительно хотите удалить файл {selectedFile.Text}", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var fileID = (int)selectedFile.Tag;
                var file = Database.MessageFiles.Local.Where(e => e.MessageFileID == fileID).FirstOrDefault();
                if (file == null)
                {
                    file = new JournalDB.MessageFile() { MessageFileID = fileID };
                    Database.MessageFiles.Attach(file);
                }
                Database.MessageFiles.Remove(file);
                Database.SaveChanges();
                Refresh();
            }
        }

        private void lvFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvFiles.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    cmsFiles.Show(Cursor.Position);
                }
            }
        }

        private void tsmiDeleteFile_Click(object sender, EventArgs e)
        {
            if (_ReadOnly) return;
            DeleteSelectedFile();
        }

        private void tsmiPinMessage_Click(object sender, EventArgs e)
        {
            PinMessage();

        }

        private void cbPin_Click(object sender, EventArgs e)
        {
            PinMessage();
        }

        private void PinMessage()
        {
            var pinForm = new PinMessageForm();
            pinForm.PinParameters = new PinMessageForm.PinnedMessageParameters()
            {
                IsPinned = CurrentMessage.IsPinned,
                StartPin = CurrentMessage.StartPin,
                StopPin = CurrentMessage.StopPin
            };
            if (pinForm.ShowDialog() == DialogResult.OK)
            {
                CurrentMessage.IsPinned = pinForm.PinParameters.IsPinned;
                CurrentMessage.StartPin = pinForm.PinParameters.StartPin;
                CurrentMessage.StopPin = pinForm.PinParameters.StopPin;
                Database.SaveChanges();
                OnChange(this, CurrentMessage);
                Refresh();
            }
        }

        private void MessageRecordControl_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, CurrentPalette.MessageBorderColor, CurrentPalette.MessageBorderStyle);// ButtonBorderStyle.Solid);
        }

        private void FreeResources()
        {
            txbText.GotFocus -= TxbText_GotFocus;
            txbText.MouseWheel -= TxbText_MouseWheel;
        }

    }

    public static class FileIconHelper
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        private const uint SHGFI_ICON = 0x100; // Получить иконку
        private const uint SHGFI_USEFILEATTRIBUTES = 0x10; // Использовать расширение вместо реального файла

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public static Icon GetIconByExtension(string extension)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImg = SHGetFileInfo(extension, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES);

            if (hImg != IntPtr.Zero)
            {
                return Icon.FromHandle(shinfo.hIcon);
            }
            return SystemIcons.Application; // Если иконку не нашли, даём стандартную
        }
    }
}
