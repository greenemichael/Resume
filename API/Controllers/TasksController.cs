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
    public class TasksController : Controller
    {
        private readonly ResumeContext _context;
        public TasksController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Tasks
            .Include(task => task.Experience)
            .Include(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .ToList();
        }

        [HttpGet("{id}")]
        public Task GetTaskByID(int id){
            return _context.Tasks
            .Include(task => (task.Experience))
            .Include(task => task.TSlist)
            .ThenInclude(taskskill => taskskill.Skill)
            .FirstOrDefault(task => task.ID == id);
        }
    }
}