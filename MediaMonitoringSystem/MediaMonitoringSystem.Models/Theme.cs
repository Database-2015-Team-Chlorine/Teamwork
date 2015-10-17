namespace MediaMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Theme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
