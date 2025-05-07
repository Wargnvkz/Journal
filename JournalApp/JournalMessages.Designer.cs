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
            tlpMessagesPermanent = new TableLayoutPanel();
            tlpMessagesCurrent = new TableLayoutPanel();
            pnlSearch = new Panel();
            lblFilterShift = new Label();
            lblFiterUser = new Label();
            cbFilterShift = new ComboBox();
            cbFilterUser = new ComboBox();
            lblFilterDashCurrent = new Label();
            dtpSelectedEndDateInclude = new DateTimePicker();
            dtpSelectedStartDate = new DateTimePicker();
            btnCreateMessage = new Button();
            cbFullPinned = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            lblFilterUserCaption = new Label();
            cbFilterUserPinned = new ComboBox();
            lblFilterDashPinnedCaption = new Label();
            dtpPermanentTo = new DateTimePicker();
            dtpPermanentFrom = new DateTimePicker();
            pnlFilterPermanent = new Panel();
            cbPermanentCurrent = new CheckBox();
            pnlSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlSearch.SuspendLayout();
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
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tlpMessagesPermanent);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(tlpMessagesCurrent);
            splitContainer1.Panel2.Controls.Add(pnlSearch);
            splitContainer1.Size = new Size(1282, 480);
            splitContainer1.SplitterDistance = 112;
            splitContainer1.SplitterWidth = 8;
            splitContainer1.TabIndex = 0;
            // 
            // tlpMessagesPermanent
            // 
            tlpMessagesPermanent.AutoScroll = true;
            tlpMessagesPermanent.BackColor = SystemColors.ControlDarkDark;
            tlpMessagesPermanent.ColumnCount = 1;
            tlpMessagesPermanent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMessagesPermanent.Dock = DockStyle.Fill;
            tlpMessagesPermanent.Location = new Point(0, 0);
            tlpMessagesPermanent.Name = "tlpMessagesPermanent";
            tlpMessagesPermanent.RowCount = 2;
            tlpMessagesPermanent.RowStyles.Add(new RowStyle(SizeType.Absolute, 800F));
            tlpMessagesPermanent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMessagesPermanent.Size = new Size(1280, 110);
            tlpMessagesPermanent.TabIndex = 0;
            tlpMessagesPermanent.Resize += tlpMessages_Resize;
            // 
            // tlpMessagesCurrent
            // 
            tlpMessagesCurrent.AutoScroll = true;
            tlpMessagesCurrent.BackColor = SystemColors.ControlDarkDark;
            tlpMessagesCurrent.ColumnCount = 1;
            tlpMessagesCurrent.ColumnStyles.Add(new ColumnStyle());
            tlpMessagesCurrent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMessagesCurrent.Dock = DockStyle.Fill;
            tlpMessagesCurrent.Location = new Point(0, 50);
            tlpMessagesCurrent.Name = "tlpMessagesCurrent";
            tlpMessagesCurrent.RowCount = 1;
            tlpMessagesCurrent.RowStyles.Add(new RowStyle(SizeType.Absolute, 306F));
            tlpMessagesCurrent.Size = new Size(1280, 308);
            tlpMessagesCurrent.TabIndex = 1;
            tlpMessagesCurrent.Resize += tlpMessages_Resize;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = SystemColors.Control;
            pnlSearch.Controls.Add(lblFilterShift);
            pnlSearch.Controls.Add(lblFiterUser);
            pnlSearch.Controls.Add(cbFilterShift);
            pnlSearch.Controls.Add(cbFilterUser);
            pnlSearch.Controls.Add(lblFilterDashCurrent);
            pnlSearch.Controls.Add(dtpSelectedEndDateInclude);
            pnlSearch.Controls.Add(dtpSelectedStartDate);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1280, 50);
            pnlSearch.TabIndex = 2;
            // 
            // lblFilterShift
            // 
            lblFilterShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFilterShift.AutoSize = true;
            lblFilterShift.Location = new Point(781, 15);
            lblFilterShift.Name = "lblFilterShift";
            lblFilterShift.Size = new Size(46, 15);
            lblFilterShift.TabIndex = 6;
            lblFilterShift.Text = "Смена:";
            // 
            // lblFiterUser
            // 
            lblFiterUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFiterUser.AutoSize = true;
            lblFiterUser.Location = new Point(960, 15);
            lblFiterUser.Name = "lblFiterUser";
            lblFiterUser.Size = new Size(87, 15);
            lblFiterUser.TabIndex = 5;
            lblFiterUser.Text = "Пользователь:";
            // 
            // cbFilterShift
            // 
            cbFilterShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFilterShift.FormattingEnabled = true;
            cbFilterShift.Location = new Point(833, 12);
            cbFilterShift.Name = "cbFilterShift";
            cbFilterShift.Size = new Size(121, 23);
            cbFilterShift.TabIndex = 4;
            // 
            // cbFilterUser
            // 
            cbFilterUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFilterUser.FormattingEnabled = true;
            cbFilterUser.Location = new Point(1053, 12);
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
            // cbFullPinned
            // 
            cbFullPinned.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFullPinned.AutoSize = true;
            cbFullPinned.Location = new Point(1036, 8);
            cbFullPinned.Name = "cbFullPinned";
            cbFullPinned.Size = new Size(246, 19);
            cbFullPinned.TabIndex = 2;
            cbFullPinned.Text = "Показать все закрепленные сообщения";
            cbFullPinned.UseVisualStyleBackColor = true;
            cbFullPinned.CheckedChanged += cbFullPinned_CheckedChanged;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 300000;
            timer1.Tick += timer1_Tick;
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
            // cbFilterUserPinned
            // 
            cbFilterUserPinned.FormattingEnabled = true;
            cbFilterUserPinned.Location = new Point(414, 3);
            cbFilterUserPinned.Name = "cbFilterUserPinned";
            cbFilterUserPinned.Size = new Size(218, 23);
            cbFilterUserPinned.TabIndex = 6;
            cbFilterUserPinned.SelectedIndexChanged += cbFilterUserPinned_SelectedIndexChanged;
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
            // dtpPermanentTo
            // 
            dtpPermanentTo.Location = new Point(175, 3);
            dtpPermanentTo.Name = "dtpPermanentTo";
            dtpPermanentTo.Size = new Size(140, 23);
            dtpPermanentTo.TabIndex = 8;
            dtpPermanentTo.ValueChanged += dtpPermanentTo_ValueChanged;
            // 
            // dtpPermanentFrom
            // 
            dtpPermanentFrom.Location = new Point(3, 3);
            dtpPermanentFrom.Name = "dtpPermanentFrom";
            dtpPermanentFrom.Size = new Size(140, 23);
            dtpPermanentFrom.TabIndex = 7;
            dtpPermanentFrom.ValueChanged += dtpPermanentFrom_ValueChanged;
            // 
            // pnlFilterPermanent
            // 
            pnlFilterPermanent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlFilterPermanent.Controls.Add(dtpPermanentFrom);
            pnlFilterPermanent.Controls.Add(lblFilterDashPinnedCaption);
            pnlFilterPermanent.Controls.Add(cbFilterUserPinned);
            pnlFilterPermanent.Controls.Add(lblFilterUserCaption);
            pnlFilterPermanent.Controls.Add(dtpPermanentTo);
            pnlFilterPermanent.Location = new Point(389, 3);
            pnlFilterPermanent.Name = "pnlFilterPermanent";
            pnlFilterPermanent.Size = new Size(641, 29);
            pnlFilterPermanent.TabIndex = 10;
            pnlFilterPermanent.Visible = false;
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
            // 
            // JournalMessages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 519);
            Controls.Add(cbPermanentCurrent);
            Controls.Add(pnlFilterPermanent);
            Controls.Add(cbFullPinned);
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
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlFilterPermanent.ResumeLayout(false);
            pnlFilterPermanent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSplit;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tlpMessagesPermanent;
        private TableLayoutPanel tlpMessagesCurrent;
        private Button btnCreateMessage;
        private Panel pnlSearch;
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
    }
}