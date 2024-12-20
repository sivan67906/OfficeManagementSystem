using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
public class ContractController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ContractController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Contract()
    {
        // Page Title
        ViewData["pTitle"] = "Contracts Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Contract";
        ViewData["bChild"] = "Contract View";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var currencyList = await client.GetFromJsonAsync<List<ContractVM>>("Contract/GetAll");

        return View(currencyList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ContractVM company = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        return PartialView("_Create", company);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContractVM currency)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<ContractVM>("Contract/Create", currency);
        return RedirectToAction("Contract");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var currency = await client.GetFromJsonAsync<ContractVM>("Contract/GetById/?Id=" + Id);
        return PartialView("_Edit", currency);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ContractVM currency)
    {
        if (currency.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<ContractVM>("Contract/Update/", currency);
        return RedirectToAction("Contract");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var currency = await client.GetFromJsonAsync<ContractVM>("Contract/GetById/?Id=" + Id);
        return PartialView("_Delete", currency);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ContractVM currency)
    {
        if (currency.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("Contract/Delete?Id=" + currency.Id);
        return RedirectToAction("Contract");
    }
}
