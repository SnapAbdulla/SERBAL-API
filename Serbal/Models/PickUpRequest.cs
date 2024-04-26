namespace Serbal.Models
{
    public partial class PickUpRequest
    {
        public int PickupID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }

        public DateTime? PickupDateTime { get; set; }

        public string DonateType { get; set; }

        public string PickupLocation { get; set; }

        public int? PickupEmployeeID { get; set; }

        public bool? IsPicked { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? ModifiedByID { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
