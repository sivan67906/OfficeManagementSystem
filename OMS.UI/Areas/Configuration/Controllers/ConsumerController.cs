using OMS.UI.Areas.Configuration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace OMS.UI.Areas.Consumer.Controllers;
[Area("Configuration")]
public class ConsumerController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ConsumerController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Consumer()
    {
        // Page Title
        ViewData["pTitle"] = "Consumers Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Consumer";
        ViewData["bChild"] = "Consumer";
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var consumerList = await client.GetFromJsonAsync<List<ConsumerVM>>("Consumer/GetAll");
        var planTypes = await client.GetFromJsonAsync<List<PlanTypeVM>>("PlanType/GetAll");
        ViewBag.PlanType = planTypes;
        return View(consumerList);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ConsumerVM consumer = new();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var planTypes = await client.GetFromJsonAsync<List<PlanTypeVM>>("PlanType/GetAll");
        ViewBag.PlanType = planTypes;
        return PartialView("_Create", consumer);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ConsumerVM consumer)
    {
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var planTypes = await client.GetFromJsonAsync<List<PlanTypeVM>>("PlanType/GetAll");
        ViewBag.PlanType = planTypes;
        await client.PostAsJsonAsync<ConsumerVM>("Consumer/Create", consumer);
        return RedirectToAction("Consumer");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var planTypes = await client.GetFromJsonAsync<List<PlanTypeVM>>("PlanType/GetAll");
        ViewBag.PlanType = planTypes;
        var consumer = await client.GetFromJsonAsync<ConsumerVM>("Consumer/GetById/?Id=" + Id);
        return PartialView("_Edit", consumer);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ConsumerVM consumer)
    {
        if (consumer.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<ConsumerVM>("Consumer/Update/", consumer);
        return RedirectToAction("Consumer");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var consumer = await client.GetFromJsonAsync<ConsumerVM>("Consumer/GetById/?Id=" + Id);
        var planTypes = await client.GetFromJsonAsync<List<PlanTypeVM>>("PlanType/GetAll");
        ViewBag.PlanType = planTypes;
        return PartialView("_Delete", consumer);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(ConsumerVM consumer)
    {
        if (consumer.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("Consumer/Delete?Id=" + consumer.Id);
        return RedirectToAction("Consumer");
    }


    //[HttpPost]
    //public async Task<IActionResult> Delete(ConsumerVM consumer)
    //{
    //    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    //    {
    //        WriteIndented = true
    //    };
    //    string forecastJson = JsonSerializer.Serialize<ConsumerVM>(consumer, options);

    //    if (consumer.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    //client.DeleteAsync("Consumer/Delete" + )
    //    var consumerList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "Consumer/Delete", consumer);
    //    return RedirectToAction("Consumer");
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