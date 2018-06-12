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
    public class ExperiencesController : Controller
    {
        private HttpClient client;
        private readonly IOptions<APIConnection> _apiConnection;

        public ExperiencesController(IOptions<APIConnection> apiConnection)
        {
            _apiConnection = apiConnection;
            client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var httpresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Experiences/");
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            var experiences = JsonConvert.DeserializeObject<List<Experience>>(httpcontent);
            return View(experiences);
        }

        public async Task<IActionResult> Details(int id)
        {
            var httpresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Experiences/" + id);
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            var experience = JsonConvert.DeserializeObject<Experience>(httpcontent);
            return View(experience);
        }
    }
}