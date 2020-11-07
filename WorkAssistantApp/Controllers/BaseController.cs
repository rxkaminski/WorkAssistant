using WorkAssistantApp.Data;
using WorkAssistantApp.Helpers;

namespace WorkAssistantApp.Controllers
{
    public class BaseController
    {
        protected readonly WorkAssistantDbContext dbContext;

        public BaseController(WorkAssistantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected long GetUser(long? userId) => userId ?? LoginUser();
        protected long LoginUser() => LoginUserToApp.Id;
    }
}
