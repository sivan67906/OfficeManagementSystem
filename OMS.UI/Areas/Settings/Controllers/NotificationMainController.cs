using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OMS.UI.Areas.Settings.ViewModels;

[Area("Settings")]
public class NotificationMainController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public NotificationMainController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> NotificationMain()
    {
        // Page Title
        ViewData["pTitle"] = "NotificationMains Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Settings";
        ViewData["bParent"] = "NotificationMain";
        ViewData["bChild"] = "NotificationMain";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");

        var NotificationMains = await client.GetFromJsonAsync<List<NotificationMainVM>>("NotificationMain/GetAll");
        var NotificationMain = NotificationMains?.FirstOrDefault();

        var CommonNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<CommonNotificationMainVM>>(NotificationMain.CommonNotificationMainJson) : new List<CommonNotificationMainVM>();
        var LeaveNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<LeaveNotificationMainVM>>(NotificationMain.LeaveNotificationMainJson) : new List<LeaveNotificationMainVM>();
        var ProposalNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<ProposalNotificationMainVM>>(NotificationMain.ProposalNotificationMainJson) : new List<ProposalNotificationMainVM>();
        var InvoiceNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<InvoiceNotificationMainVM>>(NotificationMain.InvoiceNotificationMainJson) : new List<InvoiceNotificationMainVM>();
        var PaymentNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<PaymentNotificationMainVM>>(NotificationMain.PaymentNotificationMainJson) : new List<PaymentNotificationMainVM>();
        var TaskNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<TaskNotificationMainVM>>(NotificationMain.TaskNotificationMainJson) : new List<TaskNotificationMainVM>();
        var TicketNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<TicketNotificationMainVM>>(NotificationMain.TicketNotificationMainJson) : new List<TicketNotificationMainVM>();
        var ProjectNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<ProjectNotificationMainVM>>(NotificationMain.ProjectNotificationMainJson) : new List<ProjectNotificationMainVM>();
        var ReminderNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<ReminderNotificationMainVM>>(NotificationMain.ReminderNotificationMainJson) : new List<ReminderNotificationMainVM>();
        var RequestNotificationMainItems = NotificationMain != null ? JsonConvert.DeserializeObject<List<RequestNotificationMainVM>>(NotificationMain.RequestNotificationMainJson) : new List<RequestNotificationMainVM>();

        NotificationMain!.CommonNotificationMains = CommonNotificationMainItems;
        NotificationMain!.LeaveNotificationMains = LeaveNotificationMainItems;
        NotificationMain!.ProposalNotificationMains = ProposalNotificationMainItems;
        NotificationMain!.InvoiceNotificationMains = InvoiceNotificationMainItems;
        NotificationMain!.PaymentNotificationMains = PaymentNotificationMainItems;
        NotificationMain!.TaskNotificationMains = TaskNotificationMainItems;
        NotificationMain!.TicketNotificationMains = TicketNotificationMainItems;
        NotificationMain!.ProjectNotificationMains = ProjectNotificationMainItems;
        NotificationMain!.ReminderNotificationMains = ReminderNotificationMainItems;
        NotificationMain!.RequestNotificationMains = RequestNotificationMainItems;

        return View(NotificationMain);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateNotificationMain(
        string cbValueId, string cbValue1, string cbValue2, string cbValue3, string cbValue4, string cbValue5,
        string cbValue6, string cbValue7, string cbValue8, string cbValue9, string cbValue10)
    {
        if (cbValueId == "0" || cbValueId == "") return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");

        NotificationMainVM notificationMain = new();

        notificationMain.Id = Convert.ToInt32(cbValueId);
        notificationMain.CommonNotificationMainJson = cbValue1;
        notificationMain.LeaveNotificationMainJson = cbValue2;
        notificationMain.ProposalNotificationMainJson = cbValue3;
        notificationMain.InvoiceNotificationMainJson = cbValue4;
        notificationMain.PaymentNotificationMainJson = cbValue5;
        notificationMain.TaskNotificationMainJson = cbValue6;
        notificationMain.TicketNotificationMainJson = cbValue7;
        notificationMain.ProjectNotificationMainJson = cbValue8;
        notificationMain.ReminderNotificationMainJson = cbValue9;
        notificationMain.RequestNotificationMainJson = cbValue10;

        await client.PutAsJsonAsync("NotificationMain/Update/", notificationMain);
        return Redirect("NotificationMain");
    }
}