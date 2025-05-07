using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JournalDB;

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

        public class PinnedMessageParameters
        {
            public bool IsPinned;
            public DateTime? StartPin;
            public DateTime? StopPin;
        }
    }
}
