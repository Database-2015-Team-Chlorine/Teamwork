namespace MediaMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }
        

        public DateTime PublishedOn { get; set; }

        public byte[] File { get; set; }

        public int MediaId { get; set; }

        public virtual Media Media { get; set; }
    }
}
