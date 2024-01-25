using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace chattech_auth.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string UserName { get; set; } 
        public string? ProfileImageUrl { get; set; } 
        public string? Bio { get; set; } 
        public DateTime JoinDate { get; set; }  
        public bool IsActive { get; set; }  
    }
}
