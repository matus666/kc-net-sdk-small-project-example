using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KcNetSdkSmallProjectExample.Models;
using KenticoCloud.Delivery;

namespace KcNetSdkSmallProjectExample.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Persons()
        {
            var persons = await Client.GetItemsAsync(
                new EqualsFilter("system.type", "person")
            );


            return View(persons.Items);
        }

        public async Task<IActionResult> Person(string id)
        {
            var person = (await Client.GetItemsAsync(
                    new EqualsFilter("system.type", "person"),
                    new EqualsFilter("elements.url_slug", id))
                )
                .Items
                .FirstOrDefault();


            return View(person);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
