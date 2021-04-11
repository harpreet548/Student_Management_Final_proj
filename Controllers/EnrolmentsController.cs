using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_Final_proj.Models;

namespace Student_Management_Final_proj.Controllers
{
    //Entrolment controller for permissions geven only for course_admin
    [Authorize(Roles = "course_admin")]
    public class EnrolmentsController : Controller
    {
        private readonly Student_Management_Data_Context _context;

        public EnrolmentsController(Student_Management_Data_Context context)
        {
            _context = context;
        }

        // GET: Enrolments
        //Get all enrolments using a lamda 
        public async Task<IActionResult> Index()
        {
            var student_Management_Data_Context = _context.Enrolment.Include(e => e.Course).Include(e => e.Student);
            return View(await student_Management_Data_Context.ToListAsync());
        }

        // GET: Enrolments/Details/5
        //Gets  details using a lamda 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // GET: Enrolments/Create
        //Gets the create enrollment form.
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseCode");
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "StudentRegistrationId");
            return View();
        }

        // POST: Enrolments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the enrolment.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId,StartDate,EndDate")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", enrolment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Id", enrolment.StudentId);
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        //Gets the entrolment for edit using a linq query
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await (from enrol in _context.Enrolment
                             where enrol.Id == id
                             select enrol).FirstOrDefaultAsync();
            if (enrolment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseCode", enrolment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "StudentRegistrationId", enrolment.StudentId);
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the enrolment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,StartDate,EndDate")] Enrolment enrolment)
        {
            if (id != enrolment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolmentExists(enrolment.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", enrolment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Id", enrolment.StudentId);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        //Gets the enrolment for delete using a lamda
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        //Deletes the enrolment.
        // POST: Enrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolment = await _context.Enrolment.FindAsync(id);
            _context.Enrolment.Remove(enrolment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Checks the enrolment.
        private bool EnrolmentExists(int id)
        {
            return _context.Enrolment.Any(e => e.Id == id);
        }
    }
}
