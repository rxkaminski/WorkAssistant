using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkAssistantApp.Data;
using WorkAssistantApp.Data.Models;
using WorkAssistantApp.ViewModels;

namespace WorkAssistantApp.Controllers
{
    [Route("api/status/event")]
    [Route("api/user/{userId}/status/event")]
    public class StatusEventController : BaseController
    {
        public StatusEventController(WorkAssistantDbContext dbContext) : base(dbContext) { }

        [HttpGet]
        public IActionResult GatAll(long? userId = null)
        {
            var userIdLocal = GetUser(userId);

            if (!dbContext.Users.Any(u => u.Id == userIdLocal))
                return new NotFoundResult();

            var statusEvents = dbContext.StatusEvents
                                        .Include(e => e.Project)
                                        .Include(e => e.Type)
                                        .Where(e => e.UserId == userIdLocal)
                                        .ToArray();

            return new JsonResult(statusEvents.Adapt<StatusEventViewModel[]>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id, long? userId = null)
        {
            var userIdLocal = GetUser(userId);

            var statusEvent = dbContext.StatusEvents
                                       .Include(e => e.Project)
                                       .Include(e => e.Type)
                                       .SingleOrDefault(e => e.Id == id && e.UserId == userIdLocal);

            if (statusEvent == null)
                return new NotFoundResult();

            return new JsonResult(statusEvent.Adapt<StatusEventViewModel>());
        }

        [HttpGet("projectFor")]
        public IActionResult GetProjectFor(long? userId)
        {
            var userIdLocal = GetUser(userId);

            var user = dbContext.Users.FirstOrDefault(u => u.Id == userIdLocal);

            if (user == null)
                return new NotFoundResult();

            var projectForUser = dbContext.StatusEvents
                                          .Include(e => e.Project)
                                          .Where(e => e.UserId == userIdLocal)
                                          .Select(e => e.Project)
                                          .Distinct()
                                          .OrderByDescending(e => e.Number)
                                          .ToArray();

            return new JsonResult(projectForUser.Adapt<ProjectShortViewModel[]>());
        }

        [HttpGet("types")]
        public IActionResult Types()
        {
            var types = dbContext.StatusEventTypes.ToArray();

            return new JsonResult(types.Adapt<StatusEventType[]>());
        }

        [HttpPost]
        public IActionResult Post([FromBody] StatusEventViewModel model)
        {
            if (model == null)
                return new StatusCodeResult(500);

            var statusEvent = dbContext.StatusEvents.FirstOrDefault(e => e.Id == model.Id);

            if (statusEvent == null)
                return new NotFoundResult();

            statusEvent.From = model.From;
            statusEvent.To = model.To;
            statusEvent.TypeId = model.TypeId;
            statusEvent.ProjectId = model.ProjectId;
            statusEvent.Description = model.Description;

            dbContext.SaveChanges();

            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody] StatusEventViewModel model, [FromRoute] long? userId)
        {
            if (model == null)
                return new StatusCodeResult(500);

            var userIdLocal = GetUser(userId);

            var statusEvent = new StatusEvent();
            statusEvent.From = model.From;
            statusEvent.To = model.To;
            statusEvent.ProjectId = model.ProjectId;
            statusEvent.TypeId = model.TypeId;
            statusEvent.UserId = userIdLocal;
            statusEvent.Description = model.Description;

            dbContext.StatusEvents.Add(statusEvent);
            dbContext.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var statusEvent = dbContext.StatusEvents.FirstOrDefault(e => e.Id == id);

            if (statusEvent == null)
                return new NotFoundResult();

            dbContext.StatusEvents.Remove(statusEvent);
            dbContext.SaveChanges();

            return new NoContentResult();
        }
    }
}
