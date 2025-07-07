using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDB
{
    public class JournalType
    {
        [Key]
        public int JournalTypeID { get; set; }
        public string JournalTypeName { get; set; }
        public bool ProductionShiftActive { get; set; }

    }
}
