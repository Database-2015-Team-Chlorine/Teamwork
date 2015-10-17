namespace MediaMonitoringSystem.Models
{
    using System;

    public class Theme
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}