using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Configuration.ViewModels;

namespace OMS.UI.Areas.Configuration.Controllers;
[Area("Configuration")]
public class BusinessLocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BusinessLocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> BusinessLocation()
    {
        // Page Title
        ViewData["pTitle"] = "Business Locations Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Business Location";
        ViewData["bChild"] = "Business Location";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var businessLocationList = await client.GetFromJsonAsync<List<BusinessLocationVM>>("BusinessLocation/GetAll");
        return View(businessLocationList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        BusinessLocationVM businessLocation = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
        var countries = await client.GetFromJsonAsync<List<CountryVM>>("Country/GetAll");
        ViewBag.CompanyList = companies;
        ViewBag.CountryList = countries;
        return PartialView("_Create", businessLocation);
    }
    [HttpPost, ActionName("GetStatesByCountryId")]
    public async Task<IActionResult> GetStatesByCountryId(string countryId)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var states = await client.GetFromJsonAsync<List<StateVM>>("State/GetByParentId/?parentId=" + countryId);

        return Json(states);

        //List<Product> productLists = new List<Product>();
        //if (!string.IsNullOrEmpty(categoryId))
        //{
        //    catId = Convert.ToInt32(categoryId);
        //    productLists = _context.Products.Where(s => s.CategoryId.Equals(catId)).ToList();
        //}
        //return Json(productLists);
    }


    [HttpPost]
    public async Task<IActionResult> Create(BusinessLocationVM businessLocation)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PostAsJsonAsync<BusinessLocationVM>("BusinessLocation/Create", businessLocation);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var businessLocation = await client.GetFromJsonAsync<BusinessLocationVM>("BusinessLocation/GetById/?Id=" + Id);
        return PartialView("_Edit", businessLocation);
    }

    [HttpPost]
    public async Task<IActionResult> Update(BusinessLocationVM businessLocation)
    {
        if (businessLocation.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<BusinessLocationVM>("BusinessLocation/Update/", businessLocation);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var businessLocation = await client.GetFromJsonAsync<BusinessLocationVM>("BusinessLocation/GetById/?Id=" + Id);
        return PartialView("_Delete", businessLocation);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(BusinessLocationVM businessLocation)
    {
        if (businessLocation.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("BusinessLocation/Delete?Id=" + businessLocation.Id);
        return RedirectToAction("BusinessLocation");
    }

    //[HttpPost]
    //public async Task<IActionResult> Delete(BusinessLocationVM businessLocation)
    //{
    //    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    //    {
    //        WriteIndented = true
    //    };
    //    string forecastJson = JsonSerializer.Serialize<BusinessLocationVM>(businessLocation, options);

    //    if (businessLocation.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    var businessLocationList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "BusinessLocation/Delete", businessLocation);
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