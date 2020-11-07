using System;

namespace WorkAssistantApp.Data.Models
{
    public class StatusEvent : IUserCreatedModified
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int TypeId { get; set; }
        public long? ProjectId { get; set; }
        public string Description { get; set; }

        public virtual StatusEventType Type { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Project Project { get; set; }

        #region IUserCreatedModified
        public long? CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        #endregion
    }
}
