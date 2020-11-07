using System;

namespace WorkAssistantApp.Data.Models
{
    public class Project : IUserCreatedModified
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public long? ProjectManagerId { get; set; }
        public virtual ApplicationUser ProjectManager { get; set; }

        #region IUserCreatedModified
        public long? CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public virtual ApplicationUser ModifiedBy { get; set; }
        #endregion

    }
}
