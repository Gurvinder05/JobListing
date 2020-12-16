using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobListing.Models
{
    public class Skill
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the Skill
        /// </summary>
        [Required]
        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }

        /// <summary>
        /// Description of the Skill
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Collections of Job Skills with this skill
        /// </summary>
        public ICollection<JobSkill> JobSkills { get; set; }
    }
}
