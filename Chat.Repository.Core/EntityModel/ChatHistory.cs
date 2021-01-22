using System.ComponentModel.DataAnnotations;

namespace Chat.Repository.Core.EntityModel
{
    public class ChatHistory : BaseEntity
    {
        [Required]
        public long SenderUserId { get; set; }

        [Required]
        public long RecipientUserId { get; set; }

        [Required]
        public string content { get; set; }
    }
}
