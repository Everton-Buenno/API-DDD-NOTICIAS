namespace WebApi.Token
{
    public class AppSettings
    {
        public string  Secret { get; set; }

        public int Expire { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

    }
}
