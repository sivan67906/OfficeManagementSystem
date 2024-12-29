using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Project.ProjectSettingsComponent;

public class AttendanceSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<AttendanceSettingVM> attendanceSetting)
    {
        return View(attendanceSetting);
    }
}
