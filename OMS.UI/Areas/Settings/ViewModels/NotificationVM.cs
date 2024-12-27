namespace OMS.UI.Areas.Settings.ViewModels;

public class NotificationVM
{
    public int Id { get; set; }
    public string? CommonNotificationJson { get; set; }
    public string? LeaveNotificationJson { get; set; }
    public string? ProposalNotificationJson { get; set; }
    public string? InvoiceNotificationJson { get; set; }
    public string? PaymentNotificationJson { get; set; }
    public string? TaskNotificationJson { get; set; }
    public string? TicketNotificationJson { get; set; }
    public string? ProjectNotificationJson { get; set; }
    public string? ReminderNotificationJson { get; set; }
    public string? RequestNotificationJson { get; set; }

    public List<CommonNotificationVM>? CommonNotifications { get; set; }
    public List<LeaveNotificationVM>? LeaveNotifications { get; set; }
    public List<ProposalNotificationVM>? ProposalNotifications { get; set; }
    public List<InvoiceNotificationVM>? InvoiceNotifications { get; set; }
    public List<PaymentNotificationVM>? PaymentNotifications { get; set; }
    public List<TaskNotificationVM>? TaskNotifications { get; set; }
    public List<TicketNotificationVM>? TicketNotifications { get; set; }
    public List<ProjectNotificationVM>? ProjectNotifications { get; set; }
    public List<ReminderNotificationVM>? ReminderNotifications { get; set; }
    public List<RequestNotificationVM>? RequestNotifications { get; set; }

}




public class CommonNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class LeaveNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class ProposalNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class InvoiceNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class PaymentNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class TaskNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class TicketNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class ProjectNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class ReminderNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class RequestNotificationVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}