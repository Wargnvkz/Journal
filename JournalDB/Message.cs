using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace JournalDB
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public DateTime CreatingDate { get; set; }
        public int UserID { get; set; }
        public int JournalTypeID { get; set; }
        public string MessageText { get; set; }
        public bool IsPinned { get; set; }
        public DateTime? StartPin { get; set; }
        public DateTime? StopPin { get; set; }
        [NotMapped]
        public Shift Shift
        {
            get
            {
                return new Shift(CreatingDate);
            }
        }
    }
}
