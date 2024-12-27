﻿using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class TaxController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public TaxController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Tax()
    {
        // Page Title
        ViewData["pTitle"] = "Taxes Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Tax";
        ViewData["bChild"] = "Tax View";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var taxList = await client.GetFromJsonAsync<List<TaxVM>>("Tax/GetAll");

        return View(taxList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        TaxVM tax = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        return PartialView("_Create", tax);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaxVM tax)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<TaxVM>("Tax/Create", tax);
        return RedirectToAction("Tax");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var tax = await client.GetFromJsonAsync<TaxVM>("Tax/GetById/?Id=" + Id);
        return PartialView("_Edit", tax);
    }

    [HttpPost]
    public async Task<IActionResult> Update(TaxVM tax)
    {
        if (tax.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<TaxVM>("Tax/Update/", tax);
        return RedirectToAction("Tax");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var tax = await client.GetFromJsonAsync<TaxVM>("Tax/GetById/?Id=" + Id);
        return PartialView("_Delete", tax);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(TaxVM tax)
    {
        if (tax.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("Tax/Delete?Id=" + tax.Id);
        return RedirectToAction("Tax");
    }
}
