namespace OMS.UI.Areas.Settings.ViewModels;

public class NotificationMainVM
{
    public int Id { get; set; }
    public string? CommonNotificationMainJson { get; set; }
    public string? LeaveNotificationMainJson { get; set; }
    public string? ProposalNotificationMainJson { get; set; }
    public string? InvoiceNotificationMainJson { get; set; }
    public string? PaymentNotificationMainJson { get; set; }
    public string? TaskNotificationMainJson { get; set; }
    public string? TicketNotificationMainJson { get; set; }
    public string? ProjectNotificationMainJson { get; set; }
    public string? ReminderNotificationMainJson { get; set; }
    public string? RequestNotificationMainJson { get; set; }

    public List<CommonNotificationMainVM>? CommonNotificationMains { get; set; }
    public List<LeaveNotificationMainVM>? LeaveNotificationMains { get; set; }
    public List<ProposalNotificationMainVM>? ProposalNotificationMains { get; set; }
    public List<InvoiceNotificationMainVM>? InvoiceNotificationMains { get; set; }
    public List<PaymentNotificationMainVM>? PaymentNotificationMains { get; set; }
    public List<TaskNotificationMainVM>? TaskNotificationMains { get; set; }
    public List<TicketNotificationMainVM>? TicketNotificationMains { get; set; }
    public List<ProjectNotificationMainVM>? ProjectNotificationMains { get; set; }
    public List<ReminderNotificationMainVM>? ReminderNotificationMains { get; set; }
    public List<RequestNotificationMainVM>? RequestNotificationMains { get; set; }

}
public class CommonNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class LeaveNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class ProposalNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class InvoiceNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class PaymentNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class TaskNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class TicketNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class ProjectNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class ReminderNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}
public class RequestNotificationMainVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsChecked { get; set; }
}