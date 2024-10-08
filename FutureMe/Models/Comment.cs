using FutureMe.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FutureMe.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(1000)]
        public string? Content { get; set; }

        public ApplicationUser? User { get; set; }

        public Letter? Letter { get; set; }
    }
}