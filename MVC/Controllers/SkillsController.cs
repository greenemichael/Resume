using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

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
            var strskill = new StringContent(JsonConvert.SerializeObject(skill));
            
            var httpresponse = await client.PostAsync(_apiConnection.Value.BaseURL + "Skills/Create/", strskill);
            //var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
    }
}