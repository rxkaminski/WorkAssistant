using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorkAssistantApp.Data;
using WorkAssistantApp.ViewModels;

namespace WorkAssistantApp.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        public UserController(WorkAssistantDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet("picker")]
        public IActionResult Picker()
        {
            var users = dbContext.Users
                                    .Select(p => new
                                    {
                                        p.Id,
                                        p.FirstName,
                                        p.LastName
                                    })
                                    .ToArray();

            return new JsonResult(users.Adapt<ApplicationUserShortViewModel[]>());
        }
    }
}
