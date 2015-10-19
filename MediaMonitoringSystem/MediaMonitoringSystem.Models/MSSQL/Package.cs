namespace MediaMonitoringSystem.Models.MSSQL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Package
    {
        private ICollection<Media> medias;

        private ICollection<Theme> themes;

        public Package()
        {
            this.medias = new HashSet<Media>();
            this.themes = new HashSet<Theme>();
        }

        [Key]
        public int Id { get; set; }

        //[Required]
        //[Range(3, 100)]
        public int CountMedias { get; set; }

        //[Required]
        //[Column(TypeName = "Money")]
        public decimal PricePerMonth { get; set; }

        public virtual ICollection<Media> Medias
        {
            get { return this.medias; }
            set { this.medias = value; }
        }

        public virtual ICollection<Theme> Themes
        {
            get { return this.themes; }
            set { this.themes = value; }
        }
    }
}