namespace JournalApp.UserControls
{
    partial class MessageRecordControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                FreeResources();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txbText = new TextBox();
            lvFiles = new ListView();
            lblUser = new Label();
            btnDelete = new Button();
            lblDateTimeCreate = new Label();
            cmsFiles = new ContextMenuStrip(components);
            tsmiDeleteFile = new ToolStripMenuItem();
            cmsMessage = new ContextMenuStrip(components);
            tsmiPinMessage = new ToolStripMenuItem();
            cbPin = new CheckBox();
            cmsFiles.SuspendLayout();
            cmsMessage.SuspendLayout();
            SuspendLayout();
            // 
            // txbText
            // 
            txbText.AllowDrop = true;
            txbText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txbText.Location = new Point(4, 24);
            txbText.Margin = new Padding(4, 3, 4, 3);
            txbText.Multiline = true;
            txbText.Name = "txbText";
            txbText.Size = new Size(818, 95);
            txbText.TabIndex = 0;
            txbText.TextChanged += txbText_TextChanged;
            txbText.DragDrop += lvFiles_DragDrop;
            txbText.DragEnter += lvFiles_DragEnter;
            // 
            // lvFiles
            // 
            lvFiles.AllowDrop = true;
            lvFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lvFiles.Location = new Point(830, 3);
            lvFiles.Margin = new Padding(4, 3, 4, 3);
            lvFiles.MultiSelect = false;
            lvFiles.Name = "lvFiles";
            lvFiles.Size = new Size(301, 116);
            lvFiles.TabIndex = 1;
            lvFiles.UseCompatibleStateImageBehavior = false;
            lvFiles.DragDrop += lvFiles_DragDrop;
            lvFiles.DragEnter += lvFiles_DragEnter;
            lvFiles.DoubleClick += lvFiles_DoubleClick;
            lvFiles.KeyUp += lvFiles_KeyUp;
            lvFiles.MouseClick += lvFiles_MouseClick;
            // 
            // lblUser
            // 
            lblUser.Font = new Font("Microsoft Sans Serif", 12F);
            lblUser.Location = new Point(4, 1);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(246, 20);
            lblUser.TabIndex = 3;
            lblUser.Text = "-";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(1098, 1);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(28, 28);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "✕🗑️";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblDateTimeCreate
            // 
            lblDateTimeCreate.AutoSize = true;
            lblDateTimeCreate.Font = new Font("Microsoft Sans Serif", 12F);
            lblDateTimeCreate.Location = new Point(258, 1);
            lblDateTimeCreate.Margin = new Padding(4, 0, 4, 0);
            lblDateTimeCreate.Name = "lblDateTimeCreate";
            lblDateTimeCreate.Size = new Size(14, 20);
            lblDateTimeCreate.TabIndex = 6;
            lblDateTimeCreate.Text = "-";
            lblDateTimeCreate.Visible = false;
            // 
            // cmsFiles
            // 
            cmsFiles.Items.AddRange(new ToolStripItem[] { tsmiDeleteFile });
            cmsFiles.Name = "contextMenuStrip1";
            cmsFiles.Size = new Size(119, 26);
            // 
            // tsmiDeleteFile
            // 
            tsmiDeleteFile.Name = "tsmiDeleteFile";
            tsmiDeleteFile.Size = new Size(118, 22);
            tsmiDeleteFile.Text = "Удалить";
            tsmiDeleteFile.Click += tsmiDeleteFile_Click;
            // 
            // cmsMessage
            // 
            cmsMessage.Items.AddRange(new ToolStripItem[] { tsmiPinMessage });
            cmsMessage.Name = "cmsMessage";
            cmsMessage.Size = new Size(223, 26);
            // 
            // tsmiPinMessage
            // 
            tsmiPinMessage.Name = "tsmiPinMessage";
            tsmiPinMessage.Size = new Size(222, 22);
            tsmiPinMessage.Text = "Закрепление сообщения...";
            tsmiPinMessage.Click += tsmiPinMessage_Click;
            // 
            // cbPin
            // 
            cbPin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbPin.Appearance = Appearance.Button;
            cbPin.Font = new Font("Segoe UI", 12F);
            cbPin.Location = new Point(1064, 1);
            cbPin.Name = "cbPin";
            cbPin.Size = new Size(27, 28);
            cbPin.TabIndex = 7;
            cbPin.Text = "📌";
            cbPin.TextAlign = ContentAlignment.MiddleCenter;
            cbPin.UseVisualStyleBackColor = true;
            cbPin.Click += cbPin_Click;
            // 
            // MessageRecordControl
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ContextMenuStrip = cmsMessage;
            Controls.Add(cbPin);
            Controls.Add(lblDateTimeCreate);
            Controls.Add(btnDelete);
            Controls.Add(lblUser);
            Controls.Add(lvFiles);
            Controls.Add(txbText);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(466, 2);
            Name = "MessageRecordControl";
            Size = new Size(1130, 125);
            DragDrop += lvFiles_DragDrop;
            DragEnter += lvFiles_DragEnter;
            Paint += MessageRecordControl_Paint;
            cmsFiles.ResumeLayout(false);
            cmsMessage.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txbText;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblDateTimeCreate;
        private System.Windows.Forms.ContextMenuStrip cmsFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteFile;
        private ContextMenuStrip cmsMessage;
        private ToolStripMenuItem tsmiPinMessage;
        private CheckBox cbPin;
    }
}
