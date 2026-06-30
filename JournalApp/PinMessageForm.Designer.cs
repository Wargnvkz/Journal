namespace JournalApp
{
    partial class PinMessageForm
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
            gbDate = new GroupBox();
            lblStopPin = new Label();
            dtpStopPin = new DateTimePicker();
            lblStartPin = new Label();
            dtpStartPin = new DateTimePicker();
            cbPin = new CheckBox();
            btnOK = new Button();
            btnCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            gbDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // gbDate
            // 
            gbDate.Controls.Add(lblStopPin);
            gbDate.Controls.Add(dtpStopPin);
            gbDate.Controls.Add(lblStartPin);
            gbDate.Controls.Add(dtpStartPin);
            gbDate.Location = new Point(2, 0);
            gbDate.Name = "gbDate";
            gbDate.Size = new Size(292, 83);
            gbDate.TabIndex = 0;
            gbDate.TabStop = false;
            // 
            // lblStopPin
            // 
            lblStopPin.AutoSize = true;
            lblStopPin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblStopPin.Location = new Point(6, 57);
            lblStopPin.Name = "lblStopPin";
            lblStopPin.Size = new Size(51, 19);
            lblStopPin.TabIndex = 4;
            lblStopPin.Text = "Конец:";
            // 
            // dtpStopPin
            // 
            dtpStopPin.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpStopPin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpStopPin.Format = DateTimePickerFormat.Custom;
            dtpStopPin.Location = new Point(71, 51);
            dtpStopPin.Name = "dtpStopPin";
            dtpStopPin.Size = new Size(200, 25);
            dtpStopPin.TabIndex = 3;
            // 
            // lblStartPin
            // 
            lblStartPin.AutoSize = true;
            lblStartPin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblStartPin.Location = new Point(6, 26);
            lblStartPin.Name = "lblStartPin";
            lblStartPin.Size = new Size(59, 19);
            lblStartPin.TabIndex = 2;
            lblStartPin.Text = "Начало:";
            // 
            // dtpStartPin
            // 
            dtpStartPin.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpStartPin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpStartPin.Format = DateTimePickerFormat.Custom;
            dtpStartPin.Location = new Point(71, 20);
            dtpStartPin.Name = "dtpStartPin";
            dtpStartPin.Size = new Size(200, 25);
            dtpStartPin.TabIndex = 1;
            // 
            // cbPin
            // 
            cbPin.AutoSize = true;
            cbPin.Location = new Point(2, 1);
            cbPin.Name = "cbPin";
            cbPin.Size = new Size(150, 19);
            cbPin.TabIndex = 0;
            cbPin.Text = "Закрепить сообщение";
            cbPin.UseVisualStyleBackColor = true;
            cbPin.CheckedChanged += cbPin_CheckedChanged;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(2, 89);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(219, 89);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // PinMessageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 118);
            Controls.Add(cbPin);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(gbDate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "PinMessageForm";
            StartPosition = FormStartPosition.Manual;
            Text = "PinMessageForm";
            FormClosing += PinMessageForm_FormClosing;
            gbDate.ResumeLayout(false);
            gbDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbDate;
        private CheckBox cbPin;
        private Label lblStopPin;
        private DateTimePicker dtpStopPin;
        private Label lblStartPin;
        private DateTimePicker dtpStartPin;
        private Button btnOK;
        private Button btnCancel;
        private ErrorProvider errorProvider1;
    }
}