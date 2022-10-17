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
    public class MeetingRoomTypesController : Controller
    {
        private readonly MeetingRoomDbContext _context;

        public MeetingRoomTypesController(MeetingRoomDbContext context)
        {
            _context = context;
        }

        // GET: MeetingRoomTypes
        public IActionResult Index()
        {
            return View( _context.MeetingRoomTypes.ToList());
        }

        // GET: MeetingRoomTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoomType = await _context.MeetingRoomTypes
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (meetingRoomType == null)
            {
                return NotFound();
            }

            return View(meetingRoomType);
        }

        // GET: MeetingRoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeetingRoomTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomTypeId,RoomType")] MeetingRoomType meetingRoomType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingRoomType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingRoomType);
        }

        // GET: MeetingRoomTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoomType = await _context.MeetingRoomTypes.FindAsync(id);
            if (meetingRoomType == null)
            {
                return NotFound();
            }
            return View(meetingRoomType);
        }

        // POST: MeetingRoomTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomTypeId,RoomType")] MeetingRoomType meetingRoomType)
        {
            if (id != meetingRoomType.RoomTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingRoomType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingRoomTypeExists(meetingRoomType.RoomTypeId))
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
            return View(meetingRoomType);
        }

        // GET: MeetingRoomTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRoomType = await _context.MeetingRoomTypes
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (meetingRoomType == null)
            {
                return NotFound();
            }

            return View(meetingRoomType);
        }

        // POST: MeetingRoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingRoomType = await _context.MeetingRoomTypes.FindAsync(id);
            _context.MeetingRoomTypes.Remove(meetingRoomType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingRoomTypeExists(int id)
        {
            return _context.MeetingRoomTypes.Any(e => e.RoomTypeId == id);
        }
    }
}
