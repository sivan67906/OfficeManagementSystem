using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Recruit.RecruitCustomQuestionSettingComponent;

public class RecruitJobApplicationStatusSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<RecruitJobApplicationStatusSettingVM> recruitJobApplicationStatusSettings)
    {
        return View(recruitJobApplicationStatusSettings);
    }
}










