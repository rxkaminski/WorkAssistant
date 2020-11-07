using System;

namespace WorkAssistantApp.Data.Models
{
    public interface IUserModified
    {
        public long? ModifiedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
    }
}
