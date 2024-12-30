namespace OMS.UI.Areas.Settings.ViewModels;

public class TicketVM
{
    public List<TicketAgentsVM>? TicketAgentsVMList { get; set; }
    public List<TicketGroupsVM>? TicketGroupsVMList { get; set; }
    public List<TicketTypesVM>? TicketTypesVMList { get; set; }
    public List<TicketChannelVM>? TicketChannelVMList { get; set; }
    public List<TicketReplyTemplatesVM>? TicketReplyTemplatesVMList { get; set; }
}
public class TicketAgentsVM
{
    public int Id { get; set; }
}
public class TicketGroupsVM
{
    public int Id { get; set; }
}
public class TicketTypesVM
{
    public int Id { get; set; }
}
public class TicketChannelVM
{
    public int Id { get; set; }
}
public class TicketReplyTemplatesVM
{
    public int Id { get; set; }
}