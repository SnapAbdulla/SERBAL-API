using System.ComponentModel.DataAnnotations;

namespace Serbal.Models
{
    public partial class LocationPoint
    {
        [Key]
        public int LocationID { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? LocationName { get; set; }
        public string? Remark{ get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedByID { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ModifiedByID { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
