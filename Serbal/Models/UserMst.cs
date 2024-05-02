using System.ComponentModel.DataAnnotations;
namespace Serbal.Models
{
    public partial class UserMst
    {
        [Key]
        public int UserID { get; set; }

        public int EmployeeID { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }

        public bool IsActive { get; set; }

        public bool IsLocked { get; set; }

        public int CreatedByID { get; set; }

        public DateTime DateCreated { get; set; }

        public int ModifiedByID { get; set; }

        public DateTime DateModified { get; set; }
    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
