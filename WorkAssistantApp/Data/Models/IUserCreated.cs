using System;

namespace WorkAssistantApp.Data.Models
{
    public interface IUserCreated
    {
        public long? CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUser CreatedBy { get; set; }
    }
}
