namespace MediaMonitoringSystem.Models
{
    using System.Collections.Generic;

    public class MediaDistributor
    {
        private ICollection<Media> medias;

        public MediaDistributor()
        {
            this.medias = new HashSet<Media>();
        }

        public int Id { get; set; }

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
