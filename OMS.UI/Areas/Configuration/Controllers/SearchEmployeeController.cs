//using OMS.UI.Areas.Configuration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace OMS.UI.Areas.Configuration.Controllers;
[Area("Configuration")]
public class SearchEmployeeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SearchEmployeeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> SearchEmployee()
    {
        // Page Title
        ViewData["pTitle"] = "Search Employees Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Search Employee";
        ViewData["bChild"] = "Search Employee";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var searchEmployeeList = await client.GetFromJsonAsync<List<SearchEmployeeVM>>("SearchEmployee/GetAll");
        return View(searchEmployeeList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        SearchEmployeeVM searchEmployee = new();
        return PartialView("_Create", searchEmployee);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SearchEmployeeVM searchEmployee)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<SearchEmployeeVM>("SearchEmployee/Create", searchEmployee);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var searchEmployee = await client.GetFromJsonAsync<SearchEmployeeVM>("SearchEmployee/GetById/?Id=" + Id);
        return PartialView("_Edit", searchEmployee);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SearchEmployeeVM searchEmployee)
    {
        if (searchEmployee.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<SearchEmployeeVM>("SearchEmployee/Update/", searchEmployee);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var searchEmployee = await client.GetFromJsonAsync<SearchEmployeeVM>("SearchEmployee/GetById/?Id=" + Id);
        return PartialView("_Delete", searchEmployee);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(SearchEmployeeVM searchEmployee)
    {
        if (searchEmployee.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("SearchEmployee/Delete?Id=" + searchEmployee.Id);
        return RedirectToAction("SearchEmployee");
    }

    //[HttpPost]
    //public async Task<IActionResult> Delete(SearchEmployeeVM searchEmployee)
    //{
    //    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    //    {
    //        WriteIndented = true
    //    };
    //    string forecastJson = JsonSerializer.Serialize<SearchEmployeeVM>(searchEmployee, options);

    //    if (searchEmployee.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    var searchEmployeeList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "SearchEmployee/Delete", searchEmployee);
    //    return RedirectToAction("Index");
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
