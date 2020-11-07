using System;
using WorkAssistantApp.Data.Models;

namespace WorkAssistantApp.ViewModels
{
    public class ProjectViewModel: IUserCreatedModified
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public long? ProjectManagerId { get; set; }
        public ApplicationUserShortViewModel ProjectManager { get; set; }

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
