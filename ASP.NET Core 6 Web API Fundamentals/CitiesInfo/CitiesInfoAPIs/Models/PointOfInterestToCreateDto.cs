using System.ComponentModel.DataAnnotations;

namespace CitiesInfoAPIs.Models
{
    public class PointOfInterestToCreateDto
    {
        [Required(ErrorMessage ="You must provide point name")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Discription{ get; set; }
    }
}
