using ConfigurationServices.CQRS.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Configuration.ViewModels;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class CurrencyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public CurrencyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Currency()
    {
        // Page Title
        ViewData["pTitle"] = "Currencies Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Currency";
        ViewData["bChild"] = "Currency View";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var currencyList = await client.GetFromJsonAsync<List<CurrencyVM>>("Currency/GetAll");

        return View(currencyList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        CurrencyVM company = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        return  PartialView("_Create", company);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CurrencyVM currency)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<CurrencyVM>("Currency/Create", currency);
        return RedirectToAction("Currency");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var currency = await client.GetFromJsonAsync<CurrencyVM>("Currency/GetById/?Id=" + Id);
        return PartialView("_Edit", currency);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CurrencyVM currency)
    {
        if (currency.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<CurrencyVM>("Currency/Update/", currency);
        return RedirectToAction("Currency");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var currency = await client.GetFromJsonAsync<CurrencyVM>("Currency/GetById/?Id=" + Id);
        return PartialView("_Delete", currency);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CurrencyVM currency)
    {
        if (currency.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("Currency/Delete?Id=" + currency.Id);
        return RedirectToAction("Currency");
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
