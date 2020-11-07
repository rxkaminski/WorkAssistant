using System.Collections.Generic;

namespace WorkAssistantApp.Data.Models
{
    public class ApplicationUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual StatusCurrent StatusCurrent { get; set; }
        public virtual List<StatusEvent> StatusEvents { get; set; }


    }
}
