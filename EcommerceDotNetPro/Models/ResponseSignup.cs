using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace EcommerceDotNetPro.Models
{
    public class ResponseSignup
    {
        
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Status { get; set; }

    }
}
