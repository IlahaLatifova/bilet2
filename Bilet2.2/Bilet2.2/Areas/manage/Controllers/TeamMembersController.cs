using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bilet2._2.DAL;
using Bilet2._2.Models;
using Bilet2._2.ViewModels.TeamMemberViewModels;
using AutoMapper;
using Bilet2._2.Extensions.FormFileExtensions;

namespace Bilet2._2.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamMembersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public TeamMembersController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        // GET: manage/TeamMembers
        public async Task<IActionResult> Index()
        {
              return View(await _context.teamMembers.ToListAsync());
        }

      
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamPostVM teamPost)
        {
            if (!ModelState.IsValid)
            {
                return View(teamPost);  
            }
           
            TeamMember member = _mapper.Map<TeamMember>(teamPost);
            if(teamPost.formFile is not null)
            {
                if (!teamPost.formFile.IsTrueContent())
                {
                    ModelState.AddModelError("FormFile", "This format is not true!!!");
                    return View(teamPost);
                }
                if (!teamPost.formFile.IsValidLength())
                {
                    ModelState.AddModelError("FormFile", "Length must be less than 2mb.");
                }
                member.ImageUrl = teamPost.formFile.SaveUrl(_env.WebRootPath, "assets/img");
            }

            await _context.AddAsync(teamPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {

            TeamMember teamMember = await _context.teamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            TeamUpdateVM teamUpdate = new TeamUpdateVM()
            {
                TeamGet = _mapper.Map<TeamGetVM>(teamMember)
            };
            return View(teamUpdate);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TeamUpdateVM teamUpdate)
        {
            TeamMember teamMember = await _context.teamMembers.FindAsync(teamUpdate.TeamGet.Id);
            if (teamMember == null)
            {
                return NotFound();
            }


        }

        // GET: manage/TeamMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.teamMembers == null)
            {
                return NotFound();
            }

            var teamMember = await _context.teamMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // POST: manage/TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.teamMembers == null)
            {
                return Problem("Entity set 'AppDbContext.teamMembers'  is null.");
            }
            var teamMember = await _context.teamMembers.FindAsync(id);
            if (teamMember != null)
            {
                teamMember.IsDeleted = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
