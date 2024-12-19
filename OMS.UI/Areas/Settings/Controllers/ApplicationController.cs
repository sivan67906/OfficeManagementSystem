﻿using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class ApplicationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ApplicationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Application()
    {
        // Page Title
        ViewData["pTitle"] = "Application Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Application";
        ViewData["bChild"] = "Application View";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var ApplicatonList = await client.GetFromJsonAsync<List<ApplicationVM>>("Application/GetAll");
        ViewBag.DefaultCurrency = await client.GetFromJsonAsync<List<CurrencyVM>>("Currency/GetAll");
        return View(ApplicatonList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ApplicationVM application = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        ViewBag.DefaultCurrency = await client.GetFromJsonAsync<List<CurrencyVM>>("Currency/GetAll");
        return PartialView("_Create", application);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ApplicationVM application)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<ApplicationVM>("Application/Create", application);
        return RedirectToAction("Application");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        ViewBag.DefaultCurrency = await client.GetFromJsonAsync<List<CurrencyVM>>("Currency/GetAll");
        var application = await client.GetFromJsonAsync<CurrencyVM>("Application/GetById/?Id=" + Id);
        return PartialView("_Edit", application);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ApplicationVM application)
    {
        if (application.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<ApplicationVM>("Application/Update/", application);
        return RedirectToAction("Application");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        ViewBag.DefaultCurrency = await client.GetFromJsonAsync<List<CurrencyVM>>("Application/GetAll");
        var application = await client.GetFromJsonAsync<ApplicationVM>("Application/GetById/?{Id}=" + Id);
        return PartialView("_Delete", application);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ApplicationVM application)
    {
        if (application.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("Application/Delete?Id=" + application.Id);
        return RedirectToAction("Application");
    }

    //[HttpPost]
    //public async Task<IActionResult> Delete(CompanyVM company)
    //{
    //    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    //    {
    //        WriteIndented = true
    //    };
    //    string forecastJson = JsonSerializer.Serialize<CompanyVM>(company, options);

    //    if (company.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    var companyList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "Company/Delete", company);
    //    return RedirectToAction("Company");
    //}

    //public async Task<HttpResponseMessage> Deletewithresponse(string url, object entity)
    //{
    //    using (var client = new HttpClient())
    //    {
    //        var json = JsonSerializer.Serialize(entity);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");

    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Delete,
    //            RequestUri = new Uri(url),
    //            Content = content
    //        };
    //        return await client.SendAsync(request);
    //    }
    //}
}
