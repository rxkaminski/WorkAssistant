namespace WorkAssistantApp.ViewModels
{
    public class StatusesViewModel
    {
        public long UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StatusDescription { get; set; }

        public string StartHourOnMondayHour { get; set; }
        public string StartHourOnTuesdayHour { get; set; }
        public string StartHourOnWednesdayHour { get; set; }
        public string StartHourOnThursdayHour { get; set; }
        public string StartHourOnFridayHour { get; set; }
        public ProjectShortViewModel Project { get; set; }
    }
}
