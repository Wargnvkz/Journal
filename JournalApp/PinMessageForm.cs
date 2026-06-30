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
using System.Xml.Linq;

namespace JournalApp
{
    public partial class PinMessageForm : Form
    {
        public PinnedMessageParameters PinParameters
        {
            get
            {
                return new PinnedMessageParameters()
                {
                    IsPinned = cbPin.Checked,
                    StartPin = dtpStartPin.Value,
                    StopPin = dtpStopPin.Value
                };
            }

            set
            {
                var parameters = value;
                cbPin.Checked = parameters.IsPinned;
                dtpStartPin.Value = parameters.StartPin ?? DateTime.Now;
                dtpStopPin.Value = parameters.StopPin ?? DateTime.Now.AddDays(1);
            }
        }
        public PinMessageForm()
        {
            InitializeComponent();
        }

        private void cbPin_CheckedChanged(object sender, EventArgs e)
        {
            gbDate.Enabled = cbPin.Checked;
        }
        private bool ValidateInput()
        {
            bool isValid = true;
            if (PinParameters.StartPin > PinParameters.StopPin)
            {
                errorProvider1.SetError(dtpStopPin, "Время окончания должно быть больше времени начала");
                isValid = false;

            }
            else
            {
                errorProvider1.SetError(dtpStopPin, ""); // Очищаем ошибку

            }
            return isValid;
        }

        public class PinnedMessageParameters
        {
            public bool IsPinned;
            public DateTime? StartPin;
            public DateTime? StopPin;
        }

        private void PinMessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (!ValidateInput())
                {
                    e.Cancel = true; // Отменяем закрытие формы
                }
            }
        }
    }
}
