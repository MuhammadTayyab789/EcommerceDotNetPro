namespace EcommerceDotNetPro.Models
{
    public class jwtsettings
    {

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int TokenLifetime { get; set; }
    }
}
