using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_Final_proj.Models;

namespace Student_Management_Final_proj.Controllers
{
   
    //Student controller uses  the user manager, sign in manager and role manager from
    //Identity framework 
    public class StudentsController : Controller
    {
        private readonly Student_Management_Data_Context _context;
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> signInManager;

        public StudentsController(Student_Management_Data_Context context,
             Student_Management_IdentityContext identityContext,
              UserManager<IdentityUser> userManager,
              SignInManager<IdentityUser> _signInManager
            )
        {
            var roleStore = new RoleStore<IdentityRole>(identityContext);
            _roleManager = new RoleManager<IdentityRole>(roleStore, null, null, null, null);
            _context = context;
            _userManager = userManager;
            signInManager = _signInManager;
        }

        // GET: Students
        //Gets all the students for admin but a sinlge student for currently logged in student.
        [Authorize(Roles = "course_admin,student")]
        public async Task<IActionResult> Index()
        {
            if (signInManager.IsSignedIn(User) && User.IsInRole("student")) {

                
                var Students = (from student in _context.Student
                                where student.Email.Equals(User.Identity.Name)
                                select student).ToList();

                return View(Students);
            }

            return View(await (from student in _context.Student select student).ToListAsync());
        }

        // GET: Students/Details/5
        //Gets the details of the student -course admin.
        [Authorize(Roles = "course_admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        //Get s the student create form -admin
        [Authorize(Roles = "course_admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates a student with a password and assign to student role.
        [Authorize(Roles = "course_admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("Id,Name,Email,Phone,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                 _context.SaveChanges();

                var user = new IdentityUser { UserName = student.Email, Email = student.Email };
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, student.Password);

                if (result.Succeeded)
                {
                    string studentRole = "student";


                    var roleExists = await _roleManager.RoleExistsAsync(studentRole);
                    if (!roleExists)
                    {
                        var roleReuslt = await _roleManager.CreateAsync(new IdentityRole(studentRole));

                        if (roleReuslt.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, studentRole);


                        }

                    }
                    else
                    {

                        await _userManager.AddToRoleAsync(user, studentRole);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        //Gets for update the student - student and admin
        [Authorize(Roles = "course_admin,student")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the student -student and admin
        [Authorize(Roles = "course_admin,student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Password")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                 var user =    await  _userManager.FindByEmailAsync(student.Email);

                    if (student.Password != null)
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, student.Password);
                    }
                   
                   await  _userManager.UpdateAsync(user);

                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        [Authorize(Roles = "course_admin")]
        // GET: Students/Delete/5
        //Gets for delete using a lamda 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5

        //Delets the student - admin
        [Authorize(Roles = "course_admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Checks the student exists using  a lamda 
        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
