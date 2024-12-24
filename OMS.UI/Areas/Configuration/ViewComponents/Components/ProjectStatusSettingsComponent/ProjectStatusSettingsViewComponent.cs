using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Configuration.ViewModels;

namespace OMS.UI.Areas.Configuration.ViewComponents.Components.ProjectSettingsComponent;
public class ProjectStatusSettingsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<ProjectStatusVM> projectStatusSettings)
    {
        return View(projectStatusSettings);
    }
}