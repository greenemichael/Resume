using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class SkillsController : Controller
    {
        private HttpClient client;
        private readonly IOptions<APIConnection> _apiConnection;

        public SkillsController(IOptions<APIConnection> apiConnection)
        {
            _apiConnection = apiConnection;
            client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var httpresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Skills");
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            var skills = JsonConvert.DeserializeObject<List<Skill>>(httpcontent);
            return View(skills);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            var json = JsonConvert.SerializeObject(skill);
            var strskill = new StringContent(json);

            //without headers the PostAsync method wont call the right API action
            strskill.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var httpresponse = await client.PostAsync
            (
                _apiConnection.Value.BaseURL + "Skills/", strskill
            );
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            return RedirectToAction("Index", "Skills");
        }

        public async Task<IActionResult> DeleteSkill(Skill skill)
        {
            var httpresponse = await client.DeleteAsync
            (
                _apiConnection.Value.BaseURL + "Skills/" + skill.ID
            );
            return RedirectToAction("Index", "Skills");
        }
    }
}