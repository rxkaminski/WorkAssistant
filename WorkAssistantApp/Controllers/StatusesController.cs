using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAssistantApp.Data;
using WorkAssistantApp.ViewModels;

namespace WorkAssistantApp.Controllers
{
    [Route("api/statuses")]
    public class StatusesController : BaseController
    {
        public StatusesController(WorkAssistantDbContext dbContext) : base(dbContext) { }

        [HttpGet]
        public IActionResult Get()
        {
            var users = dbContext.Users
                                 .Join(
                                    dbContext.StatusCurrents
                                             .Include(s => s.StartHourOnMonday)
                                             .Include(s => s.StartHourOnTuesday)
                                             .Include(s => s.StartHourOnWednesday)
                                             .Include(s => s.StartHourOnThursday)
                                             .Include(s => s.StartHourOnFriday)
                                             .Include(s => s.Project),
                                    u => u.Id,
                                    s => s.UserId,
                                    (u, s) => new
                                    {
                                        s.UserId,

                                        u.LastName,
                                        u.FirstName,
                                        u.Phone,
                                        u.Email,

                                        StatusDescription = (!s.StatusAvailableUse ||
                                                            (s.StatusAvailableUse &&
                                                             s.StatusAvailableFrom.HasValue && s.StatusAvailableTo.HasValue &&
                                                             s.StatusAvailableFrom.Value.Date <= DateTime.Now.Date &&
                                                             DateTime.Now.Date <= s.StatusAvailableTo.Value.Date)
                                                             ) ? s.StatusDescription : null,

                                        StartHourOnMondayHour = s.StartHourOnMonday.Hour,
                                        StartHourOnTuesdayHour = s.StartHourOnTuesday.Hour,
                                        StartHourOnWednesdayHour = s.StartHourOnWednesday.Hour,
                                        StartHourOnThursdayHour = s.StartHourOnThursday.Hour,
                                        StartHourOnFridayHour = s.StartHourOnFriday.Hour,

                                        Project = new
                                        {
                                            s.Project.Id,
                                            s.Project.Number,
                                            s.Project.Title
                                        }
                                    }
                                    )
                                 .OrderBy(u => u.LastName)
                                 .ThenBy(u => u.FirstName)
                                 .ToArray();


            return new JsonResult(users.Adapt<StatusesViewModel[]>());
        }
    }
}
