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
    public class ActivitiesController : Controller
    {
        private HttpClient client;
        private readonly IOptions<APIConnection> _apiConnection;

        public ActivitiesController(IOptions<APIConnection> apiConnection)
        {
            _apiConnection = apiConnection;
            client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var httpresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Activities");
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            var activities = JsonConvert.DeserializeObject<List<Activity>>(httpcontent);
            return View(activities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var httpresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Activities/" + id);
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            var activity = JsonConvert.DeserializeObject<Activity>(httpcontent);
            return View(activity);
        }
    }
}