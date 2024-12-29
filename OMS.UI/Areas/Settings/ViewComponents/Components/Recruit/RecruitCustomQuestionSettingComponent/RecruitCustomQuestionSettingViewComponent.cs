using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Recruit.RecruitCustomQuestionSettingComponent;

public class RecruitCustomQuestionSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<RecruitCustomQuestionSettingVM> recruitCustomQuestionSettings)
    {
        return View(recruitCustomQuestionSettings);
    }
}












