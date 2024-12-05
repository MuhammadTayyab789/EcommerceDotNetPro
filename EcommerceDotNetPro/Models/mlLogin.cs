using System.ComponentModel.DataAnnotations;

namespace EcommerceDotNetPro.Models
{
    public class mlLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
