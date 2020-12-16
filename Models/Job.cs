using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobListing.Models
{
    public class Job
    {
        //Primary Key
        public int ID { get; set; }

        /// <summary>
        /// Name of the Job Listing
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of the Job Listing
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Location identifier associated with the Job Listing
        /// </summary>
        [Required]
        public int LocationID { get; set; }

        /// <summary>
        /// Whether or not the Job Is Permanent
        /// </summary>
        [Required]
        [Display(Name = "Job Status")]
        public char IsPermanent { get; set; }

        /// <summary>
        /// Whether the Job Listing is Active
        /// </summary>
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Associated Location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Collection of associated Job Skills
        /// </summary>
        public ICollection<JobSkill> JobSkills { get; set; }
    }
}
