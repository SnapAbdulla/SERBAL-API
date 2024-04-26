namespace Serbal.Models
{
    public partial class DailyWeight
    {
        public int WeightID { get; set; }

        public DateTime? Date { get; set; }

        public string TruckNumber { get; set; }

        public int? DriverID { get; set; }

        public TimeSpan? ArrivelTime { get; set; }

        public int? ZoneLocation { get; set; }

        public string Longitude { get; set; }

        public decimal? Weight { get; set; }

        public decimal? TruckWeight { get; set; }

        public decimal? OtherWeight { get; set; }

        public decimal? FinalWeight { get; set; }

        public int? NumberOfBox { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? ModifiedByID { get; set; }

        public DateTime? DateModified { get; set; }
    }
}