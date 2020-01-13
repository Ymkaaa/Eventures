using Eventures.App.Models;
using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Eventures.App.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventuresDbContext context;

        public EventsController(EventuresDbContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(EventCreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            Event eventForDb = new Event()
            {
                Name = bindingModel.Name,
                Place = bindingModel.Place,
                Start = bindingModel.Start,
                End = bindingModel.End,
                TotalTickets = bindingModel.TotalTickets,
                PricePerTicket = bindingModel.PricePerTicket
            };

            context.Events.Add(eventForDb);
            context.SaveChanges();

            return this.Redirect("/Events/All");
        }

        [Authorize]
        public IActionResult All()
        {
            List<EventAllViewModel> events = context.Events.Select(e => new EventAllViewModel()
            {
                Name = e.Name,
                Place = e.Place,
                Start = e.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                End = e.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture)
            }).ToList();

            return this.View(events);
        }
    }
}
