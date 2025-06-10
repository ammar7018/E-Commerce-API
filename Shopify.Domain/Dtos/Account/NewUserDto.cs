namespace Supliex.Domain.Dtos.Account
{
    public class NewUserDto
    {
        public bool IsLogedIn { get; set; } = false;
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }

    }

}
