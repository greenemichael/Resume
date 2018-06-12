using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.DataAccess;

namespace API.Controllers
{
    [Route("[controller]")]

    public class ExperiencesController : Controller
    {
        private readonly ResumeContext _context;
        public ExperiencesController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Experience> GetAllExperiences()
        {
            return _context.Experiences
            .Include(exp => exp.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .Where(e => !(e is Education || e is Activity))
            .ToList();
        }

        [HttpGet("{id}")]
        public Experience GetExcerienceByID(int id)
        {
            return _context.Experiences
            .Include(e => e.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .FirstOrDefault(e => e.ID == id);
        }

        [HttpGet("{title}")]
        public IEnumerable<Experience> GetExcerienceByTitle(string title)
        {
            return _context.Experiences
            .Include(e => e.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .Where(e => e.Title == title)
            .ToList();
        }
    }
}