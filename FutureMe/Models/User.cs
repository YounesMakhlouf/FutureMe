namespace FutureMe.Models
{
    public class User
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Letter>? Letters { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
