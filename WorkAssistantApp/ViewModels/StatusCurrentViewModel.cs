using System;
using WorkAssistantApp.Data.Models;

namespace WorkAssistantApp.ViewModels
{
    public class StatusCurrentViewModel: IUserModified
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long? ProjectId { get; set; }
        public string StatusDescription { get; set; }
        public bool StatusAvailableUse { get; set; }
        public DateTime? StatusAvailableFrom { get; set; }
        public DateTime? StatusAvailableTo { get; set; }
        public int StartHourOnMondayId { get; set; }
        public int StartHourOnTuesdayId { get; set; }
        public int StartHourOnWednesdayId { get; set; }
        public int StartHourOnThursdayId { get; set; }
        public int StartHourOnFridayId { get; set; }

        public ProjectShortViewModel Project { get; set; }

        public StatusStartHourViewModel StartHourOnMonday { get; set; }
        public StatusStartHourViewModel StartHourOnTuesday { get; set; }
        public StatusStartHourViewModel StartHourOnWednesday { get; set; }
        public StatusStartHourViewModel StartHourOnThursday { get; set; }
        public StatusStartHourViewModel StartHourOnFriday { get; set; }

        #region IUserModified
        public long? ModifiedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        #endregion
    }
}
