namespace MediaMonitoringSystem.Models.MSSQL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        private ICollection<Employee> employees;

        private ICollection<Media> medias;

        public Department()
        {
            this.employees = new HashSet<Employee>();
            this.medias = new HashSet<Media>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        public virtual ICollection<Media> Medias
        {
            get { return this.medias; }
            set { this.medias = value; }
        }
    }
}