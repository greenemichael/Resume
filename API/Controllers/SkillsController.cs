using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using API.DataAccess;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("[controller]")]
    public class SkillsController : Controller
    {
        private readonly ResumeContext _context;
        public SkillsController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllSkills")]
        public IEnumerable<Skill> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        [HttpGet("{id}")]
        public Skill GetSkillByID(int id){
            return _context.Skills.FirstOrDefault(s => s.ID == id);
        }

        [HttpPost()]
        public IActionResult CreateSkill([FromBody] Skill skill)
        { // [FromBody] to indicate where to get the data for model binding
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return CreatedAtRoute("GetAllSkills", new {id = skill.ID}, skill);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSkill(int id, Skill skill)
        {
            var dbskill = _context.Skills.Find(id);
            if (dbskill == null) { return NotFound(); }

            dbskill.Name = skill.Name;
            dbskill.Description = skill.Description;

            _context.Skills.Update(dbskill);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            var dbskill = _context.Skills.Find(id);
            if (dbskill == null) { return NotFound(); }

            _context.Skills.Remove(dbskill);
            _context.SaveChanges();
            return NoContent();
        }
    }
}