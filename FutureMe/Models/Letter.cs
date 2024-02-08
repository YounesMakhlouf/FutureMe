using System.ComponentModel.DataAnnotations;

namespace FutureMe.Models
{
    public class Letter
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime WritingDate { get; set; } = DateTime.Now;

        [SendingDate(ErrorMessage = "Sending date must be after writing date")]
        public DateTime SendingDate { get; set; }
        public bool IsPublic { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}