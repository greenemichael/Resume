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

    public class EducationController : Controller
    {
        private readonly ResumeContext _context;
        public EducationController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllEducation")]
        public IEnumerable<Education> GetAllEducation()
        {
            return _context.Education
            .Include(e => e.Tasks)
            .ThenInclude(t => t.TSlist)
            .ThenInclude(ts => ts.Skill)
            .ToList();
        }

        [HttpGet("{id}")]
        public Education GetEducationByID(int id)
        {
            return _context.Education
            .Include(e => e.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .FirstOrDefault(e => e.ID == id);
        }

        [HttpPost]
        public IActionResult CreateEducation(Education edu)
        {
            _context.Education.Add(edu);
            _context.SaveChanges();
            return CreatedAtRoute("GetAll", edu);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEducation(int id, Education edu)
        {
            var dbedu = _context.Education.Find(id);
            if (dbedu == null) { return NotFound(); }

            dbedu.Institution = edu.Institution;
            dbedu.Title = edu.Title;
            dbedu.Degree = edu.Degree;
            dbedu.Start = edu.Start;
            dbedu.End = edu.End;

            _context.Education.Update(dbedu);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEducation(int id)
        {
            var dbedu = _context.Education.Find(id);
            if (dbedu == null) { return NotFound(); }

            _context.Education.Remove(dbedu);
            _context.SaveChanges();
            return NoContent();
        }
    }
}