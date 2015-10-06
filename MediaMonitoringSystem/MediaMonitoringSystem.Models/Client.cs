namespace MediaMonitoringSystem.Models
{
    using System.Collections.Generic;

    public class Client
    {
        private ICollection<Theme> themes; 

        public Client()
        {
            this.themes = new HashSet<Theme>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

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
