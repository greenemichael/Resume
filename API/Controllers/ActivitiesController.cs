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

        [HttpGet]
        public IEnumerable<Experience> GetAllActivities()
        {
            return _context.Activities
            .Include(exp => exp.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .ToList();
        }

        [HttpGet("{id}")]
        public Experience GetActivityByID(int id){
            return _context.Activities
            .Include(e => e.Tasks)
            .ThenInclude(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .FirstOrDefault(e => e.ID == id);
        }
    }
}