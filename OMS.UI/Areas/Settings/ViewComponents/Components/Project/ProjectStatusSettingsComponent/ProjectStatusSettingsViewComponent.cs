using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Project.ProjectStatusSettingsComponent;
public class ProjectStatusSettingsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<ProjectStatusVM> projectStatusSettings)
    {
        return View(projectStatusSettings);
    }
}