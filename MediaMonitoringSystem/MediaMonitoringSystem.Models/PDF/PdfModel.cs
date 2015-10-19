using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMonitoringSystem.Models.PDF
{
    public class Theme
    {
        public string Name { get; set; }
        public string Client { get; set; }
        public int CountMedias { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
