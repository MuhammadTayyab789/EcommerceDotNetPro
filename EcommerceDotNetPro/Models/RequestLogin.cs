using System.ComponentModel.DataAnnotations;

namespace EcommerceDotNetPro.Models
{
    public class RequestLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
