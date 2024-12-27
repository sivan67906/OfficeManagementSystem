using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class PurchaseController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public PurchaseController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Purchase()
    {
        // Page Title
        ViewData["pTitle"] = "Purchases Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Purchase";
        ViewData["bChild"] = "Purchase View";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var purchaseList = await client.GetFromJsonAsync<List<PurchaseVM>>("Purchase/GetAll");

        return View(purchaseList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        PurchaseVM purchase = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        return PartialView("_Create", purchase);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PurchaseVM purchase)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<PurchaseVM>("Purchase/Create", purchase);
        return RedirectToAction("Purchase");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var purchase = await client.GetFromJsonAsync<PurchaseVM>("Purchase/GetById/?Id=" + Id);
        return PartialView("_Edit", purchase);
    }

    [HttpPost]
    public async Task<IActionResult> Update(PurchaseVM purchase)
    {
        if (purchase.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<PurchaseVM>("Purchase/Update/", purchase);
        return RedirectToAction("Purchase");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var purchase = await client.GetFromJsonAsync<PurchaseVM>("Purchase/GetById/?Id=" + Id);
        return PartialView("_Delete", purchase);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(PurchaseVM purchase)
    {
        if (purchase.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("Purchase/Delete?Id=" + purchase.Id);
        return RedirectToAction("Purchase");
    }
}
