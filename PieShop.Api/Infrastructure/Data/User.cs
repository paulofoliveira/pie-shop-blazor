namespace PieShop.Api.Infrastructure.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; } = true;
    }
}
