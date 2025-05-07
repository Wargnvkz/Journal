using System.ComponentModel.DataAnnotations;

namespace JournalDB
{
    public class MessageFile
    {
        [Key]
        public int MessageFileID { get; set; }
        public int MessageID { get; set; }
        public string Filename { get; set; }
        public byte[] Data { get; set; }
    }
}
