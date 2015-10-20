namespace MediaMonitoringSystem.Data.MySql.Models
{
    public class MySqlMediaModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Distributor { get; set; }

        public int TotalSells { get; set; }

        public decimal Incomes { get; set; }
    }
}
