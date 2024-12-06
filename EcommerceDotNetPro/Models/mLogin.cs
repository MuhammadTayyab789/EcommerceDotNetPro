using System.ComponentModel.DataAnnotations;

namespace EcommerceDotNetPro.Models
{
    public class mLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
