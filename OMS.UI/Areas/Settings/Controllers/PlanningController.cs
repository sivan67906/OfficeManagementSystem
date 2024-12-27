using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class PlanningController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public PlanningController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Planning()
    {
        // Page Title
        ViewData["pTitle"] = "Plannings Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Planning";
        ViewData["bChild"] = "Planning View";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var PlanningList = await client.GetFromJsonAsync<List<PlanningVM>>("Planning/GetAll");

        return View(PlanningList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        PlanningVM company = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        return PartialView("_Create", company);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PlanningVM Planning)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<PlanningVM>("Planning/Create", Planning);
        return RedirectToAction("Planning");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var Planning = await client.GetFromJsonAsync<PlanningVM>("Planning/GetById/?Id=" + Id);
        return PartialView("_Edit", Planning);
    }

    [HttpPost]
    public async Task<IActionResult> Update(PlanningVM Planning)
    {
        if (Planning.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<PlanningVM>("Planning/Update/", Planning);
        return RedirectToAction("Planning");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var Planning = await client.GetFromJsonAsync<PlanningVM>("Planning/GetById/?Id=" + Id);
        return PartialView("_Delete", Planning);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(PlanningVM Planning)
    {
        if (Planning.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("Planning/Delete?Id=" + Planning.Id);
        return RedirectToAction("Planning");
    }
}
