namespace JournalApp.SettingsForms
{
    partial class JournalUserRights
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
            lblUserTypeCaption = new Label();
            lblJournalTypeCaption = new Label();
            cbUserTypes = new ComboBox();
            cbJournalTypes = new ComboBox();
            gbUserRights = new GroupBox();
            cbPinRight = new CheckBox();
            btnSetRights = new Button();
            cbWriteRight = new CheckBox();
            cbReadRight = new CheckBox();
            gbUserRights.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserTypeCaption
            // 
            lblUserTypeCaption.AutoSize = true;
            lblUserTypeCaption.Location = new Point(12, 9);
            lblUserTypeCaption.Name = "lblUserTypeCaption";
            lblUserTypeCaption.Size = new Size(134, 15);
            lblUserTypeCaption.TabIndex = 0;
            lblUserTypeCaption.Text = "Группа пользователей:";
            // 
            // lblJournalTypeCaption
            // 
            lblJournalTypeCaption.AutoSize = true;
            lblJournalTypeCaption.Location = new Point(229, 9);
            lblJournalTypeCaption.Name = "lblJournalTypeCaption";
            lblJournalTypeCaption.Size = new Size(54, 15);
            lblJournalTypeCaption.TabIndex = 2;
            lblJournalTypeCaption.Text = "Журнал:";
            // 
            // cbUserTypes
            // 
            cbUserTypes.FormattingEnabled = true;
            cbUserTypes.Location = new Point(12, 27);
            cbUserTypes.Name = "cbUserTypes";
            cbUserTypes.Size = new Size(211, 23);
            cbUserTypes.TabIndex = 3;
            cbUserTypes.SelectedIndexChanged += cbUserTypes_SelectedIndexChanged;
            // 
            // cbJournalTypes
            // 
            cbJournalTypes.FormattingEnabled = true;
            cbJournalTypes.Location = new Point(229, 27);
            cbJournalTypes.Name = "cbJournalTypes";
            cbJournalTypes.Size = new Size(213, 23);
            cbJournalTypes.TabIndex = 4;
            cbJournalTypes.SelectedIndexChanged += cbJournalTypes_SelectedIndexChanged;
            // 
            // gbUserRights
            // 
            gbUserRights.Controls.Add(cbPinRight);
            gbUserRights.Controls.Add(btnSetRights);
            gbUserRights.Controls.Add(cbWriteRight);
            gbUserRights.Controls.Add(cbReadRight);
            gbUserRights.Location = new Point(448, 9);
            gbUserRights.Name = "gbUserRights";
            gbUserRights.Size = new Size(200, 137);
            gbUserRights.TabIndex = 5;
            gbUserRights.TabStop = false;
            gbUserRights.Text = "Права пользователей в журнале";
            // 
            // cbPinRight
            // 
            cbPinRight.AutoSize = true;
            cbPinRight.Location = new Point(6, 72);
            cbPinRight.Name = "cbPinRight";
            cbPinRight.Size = new Size(145, 19);
            cbPinRight.TabIndex = 3;
            cbPinRight.Text = "Закрепление записей";
            cbPinRight.UseVisualStyleBackColor = true;
            // 
            // btnSetRights
            // 
            btnSetRights.Location = new Point(6, 107);
            btnSetRights.Name = "btnSetRights";
            btnSetRights.Size = new Size(112, 24);
            btnSetRights.TabIndex = 2;
            btnSetRights.Text = "Установить";
            btnSetRights.UseVisualStyleBackColor = true;
            btnSetRights.Click += btnSetRights_Click;
            // 
            // cbWriteRight
            // 
            cbWriteRight.AutoSize = true;
            cbWriteRight.Location = new Point(6, 47);
            cbWriteRight.Name = "cbWriteRight";
            cbWriteRight.Size = new Size(140, 19);
            cbWriteRight.TabIndex = 1;
            cbWriteRight.Text = "Добавление записей";
            cbWriteRight.UseVisualStyleBackColor = true;
            // 
            // cbReadRight
            // 
            cbReadRight.AutoSize = true;
            cbReadRight.Location = new Point(6, 22);
            cbReadRight.Name = "cbReadRight";
            cbReadRight.Size = new Size(112, 19);
            cbReadRight.TabIndex = 0;
            cbReadRight.Text = "Чтение записей";
            cbReadRight.UseVisualStyleBackColor = true;
            // 
            // JournalUserRights
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 158);
            Controls.Add(gbUserRights);
            Controls.Add(cbJournalTypes);
            Controls.Add(cbUserTypes);
            Controls.Add(lblJournalTypeCaption);
            Controls.Add(lblUserTypeCaption);
            Name = "JournalUserRights";
            Text = "JournalUserRights";
            FormClosed += JournalUserRights_FormClosed;
            gbUserRights.ResumeLayout(false);
            gbUserRights.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserTypeCaption;
        private Label lblJournalTypeCaption;
        private ComboBox cbUserTypes;
        private ComboBox cbJournalTypes;
        private GroupBox gbUserRights;
        private CheckBox cbReadRight;
        private CheckBox cbWriteRight;
        private Button btnSetRights;
        private CheckBox cbPinRight;
    }
}