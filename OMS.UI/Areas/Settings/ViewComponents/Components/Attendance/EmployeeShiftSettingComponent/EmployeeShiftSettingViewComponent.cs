using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Project.ProjectCategoryComponent;

public class EmployeeShiftSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<EmployeeShiftSettingVM> employeeShiftSettings)
    {
        return View(employeeShiftSettings);
    }
}