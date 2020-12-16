namespace JobListing.Models
{
    public class JobSkill
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Job ID
        /// </summary>
        public int JobID { get; set; }

        /// <summary>
        /// Skill ID
        /// </summary>
        public int SkillID { get; set; }

        /// <summary>
        /// Linked Job
        /// </summary>
        public Job Job { get; set; }

        /// <summary>
        /// Linked Skill
        /// </summary>
        public Skill Skill { get; set; }
    }
}
