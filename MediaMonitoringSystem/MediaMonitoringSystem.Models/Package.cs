namespace MediaMonitoringSystem.Models
{
    using System.Collections.Generic;

    public class Package
    {
        private ICollection<Media> medias;

        private ICollection<Theme> themes;

        public Package()
        {
            this.medias = new HashSet<Media>();
            this.themes = new HashSet<Theme>();
        }
        
        public int Id { get; set; }

        public PackageType Type { get; set; }

        public decimal PricePerMonth { get; set; }

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

        public virtual ICollection<Theme> Themes
        {
            get
            {
                return this.themes;
            }

            set
            {
                this.themes = value;
            }
        }
    }
}
