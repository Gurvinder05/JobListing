using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobListing.Data;
using JobListing.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobListing.Controllers
{
    public class JobSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobSkills
        /// <summary>
        /// Index page which will display listing ok Skills for a Job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            var applicationDbContext = _context.JobSkills.Include(j => j.Job).Include(j => j.Skill).Where(js=>js.JobID == id);
            ViewData["JobID"] = id;
            ViewData["JobName"] = job.Name;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobSkills/Details/5
        /// <summary>
        /// Details page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSkill = await _context.JobSkills
                .Include(j => j.Job)
                .Include(j => j.Skill)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jobSkill == null)
            {
                return NotFound();
            }

            return View(jobSkill);
        }

        // GET: JobSkills/Create
        /// <summary>
        /// Create GET Controller action
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Create(int? jobID)
        {
            if (jobID == null)
            {
                return NotFound();
            }
            ViewData["ParamId"] = jobID;
            ViewData["JobID"] = new SelectList(_context.Jobs.Where(i=>i.ID== jobID), "ID", "Name");
            ViewData["SkillID"] = new SelectList(_context.Skills, "ID", "SkillName");
            return View();
        }

        // POST: JobSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create POST controller action
        /// </summary>
        /// <param name="jobSkill"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID,JobID,SkillID")] JobSkill jobSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = jobSkill.JobID });
            }
            ViewData["ParamId"] = jobSkill.JobID;
            ViewData["JobID"] = new SelectList(_context.Jobs.Where(i => i.ID == jobSkill.JobID), "ID", "Name", jobSkill.JobID);
            ViewData["SkillID"] = new SelectList(_context.Skills, "ID", "SkillName", jobSkill.SkillID);
            return View(jobSkill);
        }

        // GET: JobSkills/Edit/5
        /// <summary>
        /// Edit GET Controller action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSkill = await _context.JobSkills.FindAsync(id);
            if (jobSkill == null)
            {
                return NotFound();
            }
            ViewData["ParamId"] = jobSkill.JobID;
            ViewData["JobID"] = new SelectList(_context.Jobs.Where(i => i.ID == jobSkill.JobID), "ID", "Name", jobSkill.JobID);
            ViewData["SkillID"] = new SelectList(_context.Skills, "ID", "SkillName", jobSkill.SkillID);
            return View(jobSkill);
        }

        // POST: JobSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit POST Controller action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobSkill"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,JobID,SkillID")] JobSkill jobSkill)
        {
            if (id != jobSkill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobSkillExists(jobSkill.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = jobSkill.JobID });
            }
            ViewData["ParamId"] = jobSkill.JobID;
            ViewData["JobID"] = new SelectList(_context.Jobs.Where(i => i.ID == jobSkill.JobID), "ID", "Name", jobSkill.JobID);
            ViewData["SkillID"] = new SelectList(_context.Skills, "ID", "SkillName", jobSkill.SkillID);
            return View(jobSkill);
        }

        // GET: JobSkills/Delete/5
        /// <summary>
        /// Delete GET Controller Action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSkill = await _context.JobSkills
                .Include(j => j.Job)
                .Include(j => j.Skill)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jobSkill == null)
            {
                return NotFound();
            }

            ViewData["ParamId"] = jobSkill.JobID;
            return View(jobSkill);
        }

        // POST: JobSkills/Delete/5
        /// <summary>
        /// Delete POST Controller action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobSkill = await _context.JobSkills.FindAsync(id);

            ViewData["ParamId"] = jobSkill.JobID;
            _context.JobSkills.Remove(jobSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = jobSkill.JobID });
        }

        private bool JobSkillExists(int id)
        {
            return _context.JobSkills.Any(e => e.ID == id);
        }
    }
}
