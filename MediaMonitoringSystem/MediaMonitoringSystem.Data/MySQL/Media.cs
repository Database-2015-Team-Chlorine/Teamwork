
namespace MediaMonitoringSystem.Data.MySQL
{
    public class MediaModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Distributor { get; set; }

        public int TotalSells { get; set; }

        public decimal Incomes { get; set; }
    }
}
