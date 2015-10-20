namespace MediaMonitoringSystem.Models.Sql
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}