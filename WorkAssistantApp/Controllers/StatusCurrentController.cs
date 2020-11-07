using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkAssistantApp.Data;
using WorkAssistantApp.ViewModels;

namespace WorkAssistantApp.Controllers
{
    [Route("api/status/current")]
    [Route("api/user/{userId}/status/current")]
    public class StatusCurrentController : BaseController
    {
        public StatusCurrentController(WorkAssistantDbContext dbContext)
            : base(dbContext) { }

        [HttpGet]
        public IActionResult Get(long? userId = null)
        {
            var userIdLocal = GetUser(userId);

            var statusCurrent = dbContext.StatusCurrents
                                         .Include(s => s.Project)
                                         .Single(s => s.UserId == userIdLocal);

            if (statusCurrent == null)
                return new NotFoundResult();

            return new JsonResult(statusCurrent.Adapt<StatusCurrentViewModel>());
        }

        [HttpGet("starthours")]
        public IActionResult StartHours()
        {
            var startHours = dbContext.StatusStartHours
                                      .ToArray()
                                      .OrderBy(o => int.Parse(o.Hour.Replace(":", string.Empty)));
                                      
            return new JsonResult(startHours.Adapt<StatusStartHourViewModel[]>());
        }

        [HttpPost]
        public IActionResult Post([FromBody] StatusCurrentViewModel model, [FromRoute] long? userId = null)
        {
            if (model == null)
                return new StatusCodeResult(500);

            var userIdLocal = GetUser(userId);

            var statusCurrent = dbContext.StatusCurrents.Single(s => s.UserId == userIdLocal);

            if (model == null)
                return new NotFoundResult();

            statusCurrent.StatusDescription = model.StatusDescription;
            statusCurrent.StatusAvailableUse = model.StatusAvailableUse;
            statusCurrent.StatusAvailableFrom = model.StatusAvailableFrom;
            statusCurrent.StatusAvailableTo = model.StatusAvailableTo;
            statusCurrent.StartHourOnMondayId = model.StartHourOnMondayId;
            statusCurrent.StartHourOnTuesdayId = model.StartHourOnTuesdayId;
            statusCurrent.StartHourOnWednesdayId = model.StartHourOnWednesdayId;
            statusCurrent.StartHourOnThursdayId = model.StartHourOnThursdayId;
            statusCurrent.StartHourOnFridayId = model.StartHourOnFridayId;

            dbContext.SaveChanges();

            return new JsonResult(statusCurrent.Adapt<StatusCurrentViewModel>());
        }
    }
}
