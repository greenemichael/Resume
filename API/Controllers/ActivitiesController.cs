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

    public class ActivitiesController : Controller
    {
        private readonly ResumeContext _context;
        public ActivitiesController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllActivities")]
        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities
            .Include(act => act.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .ToList();
        }

        [HttpGet("{id}")]
        public Activity GetActivityByID(int id){
            return _context.Activities
            .Include(act => act.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .FirstOrDefault(act => act.ID == id);
        }

        [HttpPost]
        public IActionResult CreateActivity(Activity act)
        {
            _context.Activities.Add(act);
            _context.SaveChanges();
            return CreatedAtRoute("GetAllActivities", act);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActivity(int id, Activity act)
        {
            var dbact = _context.Activities.Find(id);
            if (dbact == null) { return NotFound(); }

            dbact.Institution = act.Institution;
            dbact.Title = act.Title;
            dbact.Group = act.Group;
            dbact.Start = act.Start;
            dbact.End = act.End;

            _context.Activities.Update(dbact);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(int id)
        {
            var dbact = _context.Activities.Find(id);
            if (dbact == null) { return NotFound(); }

            _context.Activities.Remove(dbact);
            _context.SaveChanges();
            return NoContent();
        }
    }
}