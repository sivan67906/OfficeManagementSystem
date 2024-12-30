using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class TicketController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TicketController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Ticket()
    {
        // Page Title
        ViewData["pTitle"] = "Tickets Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Ticket";
        ViewData["bChild"] = "Ticket";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");

        //var ticketAgents = await client.GetFromJsonAsync<List<TicketAgentsVM>>("TicketAgent/GetAll");
        //var ticketGroups = await client.GetFromJsonAsync<List<TicketGroupsVM>>("TicketGroup/GetAll");
        //var ticketTypes = await client.GetFromJsonAsync<List<TicketTypesVM>>("TicketType/GetAll");
        //var ticketChannels = await client.GetFromJsonAsync<List<TicketChannelVM>>("TicketChannel/GetAll");
        //var ticketReplyTemplates = await client.GetFromJsonAsync<List<TicketReplyTemplatesVM>>("TicketReplyTemplate/GetAll");

        var ticketAgents = new List<TicketAgentsVM>();
        var ticketGroups = new List<TicketGroupsVM>();
        var ticketTypes = new List<TicketTypesVM>();
        var ticketChannels = new List<TicketChannelVM>();
        var ticketReplyTemplates = new List<TicketReplyTemplatesVM>();



        var tickets = new TicketVM
        {
            TicketAgentsVMList = ticketAgents,
            TicketGroupsVMList = ticketGroups,
            TicketTypesVMList = ticketTypes,
            TicketChannelVMList = ticketChannels,
            TicketReplyTemplatesVMList = ticketReplyTemplates
        };
        return View(tickets);
    }
}