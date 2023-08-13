using CitiesInfoAPIs.Models;

namespace CitiesInfoAPIs
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore current { get; set; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            this.Cities = new List<CityDto>()
           {
               new CityDto() { Id = 1, Name ="Cairo", PointOfInterest = new List<PointOfInterstDto>(){
               new PointOfInterstDto{Id = 1 , Name = "point 1"},
               new PointOfInterstDto{Id = 2 , Name = "point 2"},
               new PointOfInterstDto{Id = 3 , Name = "point 3"},
               } },
               new CityDto() { Id = 2, Name ="Giza", PointOfInterest = new List<PointOfInterstDto>(){
               new PointOfInterstDto{Id = 1 , Name = "point 1"},
               new PointOfInterstDto{Id = 2 , Name = "point 2"},
               new PointOfInterstDto{Id = 3 , Name = "point 3"},
               }},
               new CityDto() { Id = 3, Name ="Alex", PointOfInterest = new List<PointOfInterstDto>(){
               new PointOfInterstDto{Id = 1 , Name = "point 1"},
               new PointOfInterstDto{Id = 2 , Name = "point 2"},
               new PointOfInterstDto{Id = 3 , Name = "point 3"},
               }},

           };
        }
    }
}
