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
    public class EducationController : Controller
    {
        private HttpClient client;
        private readonly IOptions<APIConnection> _apiConnection;

        public EducationController(IOptions<APIConnection> apiConnection)
        {
            _apiConnection = apiConnection;
            client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var httpresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Education");
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            var education = JsonConvert.DeserializeObject<List<Education>>(httpcontent);
            return View(education);
        }

        public async Task<IActionResult> Details(int id)
        {
            var httpresponse = await client.GetAsync(_apiConnection.Value.BaseURL + "Education/" + id);
            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            var education = JsonConvert.DeserializeObject<Education>(httpcontent);
            return View(education);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateEducation(Education edu)
        {
            edu.Tasks = new List<MVC.Models.Task>();
            var json = JsonConvert.SerializeObject(edu);
            var strEdu = new StringContent(json);

            // header is needed to call the proper API action
            strEdu.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpresponse = await client.PostAsync
            (
                _apiConnection.Value.BaseURL + "Education/", strEdu
            );

            var httpcontent = await httpresponse.Content.ReadAsStringAsync();
            return RedirectToAction("Index", "Education");
        }
    }
}