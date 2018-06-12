using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.DataAccess;

namespace API.DataAccess
{
    public class ResumeInitializer
    {
        public static void Initialize(ResumeContext context)
        {
            context.Database.EnsureCreated();
            if (context.Experiences.Any()){return;} // make a stronger check here?

            ///create and save a group of skills (bottom level)
            Skill csharp = new Skill {Name = "C#", Description = "Web application development in C# (front-end and back-end)"};
            Skill dotnet = new Skill {Name = "ASP.NET Core", Description = "Development in ASP.NET Core using Web API and MVC patterns"};
            Skill sql = new Skill {Name = "SQL", Description = "Design and implementation of a back-end SQL database in Visual Studio"};
            Skill js = new Skill {Name = "JavaScript", Description = "Front-end client development with enhancements, includes AngularJS, JQuery, and AJAX"};
            Skill python = new Skill {Name = "Python", Description = "Data mining with Numpy, Scikit-Learn, etc."};
            Skill frontend = new Skill {Name = "HTML / CSS", Description = "Front-end client development, includes BootStrap"};

            context.Skills.AddRange(new Skill[] {csharp, dotnet, sql, js, python, frontend});
            context.SaveChanges();

            //create and save experiences / education (top layer)
            Experience softwareDevIntern = new Experience {Institution = "Hennepin County Government", Title = "Software Development Intern", 
            Start = new DateTime(2017, 5, 1), End = new DateTime(2017, 11, 1) ,Tasks = new List<Task>()}; // responsibility list must be initialized to add to later
            Experience dataArchitectureIntern = new Experience {Institution = "Hennepin County Government", Title = "Data Architecture Intern", 
            Start = new DateTime(2017, 11, 1), Tasks = new List<Task>()};

            context.Experiences.AddRange(new Experience[] {softwareDevIntern, dataArchitectureIntern});
            context.SaveChanges();

            Education undergrad = new Education {Institution = "U of MN- Twin Cities", Title = "Computer Science", Degree="Bachelor of Science",
            Start = new DateTime(2014, 9, 1), Tasks = new List<Task>()};

            context.Education.Add(undergrad);
            context.SaveChanges();

            Activity vhlab = new Activity {Institution = "U of MN- Twin Cities", Title ="Volunteer", Group = "Visible Heart Medical Research Lab",
            Start = new DateTime(2016, 3, 1), Tasks = new List<Task>()};

            context.Activities.Add(vhlab);
            context.SaveChanges();

            //create and save tasks (got by experiences/education)
            Task t1 = new Task {Description = "Write code to build and customize a REST client; Keep client in sync with API changes", 
            ExperienceID = 1, TSlist = new List<TaskSkill>()}; // initialize skills to be added to later

            Task t2 = new Task {Description = "Meet with product owners weekly to report progress and refine product designs", 
            ExperienceID = 1, TSlist = new List<TaskSkill>()};
        
            Task t3 = new Task {Description = "Design and implement a SQL database in Visual Studio", 
            ExperienceID = 2, TSlist = new List<TaskSkill>()};

            Task t4 = new Task {Description = "Design and implement a Web API to interact with a SQL database", 
            ExperienceID = 2, TSlist = new List<TaskSkill>()};
        
            Task t5 = new Task {Description = "Design and implement a REST client to access a database via an API", 
            ExperienceID = 2, TSlist = new List<TaskSkill>()};

            Task t6 = new Task{Description = "Use maching learning to prescribe and evaluate the emergency response to Hurricane Harvey",
            ExperienceID = 3, TSlist = new List<TaskSkill>()};

            Task t7 = new Task{Description = "Use Artificial Intelligence to enhance security cameras with audio emotional sensors",
            ExperienceID = 3, TSlist = new List<TaskSkill>()};

            Task t8 = new Task{Description = "Assist in making image segmentation network; segmented images significantly speed up 3D printing",
            ExperienceID = 4, TSlist = new List<TaskSkill>()};

            Task t9 = new Task{Description = "Create web service to manage experiments and their data",
            ExperienceID = 4, TSlist = new List<TaskSkill>()};

            context.Tasks.AddRange(new Task[] {t1, t2, t3, t4, t5, t6, t7, t8, t9});
            context.SaveChanges();

            //create task/skill bridges
            TaskSkill ts1 = new TaskSkill {TaskID = 1, SkillID = 4};
            TaskSkill ts2 = new TaskSkill {TaskID = 1, SkillID = 6};
            TaskSkill ts3 = new TaskSkill {TaskID = 3, SkillID = 3};
            TaskSkill ts4 = new TaskSkill {TaskID = 4, SkillID = 1};
            TaskSkill ts5 = new TaskSkill {TaskID = 4, SkillID = 2};
            TaskSkill ts6 = new TaskSkill {TaskID = 4, SkillID = 3};
            TaskSkill ts7 = new TaskSkill {TaskID = 5, SkillID = 1};
            TaskSkill ts8 = new TaskSkill {TaskID = 5, SkillID = 2};
            TaskSkill ts9 = new TaskSkill {TaskID = 5, SkillID = 6};
            TaskSkill ts10 = new TaskSkill {TaskID = 6, SkillID = 5};
            TaskSkill ts11 = new TaskSkill {TaskID = 7, SkillID = 5};
            TaskSkill ts12 = new TaskSkill {TaskID = 8, SkillID = 5};
            TaskSkill ts13 = new TaskSkill {TaskID = 9, SkillID = 4};
            TaskSkill ts14 = new TaskSkill {TaskID = 9, SkillID = 6};

            context.TSlist.AddRange(new TaskSkill[] {ts1, ts2, ts3, ts4, ts5, ts6, ts7, ts8, ts9, ts10, ts11, ts12, ts13, ts14});
            context.SaveChanges();
        }
    }
}
