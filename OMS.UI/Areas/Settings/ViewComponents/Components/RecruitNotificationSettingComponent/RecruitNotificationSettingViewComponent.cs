using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.RecruitNotificationSettingComponent;

public class RecruitNotificationSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(RecruitNotificationSettingVM recruitNotificationSetting)
    {
        return View(recruitNotificationSetting);
    }
}








