using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Project.ProjectSettingsComponent;

public class ProjectSettingsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<ProjectSettingVM> projectSettings)
    {
        return View(projectSettings);
    }
}
