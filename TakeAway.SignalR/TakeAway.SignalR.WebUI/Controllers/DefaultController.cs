﻿using Microsoft.AspNetCore.Mvc;

namespace TakeAway.SignalR.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController ( IHttpClientFactory httpClientFactory )
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index ()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7039/api/Deliveries/GetTotalPrice");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonData;


            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7039/api/Deliveries/GetTotalDelivery");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData1;
            return View();
        }
    }
}
