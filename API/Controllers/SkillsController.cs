using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using API.DataAccess;

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

        [HttpGet]
        public IEnumerable<Skill> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        [HttpGet("{id}")]
        public Skill GetSkillByID(int id){
            return _context.Skills.FirstOrDefault(s => s.ID == id);
        }
    }
}