using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.DataAccess
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options){}

        public DbSet<Experience> Experiences {get; set;}
        public DbSet<Education> Education {get; set;}
        public DbSet<Activity> Activities {get; set;}
        public DbSet<Task> Tasks {get; set;}
        public DbSet<Skill> Skills {get; set;}
        public DbSet<TaskSkill> TSlist {get; set;}
    }
}