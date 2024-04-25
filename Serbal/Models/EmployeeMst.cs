namespace Serbal.Models
{
    public class EmployeeMst
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeFatherName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string PersonalEmail { get; set; }
        public bool IsActive { get; set; }

        public int CreatedByID { get; set; }
        public DateTime DateCreated { get; set; }
        public int ModifiedByID { get; set; }
        public DateTime DateModified { get; set; }

    }
}
