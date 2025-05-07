using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDB
{
    public class JournalTypeUserTypeRight
    {
        [Key]
        public int JournalTypeUserTypeRightID { get; set; }
        public int JournalTypeID { get; set; }
        public virtual JournalType JournalType { get; set; }
        public int UserTypeID { get; set; }
        public virtual UserType UserType { get; set; }

        /// <summary>
        /// 0 бит - можно читать, 1 бит - можно писать
        /// </summary>
        public int bUserTypeRight { get; set; }


    }
}
