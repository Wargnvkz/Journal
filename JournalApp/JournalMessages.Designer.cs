namespace JournalApp
{
    partial class JournalMessages
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
            components = new System.ComponentModel.Container();
            pnlSplit = new Panel();
            splitContainer1 = new SplitContainer();
            tlpMessagesCurrent = new TableLayoutPanel();
            pnlSearchCurrent = new Panel();
            lblFilterShift = new Label();
            lblFiterUser = new Label();
            cbFilterShift = new ComboBox();
            cbFilterUser = new ComboBox();
            lblFilterDashCurrent = new Label();
            dtpSelectedEndDateInclude = new DateTimePicker();
            dtpSelectedStartDate = new DateTimePicker();
            tlpMessagesPermanent = new TableLayoutPanel();
            pnlSearchPermanent = new Panel();
            pnlFilterPermanent = new Panel();
            dtpPermanentFrom = new DateTimePicker();
            lblFilterDashPinnedCaption = new Label();
            cbFilterUserPinned = new ComboBox();
            lblFilterUserCaption = new Label();
            dtpPermanentTo = new DateTimePicker();
            cbFullPinned = new CheckBox();
            btnCreateMessage = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            cbPermanentCurrent = new CheckBox();
            pnlSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlSearchCurrent.SuspendLayout();
            pnlSearchPermanent.SuspendLayout();
            pnlFilterPermanent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSplit
            // 
            pnlSplit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSplit.Controls.Add(splitContainer1);
            pnlSplit.Location = new Point(0, 38);
            pnlSplit.Name = "pnlSplit";
            pnlSplit.Size = new Size(1282, 480);
            pnlSplit.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(tlpMessagesCurrent);
            splitContainer1.Panel1.Controls.Add(pnlSearchCurrent);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(tlpMessagesPermanent);
            splitContainer1.Panel2.Controls.Add(pnlSearchPermanent);
            splitContainer1.Size = new Size(1282, 480);
            splitContainer1.SplitterDistance = 936;
            splitContainer1.SplitterWidth = 8;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            splitContainer1.Resize += splitContainer1_Resize;
            // 
            // tlpMessagesCurrent
            // 
            tlpMessagesCurrent.AutoScroll = true;
            tlpMessagesCurrent.BackColor = SystemColors.ControlDarkDark;
            tlpMessagesCurrent.ColumnCount = 1;
            tlpMessagesCurrent.ColumnStyles.Add(new ColumnStyle());
            tlpMessagesCurrent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMessagesCurrent.Dock = DockStyle.Fill;
            tlpMessagesCurrent.Location = new Point(0, 71);
            tlpMessagesCurrent.Name = "tlpMessagesCurrent";
            tlpMessagesCurrent.RowCount = 1;
            tlpMessagesCurrent.RowStyles.Add(new RowStyle(SizeType.Absolute, 306F));
            tlpMessagesCurrent.Size = new Size(934, 407);
            tlpMessagesCurrent.TabIndex = 1;
            tlpMessagesCurrent.Resize += tlpMessages_Resize;
            // 
            // pnlSearchCurrent
            // 
            pnlSearchCurrent.BackColor = SystemColors.Control;
            pnlSearchCurrent.Controls.Add(lblFilterShift);
            pnlSearchCurrent.Controls.Add(lblFiterUser);
            pnlSearchCurrent.Controls.Add(cbFilterShift);
            pnlSearchCurrent.Controls.Add(cbFilterUser);
            pnlSearchCurrent.Controls.Add(lblFilterDashCurrent);
            pnlSearchCurrent.Controls.Add(dtpSelectedEndDateInclude);
            pnlSearchCurrent.Controls.Add(dtpSelectedStartDate);
            pnlSearchCurrent.Dock = DockStyle.Top;
            pnlSearchCurrent.Location = new Point(0, 0);
            pnlSearchCurrent.Name = "pnlSearchCurrent";
            pnlSearchCurrent.Size = new Size(934, 71);
            pnlSearchCurrent.TabIndex = 2;
            // 
            // lblFilterShift
            // 
            lblFilterShift.AutoSize = true;
            lblFilterShift.Location = new Point(7, 44);
            lblFilterShift.Name = "lblFilterShift";
            lblFilterShift.Size = new Size(46, 15);
            lblFilterShift.TabIndex = 6;
            lblFilterShift.Text = "Смена:";
            // 
            // lblFiterUser
            // 
            lblFiterUser.AutoSize = true;
            lblFiterUser.Location = new Point(186, 44);
            lblFiterUser.Name = "lblFiterUser";
            lblFiterUser.Size = new Size(87, 15);
            lblFiterUser.TabIndex = 5;
            lblFiterUser.Text = "Пользователь:";
            // 
            // cbFilterShift
            // 
            cbFilterShift.FormattingEnabled = true;
            cbFilterShift.Location = new Point(59, 41);
            cbFilterShift.Name = "cbFilterShift";
            cbFilterShift.Size = new Size(121, 23);
            cbFilterShift.TabIndex = 4;
            // 
            // cbFilterUser
            // 
            cbFilterUser.FormattingEnabled = true;
            cbFilterUser.Location = new Point(279, 41);
            cbFilterUser.Name = "cbFilterUser";
            cbFilterUser.Size = new Size(218, 23);
            cbFilterUser.TabIndex = 3;
            // 
            // lblFilterDashCurrent
            // 
            lblFilterDashCurrent.AutoSize = true;
            lblFilterDashCurrent.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFilterDashCurrent.Location = new Point(214, 10);
            lblFilterDashCurrent.Name = "lblFilterDashCurrent";
            lblFilterDashCurrent.Size = new Size(20, 25);
            lblFilterDashCurrent.TabIndex = 2;
            lblFilterDashCurrent.Text = "-";
            // 
            // dtpSelectedEndDateInclude
            // 
            dtpSelectedEndDateInclude.Location = new Point(240, 12);
            dtpSelectedEndDateInclude.Name = "dtpSelectedEndDateInclude";
            dtpSelectedEndDateInclude.Size = new Size(200, 23);
            dtpSelectedEndDateInclude.TabIndex = 1;
            dtpSelectedEndDateInclude.ValueChanged += dtpSelectedEndDateInclude_ValueChanged;
            // 
            // dtpSelectedStartDate
            // 
            dtpSelectedStartDate.Location = new Point(8, 12);
            dtpSelectedStartDate.Name = "dtpSelectedStartDate";
            dtpSelectedStartDate.Size = new Size(200, 23);
            dtpSelectedStartDate.TabIndex = 0;
            dtpSelectedStartDate.ValueChanged += dtpSelectedDate_ValueChanged;
            // 
            // tlpMessagesPermanent
            // 
            tlpMessagesPermanent.AutoScroll = true;
            tlpMessagesPermanent.BackColor = SystemColors.ControlDarkDark;
            tlpMessagesPermanent.ColumnCount = 1;
            tlpMessagesPermanent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMessagesPermanent.Dock = DockStyle.Fill;
            tlpMessagesPermanent.Location = new Point(0, 58);
            tlpMessagesPermanent.Name = "tlpMessagesPermanent";
            tlpMessagesPermanent.RowCount = 2;
            tlpMessagesPermanent.RowStyles.Add(new RowStyle(SizeType.Absolute, 800F));
            tlpMessagesPermanent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMessagesPermanent.Size = new Size(336, 420);
            tlpMessagesPermanent.TabIndex = 0;
            tlpMessagesPermanent.Resize += tlpMessages_Resize;
            // 
            // pnlSearchPermanent
            // 
            pnlSearchPermanent.Controls.Add(pnlFilterPermanent);
            pnlSearchPermanent.Controls.Add(cbFullPinned);
            pnlSearchPermanent.Dock = DockStyle.Top;
            pnlSearchPermanent.Location = new Point(0, 0);
            pnlSearchPermanent.Name = "pnlSearchPermanent";
            pnlSearchPermanent.Size = new Size(336, 58);
            pnlSearchPermanent.TabIndex = 1;
            // 
            // pnlFilterPermanent
            // 
            pnlFilterPermanent.Controls.Add(dtpPermanentFrom);
            pnlFilterPermanent.Controls.Add(lblFilterDashPinnedCaption);
            pnlFilterPermanent.Controls.Add(cbFilterUserPinned);
            pnlFilterPermanent.Controls.Add(lblFilterUserCaption);
            pnlFilterPermanent.Controls.Add(dtpPermanentTo);
            pnlFilterPermanent.Location = new Point(7, 26);
            pnlFilterPermanent.Name = "pnlFilterPermanent";
            pnlFilterPermanent.Size = new Size(641, 29);
            pnlFilterPermanent.TabIndex = 10;
            pnlFilterPermanent.Visible = false;
            // 
            // dtpPermanentFrom
            // 
            dtpPermanentFrom.Location = new Point(3, 3);
            dtpPermanentFrom.Name = "dtpPermanentFrom";
            dtpPermanentFrom.Size = new Size(140, 23);
            dtpPermanentFrom.TabIndex = 7;
            dtpPermanentFrom.ValueChanged += dtpPermanentFrom_ValueChanged;
            // 
            // lblFilterDashPinnedCaption
            // 
            lblFilterDashPinnedCaption.AutoSize = true;
            lblFilterDashPinnedCaption.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFilterDashPinnedCaption.Location = new Point(149, 1);
            lblFilterDashPinnedCaption.Name = "lblFilterDashPinnedCaption";
            lblFilterDashPinnedCaption.Size = new Size(20, 25);
            lblFilterDashPinnedCaption.TabIndex = 9;
            lblFilterDashPinnedCaption.Text = "-";
            // 
            // cbFilterUserPinned
            // 
            cbFilterUserPinned.FormattingEnabled = true;
            cbFilterUserPinned.Location = new Point(414, 3);
            cbFilterUserPinned.Name = "cbFilterUserPinned";
            cbFilterUserPinned.Size = new Size(218, 23);
            cbFilterUserPinned.TabIndex = 6;
            cbFilterUserPinned.SelectedIndexChanged += cbFilterUserPinned_SelectedIndexChanged;
            // 
            // lblFilterUserCaption
            // 
            lblFilterUserCaption.AutoSize = true;
            lblFilterUserCaption.Location = new Point(321, 7);
            lblFilterUserCaption.Name = "lblFilterUserCaption";
            lblFilterUserCaption.Size = new Size(87, 15);
            lblFilterUserCaption.TabIndex = 7;
            lblFilterUserCaption.Text = "Пользователь:";
            // 
            // dtpPermanentTo
            // 
            dtpPermanentTo.Location = new Point(175, 3);
            dtpPermanentTo.Name = "dtpPermanentTo";
            dtpPermanentTo.Size = new Size(140, 23);
            dtpPermanentTo.TabIndex = 8;
            dtpPermanentTo.ValueChanged += dtpPermanentTo_ValueChanged;
            // 
            // cbFullPinned
            // 
            cbFullPinned.AutoSize = true;
            cbFullPinned.Location = new Point(7, 3);
            cbFullPinned.Name = "cbFullPinned";
            cbFullPinned.Size = new Size(246, 19);
            cbFullPinned.TabIndex = 2;
            cbFullPinned.Text = "Показать все закрепленные сообщения";
            cbFullPinned.UseVisualStyleBackColor = true;
            cbFullPinned.CheckedChanged += cbFullPinned_CheckedChanged;
            // 
            // btnCreateMessage
            // 
            btnCreateMessage.Font = new Font("Segoe UI", 12F);
            btnCreateMessage.Location = new Point(3, 3);
            btnCreateMessage.Name = "btnCreateMessage";
            btnCreateMessage.Size = new Size(208, 29);
            btnCreateMessage.TabIndex = 1;
            btnCreateMessage.Text = "✚ Добавить сообщение";
            btnCreateMessage.TextAlign = ContentAlignment.TopCenter;
            btnCreateMessage.UseVisualStyleBackColor = true;
            btnCreateMessage.Click += btnCreateMessage_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 300000;
            timer1.Tick += timer1_Tick;
            // 
            // cbPermanentCurrent
            // 
            cbPermanentCurrent.Appearance = Appearance.Button;
            cbPermanentCurrent.Location = new Point(217, 3);
            cbPermanentCurrent.Name = "cbPermanentCurrent";
            cbPermanentCurrent.Size = new Size(147, 29);
            cbPermanentCurrent.TabIndex = 11;
            cbPermanentCurrent.Text = "Развернуть объявления";
            cbPermanentCurrent.UseVisualStyleBackColor = true;
            cbPermanentCurrent.CheckedChanged += cbPermanentCurrent_CheckedChanged;
            cbPermanentCurrent.Resize += cbPermanentCurrent_Resize;
            // 
            // JournalMessages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 519);
            Controls.Add(cbPermanentCurrent);
            Controls.Add(btnCreateMessage);
            Controls.Add(pnlSplit);
            MinimumSize = new Size(1300, 0);
            Name = "JournalMessages";
            Text = "JournalMessages";
            pnlSplit.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlSearchCurrent.ResumeLayout(false);
            pnlSearchCurrent.PerformLayout();
            pnlSearchPermanent.ResumeLayout(false);
            pnlSearchPermanent.PerformLayout();
            pnlFilterPermanent.ResumeLayout(false);
            pnlFilterPermanent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSplit;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tlpMessagesPermanent;
        private TableLayoutPanel tlpMessagesCurrent;
        private Button btnCreateMessage;
        private Panel pnlSearchCurrent;
        private DateTimePicker dtpSelectedStartDate;
        private CheckBox cbFullPinned;
        private System.Windows.Forms.Timer timer1;
        private Label lblFilterDashCurrent;
        private DateTimePicker dtpSelectedEndDateInclude;
        private ComboBox cbFilterUser;
        private Label lblFilterShift;
        private Label lblFiterUser;
        private ComboBox cbFilterShift;
        private Label lblFilterUserCaption;
        private ComboBox cbFilterUserPinned;
        private Label lblFilterDashPinnedCaption;
        private DateTimePicker dtpPermanentTo;
        private DateTimePicker dtpPermanentFrom;
        private Panel pnlFilterPermanent;
        private CheckBox cbPermanentCurrent;
        private Panel pnlSearchPermanent;
    }
}