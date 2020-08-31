namespace Insurance.Web.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public CountryModel Country { get; set; }
        public string Name { get; set; }
    }
}
