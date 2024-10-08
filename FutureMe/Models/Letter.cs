using FutureMe.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureMe.Models
{
    public class Letter : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }

        public DateTime WritingDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime SendingDate { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SendingDate.Date < WritingDate.Date)
            {
                yield return new ValidationResult(
                    "Sending date must be after or equal to the writing date.",
                    new[] { nameof(SendingDate) });
            }
        }
    }
}