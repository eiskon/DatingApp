namespace DatingApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswortHash { get; set; }
        public byte[] PasswortSalt { get; set; }
    }
}