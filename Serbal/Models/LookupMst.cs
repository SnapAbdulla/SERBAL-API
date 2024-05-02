using System.ComponentModel.DataAnnotations;

namespace Serbal.Models
{
    public class LookupMst
    {
        [Key]
        public String LookupType { get; set; }
        public int TempID { get; set; }
        public String DisplayText { get; set; }
        public String Value { get; set; }
        public int SeqNo { get; set; }
        public bool IsActive { get; set; }
    }
}
