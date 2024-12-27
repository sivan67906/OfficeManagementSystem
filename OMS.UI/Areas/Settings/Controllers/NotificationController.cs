using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.Controllers;
[Area("Settings")]
public class NotificationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NotificationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Notification()
    {
        // Page Title
        ViewData["pTitle"] = "Notifications Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "Notification";
        ViewData["bChild"] = "Notification";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");

        var Notifications = await client.GetFromJsonAsync<List<NotificationVM>>("Notification/GetAll");
        var Notification = Notifications?.FirstOrDefault();

        var CommonNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<CommonNotificationVM>>(Notification.CommonNotificationJson) : new List<CommonNotificationVM>();
        var LeaveNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<LeaveNotificationVM>>(Notification.LeaveNotificationJson) : new List<LeaveNotificationVM>();
        var ProposalNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<ProposalNotificationVM>>(Notification.ProposalNotificationJson) : new List<ProposalNotificationVM>();
        var InvoiceNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<InvoiceNotificationVM>>(Notification.InvoiceNotificationJson) : new List<InvoiceNotificationVM>();
        var PaymentNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<PaymentNotificationVM>>(Notification.PaymentNotificationJson) : new List<PaymentNotificationVM>();
        var TaskNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<TaskNotificationVM>>(Notification.TaskNotificationJson) : new List<TaskNotificationVM>();
        var TicketNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<TicketNotificationVM>>(Notification.TicketNotificationJson) : new List<TicketNotificationVM>();
        var ProjectNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<ProjectNotificationVM>>(Notification.ProjectNotificationJson) : new List<ProjectNotificationVM>();
        var ReminderNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<ReminderNotificationVM>>(Notification.ReminderNotificationJson) : new List<ReminderNotificationVM>();
        var RequestNotificationItems = Notification != null ? JsonConvert.DeserializeObject<List<RequestNotificationVM>>(Notification.RequestNotificationJson) : new List<RequestNotificationVM>();

        Notification!.CommonNotifications = CommonNotificationItems;
        Notification!.LeaveNotifications = LeaveNotificationItems;
        Notification!.ProposalNotifications = ProposalNotificationItems;
        Notification!.InvoiceNotifications = InvoiceNotificationItems;
        Notification!.PaymentNotifications = PaymentNotificationItems;
        Notification!.TaskNotifications = TaskNotificationItems;
        Notification!.TicketNotifications = TicketNotificationItems;
        Notification!.ProjectNotifications = ProjectNotificationItems;
        Notification!.ReminderNotifications = ReminderNotificationItems;
        Notification!.RequestNotifications = RequestNotificationItems;

        return View(Notification);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateNotification(NotificationVM Notification, string jsonData)
    {
        if (Notification.Id == 0) return View();
        Notification.CBNotificationJsonSettings = jsonData;
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync("Notification/Update/", Notification);
        return Redirect("Notification");
    }
}





