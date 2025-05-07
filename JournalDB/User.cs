using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDB
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string AutoLogonComputerNames { get; set; }
        public virtual List<UserType> UserTypes { get; set; } = new();

        [NotMapped]
        public List<string> ComputerNames
        {
            get
            {
                var res = new List<string>();
                if (AutoLogonComputerNames == null) return res;
                Array.ForEach(AutoLogonComputerNames.Split(','), cnsc => Array.ForEach(cnsc.Split(';'), cn => res.Add(cn.Trim().ToUpper())));
                return res;
            }
        }

        public bool CheckComputerName(string ComputerName)
        {
            var cns = ComputerNames;
            return cns.Contains(ComputerName.ToUpper());
        }
    }

}
