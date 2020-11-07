using System;
using WorkAssistantApp.Data.Models;

namespace WorkAssistantApp.ViewModels
{
    public class StatusEventViewModel: IUserCreatedModified
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int TypeId { get; set; }
        public long? ProjectId { get; set; }
        public string Description { get; set; }

   
        public StatusEventTypeViewModel Type { get; set; }
        public ProjectShortViewModel Project { get; set; }


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
