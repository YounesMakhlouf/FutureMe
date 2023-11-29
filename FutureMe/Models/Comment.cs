namespace FutureMe.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? LetterId { get; set; }
        public Letter? Letter { get; set; }
    }
}
