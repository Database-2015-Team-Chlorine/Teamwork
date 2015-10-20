namespace MediaMonitoringSystem.Models.Pdf
{
    using System;
    using System.Linq;

    public class PdfModel
    {
        public string Name { get; set; }

        public string Client { get; set; }

        public int CountMedias { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Price { get; set; }
    }
}
