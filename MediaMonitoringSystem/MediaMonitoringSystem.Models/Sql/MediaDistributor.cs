namespace MediaMonitoringSystem.Models.Sql
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MediaDistributor
    {
        private ICollection<Media> medias;

        public MediaDistributor()
        {
            this.medias = new HashSet<Media>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Media> Medias
        {
            get
            {
                return this.medias;
            }

            set
            {
                this.medias = value;
            }
        }
    }
}