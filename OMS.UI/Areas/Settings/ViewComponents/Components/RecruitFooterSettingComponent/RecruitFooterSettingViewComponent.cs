using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.RecruitFooterSettingComponent;

public class RecruitFooterSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<RecruitFooterSettingVM> recruitFooterSettings)
    {
        return View(recruitFooterSettings);
    }
}




