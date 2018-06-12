using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client;
        private readonly IOptions<APIConnection> _apiConnection;

        public HomeController(IOptions<APIConnection> apiConnection)
        {
            _apiConnection = apiConnection;
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var expresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Experiences");
            var expcontent = await expresponse.Content.ReadAsStringAsync();
            var experiences = JsonConvert.DeserializeObject<List<Experience>>(expcontent);

            var eduresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Education");
            var educontent = await eduresponse.Content.ReadAsStringAsync();
            var education = JsonConvert.DeserializeObject<List<Education>>(educontent);

            var actresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Activities");
            var actcontent = await actresponse.Content.ReadAsStringAsync();
            var activities = JsonConvert.DeserializeObject<List<MVC.Models.Activity>>(actcontent);

            var skillresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Skills");
            var skillcontent = await skillresponse.Content.ReadAsStringAsync();
            var skills = JsonConvert.DeserializeObject<List<Skill>>(skillcontent);
            return View(new ResumeVM {Experiences = experiences, Education = education, Skills = skills, Activities = activities});
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
