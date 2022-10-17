using MeetingRommApp.Data;
using Microsoft.AspNetCore.Mvc;
using MeetingRoomApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MeetingRoomApp_MVC.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly MeetingRoomDbContext dbContext;

        public MeetingsController(MeetingRoomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Meeting> meetingList = dbContext.Meetings.ToList();
            return View(meetingList);
        }
    }
}
