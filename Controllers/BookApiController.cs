using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QL_Sach.Models;

namespace QL_Sach.Controllers
{
    public class BookApiController : Controller
    {
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/book").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<Book> data = JsonConvert.DeserializeObject<List<Book>>(stringData);
                return View(data);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string stringData = JsonConvert.SerializeObject(obj);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("/api/book", contentData).Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                return View(obj);
            }
        }
        public ActionResult Update(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                HttpResponseMessage response = client.GetAsync("/api/book/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Book data = JsonConvert.DeserializeObject<Book>(stringData);
                return View(data);
            }
        }

        [HttpPost]
        public ActionResult Update(Book obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                string stringData = JsonConvert.SerializeObject(obj);
                var contentData = new StringContent(stringData,System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("/api/book/" + obj.Id,contentData).Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                return View(obj);
            }
        }
    }
}