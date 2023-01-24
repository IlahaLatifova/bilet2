
using AutoMapper;
using Bilet2._2.DAL;
using Bilet2._2.Models;
using Bilet2._2.ViewModels.TeamMemberViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bilet2._2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<TeamMember> members = await _context.teamMembers.ToListAsync();
            List<TeamGetVM> MembersGet = _mapper.Map < List < TeamGetVM >> (members);                                                                                                                       
            return View(MembersGet);
        }

    }
}