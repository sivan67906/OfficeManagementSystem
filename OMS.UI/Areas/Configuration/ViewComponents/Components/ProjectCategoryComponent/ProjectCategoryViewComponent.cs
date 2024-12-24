using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Configuration.ViewModels;

namespace OMS.UI.Areas.Configuration.ViewComponents.Components.ProjectSettingsComponent;

public class ProjectCategoryViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<ProjectCategoryVM> projectCategories)
    {
        return View(projectCategories);
    }
}