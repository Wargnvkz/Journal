using System.ComponentModel.DataAnnotations;

namespace JournalDB
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        // Связь многие ко многим через промежуточную таблицу
        public virtual List<User> Users { get; set; } = new();
    }
}
