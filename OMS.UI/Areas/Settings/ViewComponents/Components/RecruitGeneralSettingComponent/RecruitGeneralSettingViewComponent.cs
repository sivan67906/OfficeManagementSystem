using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.RecruitGeneralSettingComponent;

public class RecruitGeneralSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(RecruitGeneralSettingVM recruitGeneralSetting)
    {
        return View(recruitGeneralSetting);
    }
}


