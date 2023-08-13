namespace CitiesInfoAPIs.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }


        public int PointOfInterestValue
        {
            get { return PointOfInterest.Count; }
        }

        public ICollection<PointOfInterstDto> PointOfInterest { get; set; } = new List<PointOfInterstDto>();     
    }
}
