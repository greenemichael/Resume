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

        [HttpGet(Name = "GetAllTasks")]
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

        [HttpPost]
        public IActionResult CreateTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return CreatedAtRoute("GetAllTasks", task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task task)
        {
            var dbtask = _context.Tasks.Find(id);
            if (dbtask == null) { return NotFound(); }

            dbtask.Description = task.Description;

            _context.Tasks.Update(dbtask);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var dbtask = _context.Tasks.Find(id);
            if (dbtask == null) { return NotFound(); }

            _context.Tasks.Remove(dbtask);
            _context.SaveChanges();

            return NoContent();
        }
    }
}