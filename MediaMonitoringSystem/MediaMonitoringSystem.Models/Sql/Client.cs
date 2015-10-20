namespace MediaMonitoringSystem.Models.Sql
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        private ICollection<Theme> themes;

        public Client()
        {
            this.themes = new HashSet<Theme>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
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