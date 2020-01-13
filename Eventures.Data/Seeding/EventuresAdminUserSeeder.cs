using Eventures.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Eventures.Data.Seeding
{
    public class EventuresAdminUserSeeder : ISeeder
    {
        private readonly EventuresDbContext context;
        private readonly UserManager<EventuresUser> userManager;

        public EventuresAdminUserSeeder(EventuresDbContext context, UserManager<EventuresUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public void Seed()
        {
            //TODO
        }
    }
}
