using System.ComponentModel.DataAnnotations;

namespace Chat.Repository.Core.EntityModel
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool LoginStatus { get; set; }
    }
}
