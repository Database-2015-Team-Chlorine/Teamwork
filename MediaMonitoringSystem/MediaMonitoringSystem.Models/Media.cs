namespace MediaMonitoringSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Media
    {
        private ICollection<Package> packages;

        public Media()
        {
            this.packages = new HashSet<Package>();
        }

        public int Id { get; set; }

        public MediaType Type { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Package> Packages
        {
            get
            {
                return this.packages;
            }

            set
            {
                this.packages = value;
            }
        }

        public int MediaDistributorId { get; set; }

        public virtual MediaDistributor MediaDistributor { get; set; }

        public decimal PriceSubscriptionPerMonth { get; set; }
    }
}
