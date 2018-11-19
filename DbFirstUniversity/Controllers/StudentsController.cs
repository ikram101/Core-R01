using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirstUniversity.Models;
using DbFirstUniversity.Data;

namespace DbFirstUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UnitOfWork _context;

        public StudentsController(UniversityContext context)
        {
            _context = new UnitOfWork(new UniversityContext());
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(_context.Students.GetAll());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student1 = _context.Students.Get(id);
            if (student1 == null)
            {
                return NotFound();
            }
            return View(student1);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var studentToUpdate = _context.Students.Get(id);

                    studentToUpdate.FirstMidName = student.FirstMidName;
                    studentToUpdate.LastName = student.LastName;
                    _context.Save();
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

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
             
            var student = _context.Students.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = _context.Students.Get(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.Save();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            var exists = _context.Students.SingleOrDefault(e => e.Id == id);

            if (exists != null)
            {
                return true;
            }

            return false;

        }
    }
}
