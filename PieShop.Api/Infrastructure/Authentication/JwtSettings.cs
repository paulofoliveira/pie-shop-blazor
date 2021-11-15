namespace PieShop.Api.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int ExpireInMinutes { get; set; }
    }
}
