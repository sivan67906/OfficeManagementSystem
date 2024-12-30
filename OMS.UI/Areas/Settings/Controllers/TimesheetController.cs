using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class TimesheetController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TimesheetController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Timesheet()
    {
        // Page Title
        ViewData["pTitle"] = "Timesheets Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Timesheet";
        ViewData["bChild"] = "Timesheet";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");

        var timesheetSettings = await client.GetFromJsonAsync<List<TimesheetSettingVM>>("TimesheetSetting/GetAll");
        return View(timesheetSettings);
    }
}