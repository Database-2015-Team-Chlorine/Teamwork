namespace MediaMonitoringSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Media
    {
        private ICollection<Package> packages;
        private ICollection<Article> articles;

        public Media()
        {
            this.packages = new HashSet<Package>();
            this.articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        public MediaType Type { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Package> Packages
        {
            get { return this.packages; }
            set { this.packages = value; }
        }
        
        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }

        [Required]
        public int MediaDistributorId { get; set; }

        public virtual MediaDistributor MediaDistributor { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal PriceSubscriptionPerMonth { get; set; }
    }
}
