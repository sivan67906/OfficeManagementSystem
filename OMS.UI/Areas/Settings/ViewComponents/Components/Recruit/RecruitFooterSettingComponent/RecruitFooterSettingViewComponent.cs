using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Recruit.RecruitCustomQuestionSettingComponent;

public class RecruitFooterSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<RecruitFooterSettingVM> recruitFooterSettings)
    {
        return View(recruitFooterSettings);
    }
}




