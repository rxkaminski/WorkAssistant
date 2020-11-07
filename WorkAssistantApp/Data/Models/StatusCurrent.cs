using System;

namespace WorkAssistantApp.Data.Models
{
    public class StatusCurrent: IUserModified
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


        public virtual ApplicationUser User { get; set; }
        public virtual Project Project { get; set; }
        public virtual StatusStartHour StartHourOnMonday { get; set; }
        public virtual StatusStartHour StartHourOnTuesday { get; set; }
        public virtual StatusStartHour StartHourOnWednesday { get; set; }
        public virtual StatusStartHour StartHourOnThursday { get; set; }
        public virtual StatusStartHour StartHourOnFriday { get; set; }

        #region IUserModified
        public long? ModifiedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        #endregion
    }
}
