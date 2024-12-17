﻿using OMS.UI.Areas.Settings.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace OMS.UI.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class LeadAgentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LeadAgentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> LeadAgent(string searchQuery = null)
        {
            var client = _httpClientFactory.CreateClient("ApiGatewayCall");
            //var productList = await client.GetFromJsonAsync<List<ProductVM>>("Product/GetAll");

            List<LeadAgentVM> productList;

            if (string.IsNullOrEmpty(searchQuery))
            {
                // Fetch all products if no search query is provided
                productList = await client.GetFromJsonAsync<List<LeadAgentVM>>("LeadAgent/GetAll");
            }
            else
            {
                // Fetch products matching the search query
                productList = await client.GetFromJsonAsync<List<LeadAgentVM>>($"LeadAgent/SearchByName?name={searchQuery}");
            }
            ViewData["searchQuery"] = searchQuery; // Retain search query
            return View(productList);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            LeadAgentVM product = new();
            return PartialView("_Create", product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeadAgentVM product)
        {
            var client = _httpClientFactory.CreateClient("ApiGatewayCall");
            await client.PostAsJsonAsync<LeadAgentVM>("LeadAgent/Create", product);
            return RedirectToAction("LeadAgent");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ApiGatewayCall");
            var product = await client.GetFromJsonAsync<LeadAgentVM>("LeadAgent/GetById/?Id=" + Id);
            return PartialView("_Edit", product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LeadAgentVM product)
        {
            if (product.Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ApiGatewayCall");
            await client.PutAsJsonAsync<LeadAgentVM>("LeadAgent/Update/", product);
            return RedirectToAction("LeadAgent");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ApiGatewayCall");
            var product = await client.GetFromJsonAsync<LeadAgentVM>("LeadAgent/GetById/?Id=" + Id);
            return PartialView("_Delete", product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LeadAgentVM product)
        {
            if (product.Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ApiGatewayCall");
            var productList = await client.DeleteAsync("LeadAgent/Delete?Id=" + product.Id);
            return RedirectToAction("LeadAgent");
        }
    }
}
