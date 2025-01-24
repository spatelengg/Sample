

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Domain.Entities
{
    public class User : Common.BaseEntity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedInUrl { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public UserStatus Status { get; set; }
        public string AliasName { get; set; }
    }
}
