namespace FutureMe.Models
{
    public class Letter
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime WritingDate { get; set; }
        public DateTime SendingDate { get; set; }
        public bool IsPublic { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public User? User { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}