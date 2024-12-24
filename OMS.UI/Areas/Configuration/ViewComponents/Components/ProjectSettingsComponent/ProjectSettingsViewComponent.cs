using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Configuration.ViewModels;

namespace OMS.UI.Areas.Configuration.ViewComponents.Components.ProjectSettingsComponent;

public class ProjectSettingsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<ProjectSettingVM> projectSettings)
    {
        return View(projectSettings);
    }
}
