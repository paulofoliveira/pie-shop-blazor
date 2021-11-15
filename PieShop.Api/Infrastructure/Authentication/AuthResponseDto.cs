namespace PieShop.Api.Infrastructure.Authentication
{
    public class AuthResponseDto
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
