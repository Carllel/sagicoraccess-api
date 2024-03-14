namespace Sagicor.Access.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        //public DateTime? Expiration { get; set; }
        public bool IsLogedIn { get; set; } = false;
    }
}
