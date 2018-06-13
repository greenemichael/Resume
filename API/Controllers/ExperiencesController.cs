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

        [HttpGet(Name = "GetAllExperiences")]
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
        public Experience GetExperienceByID(int id)
        {
            return _context.Experiences
            .Include(e => e.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .FirstOrDefault(e => e.ID == id);
        }

        [HttpGet("{title}")]
        public IEnumerable<Experience> GetExperienceByTitle(string title)
        {
            return _context.Experiences
            .Include(e => e.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .Where(e => e.Title == title)
            .ToList();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return CreatedAtRoute("GetAllExperiences", experience);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateExperience(int id, Experience experience)
        {
            var dbexperience = _context.Experiences.Find(id);
            if (dbexperience == null) { return NotFound(); }

            dbexperience.Institution = experience.Institution;
            dbexperience.Title = experience.Title;
            dbexperience.Start = experience.Start;
            dbexperience.End = experience.End;

            _context.Experiences.Update(dbexperience);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExperience(int id)
        {
            var dbexperience = _context.Experiences.Find(id);
            if (dbexperience == null) { return NotFound(); }

            _context.Experiences.Remove(dbexperience);
            _context.SaveChanges();
            return NoContent();
        }
    }
}