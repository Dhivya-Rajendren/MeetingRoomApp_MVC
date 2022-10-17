using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingRommApp.Data;
using MeetingRoomApp.Domain;

namespace MeetingRoomApp_MVC.Controllers
{
    public class MeetingRoomsController : Controller
    {
        private readonly MeetingRoomDbContext _context;

        public MeetingRoomsController(MeetingRoomDbContext context)
        {
            _context = context;
        }

        // GET: MeetingRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeetingRooms.ToListAsync());
        }

        // GET: MeetingRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoom = await _context.MeetingRooms
                .FirstOrDefaultAsync(m => m.RoomNo == id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            return View(meetingRoom);
        }

        // GET: MeetingRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeetingRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNo,RoomName,RoomTypeId,Location")] MeetingRoom meetingRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingRoom);
        }

        // GET: MeetingRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoom = await _context.MeetingRooms.FindAsync(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }
            return View(meetingRoom);
        }

        // POST: MeetingRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomNo,RoomName,RoomTypeId,Location")] MeetingRoom meetingRoom)
        {
            if (id != meetingRoom.RoomNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingRoomExists(meetingRoom.RoomNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meetingRoom);
        }

        // GET: MeetingRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoom = await _context.MeetingRooms
                .FirstOrDefaultAsync(m => m.RoomNo == id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            return View(meetingRoom);
        }

        // POST: MeetingRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingRoom = await _context.MeetingRooms.FindAsync(id);
            _context.MeetingRooms.Remove(meetingRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingRoomExists(int id)
        {
            return _context.MeetingRooms.Any(e => e.RoomNo == id);
        }
    }
}
