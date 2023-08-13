using System.ComponentModel.DataAnnotations;

namespace CitiesInfoAPIs.Models
{
    public class PointOfInterestToUpdate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
