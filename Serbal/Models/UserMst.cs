namespace Serbal.Models
{
    public partial class UserMst
    {
        public int UserID { get; set; }

        public string EmployeeID { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

        public bool IsActive { get; set; }

        public bool IsLocked { get; set; }

        public int CreatedByID { get; set; }

        public DateTime DateCreated { get; set; }

        public int ModifiedByID { get; set; }

        public DateTime DateModified { get; set; }
    }
}
