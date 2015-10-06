namespace BigRoom.Service.Models.JWTVms
{
    public class JWTResponse
    {
        public string AccessToken { get; set; }
        public string Type { get; set; }
        public double Expiration { get; set; }
    }
}