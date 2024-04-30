namespace TaxiStartApp.Dto
{
    public class UserTokenJson
    {
        public string id { get; set; }
        public string? tokenType { get; set; }

        public string? accessToken { get; set; }

        public int? expiresIn { get; set; }

        public string? refreshToken { get; set; }

        public string? scope { get; set; }
    }
}
