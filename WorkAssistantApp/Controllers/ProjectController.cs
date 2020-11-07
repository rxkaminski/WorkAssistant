using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkAssistantApp.Data;
using WorkAssistantApp.Data.Models;
using WorkAssistantApp.ViewModels;

namespace WorkAssistantApp.Controllers
{
    [Route("api/project")]
    public class ProjectController : BaseController
    {
        public ProjectController(WorkAssistantDbContext dbContext) : base(dbContext) { }

        [HttpGet("picker")]
        public IActionResult Picker()
        {
            var projects = dbContext.Projects
                                    .Select(p => new
                                    {
                                        p.Id,
                                        p.Number,
                                        p.Title
                                    })
                                    .ToArray();

            return new JsonResult(projects.Adapt<ProjectShortViewModel[]>());
        }

        [HttpGet("/api/project/managedBy")]
        [HttpGet("/api/user/{userId}/project/managedBy")]
        public IActionResult ManagedBy(long? userId)
        {
            var userIdLocal = GetUser(userId);

            var user = dbContext.Users.FirstOrDefault(u => u.Id == userIdLocal);

            if (user == null)
                return new NotFoundResult();

            var managmedProject = dbContext.Projects
                                           .Where(p => p.ProjectManagerId == userIdLocal)
                                           .Select(p => new
                                           {
                                               p.Id,
                                               p.Number,
                                               p.Title
                                           })
                                           .OrderByDescending(p => p.Number)
                                           .ToArray();

            return new JsonResult(managmedProject.Adapt<ProjectShortViewModel[]>());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = dbContext.Projects
                                    .ToArray();

            return new JsonResult(projects.Adapt<ProjectViewModel[]>());
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var project = dbContext.Projects
                                   .Include(u => u.CreatedBy)
                                   .Include(u => u.ModifiedBy)
                                   .FirstOrDefault(p => p.Id == id);

            if (project == null)
                return new NotFoundResult();

            return new JsonResult(project.Adapt<ProjectViewModel>());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProjectViewModel model)
        {
            if (model == null)
                return new StatusCodeResult(500);

            var project = dbContext.Projects.FirstOrDefault(e => e.Id == model.Id);

            if (project == null)
                return new NotFoundResult();

            project.Number = model.Number;
            project.Title = model.Title;
            project.Description = model.Description;
            project.Start = model.Start;
            project.End = model.End;
            project.ProjectManagerId = model.ProjectManagerId;

            project.ModifiedById = LoginUser();

            dbContext.SaveChanges();

            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProjectViewModel model)
        {
            if (model == null)
                return new StatusCodeResult(500);

            var project = new Project();
            project.Number = model.Number;
            project.Title = model.Title;
            project.Description = model.Description;
            project.Start = model.Start;
            project.End = model.End;
            project.ProjectManagerId = model.ProjectManagerId;

            //var createdDate = DateTime.UtcNow;

            project.CreatedById = LoginUser();
           // project.CreatedAt = createdDate;
            project.ModifiedById = LoginUser();
            //project.ModifiedAt = createdDate;

            dbContext.Projects.Add(project);
            dbContext.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var project = dbContext.Projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
                return new NotFoundResult();

            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();

            return new NoContentResult();
        }
    }
}
