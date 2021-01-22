using System;

namespace Chat.Repository.Core.EntityModel
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool ActiveStatus { get; set; } = true;
        public bool DeleteStatus { get; set; } = false;

        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
