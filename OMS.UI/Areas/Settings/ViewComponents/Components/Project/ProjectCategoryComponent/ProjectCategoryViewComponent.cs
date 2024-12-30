using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Project.ProjectCategoryComponent;

public class ProjectCategoryViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<ProjectCategoryVM> projectCategories)
    {
        return View(projectCategories);
    }
}