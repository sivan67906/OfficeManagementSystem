﻿using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Configuration.ViewModels;

namespace OMS.UI.Areas.Configuration.Controllers;
[Area("Configuration")]
public class PlanTypeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public PlanTypeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> PlanType()
    {
        // Page Title
        ViewData["pTitle"] = "PlanTypes Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "PlanType";
        ViewData["bChild"] = "PlanType";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var planTypeList = await client.GetFromJsonAsync<List<PlanTypeVM>>("PlanType/GetAll");

        return View(planTypeList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        PlanTypeVM planType = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        return PartialView("_Create", planType);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PlanTypeVM planType)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<PlanTypeVM>("PlanType/Create", planType);
        return RedirectToAction("PlanType");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var planType = await client.GetFromJsonAsync<PlanTypeVM>("PlanType/GetById/?Id=" + Id);
        return PartialView("_Edit", planType);
    }

    [HttpPost]
    public async Task<IActionResult> Update(PlanTypeVM planType)
    {
        if (planType.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<PlanTypeVM>("PlanType/Update/", planType);
        return RedirectToAction("PlanType");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("PlanType/Delete?Id=" + Id);
        return RedirectToAction("PlanType");
    }
}