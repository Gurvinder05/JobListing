using System.ComponentModel.DataAnnotations;

namespace JobListing.Models
{
    public class Location
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the Location
        /// </summary>
        [Required]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        /// <summary>
        /// Description about the location
        /// </summary>
        public string Description { get; set; }
    }
}
