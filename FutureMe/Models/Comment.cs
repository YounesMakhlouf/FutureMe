namespace FutureMe.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }
        public User? User { get; set; }
        public Letter? Letter { get; set; }
    }
}