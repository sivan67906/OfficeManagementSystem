using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.RecruiterSettingComponent;

public class RecruiterSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<RecruiterSettingVM> recruiterSettings)
    {
        return View(recruiterSettings);
    }
}






