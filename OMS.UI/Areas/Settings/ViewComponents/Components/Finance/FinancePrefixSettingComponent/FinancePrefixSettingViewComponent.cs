using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Finance.FinancePrefixSettingComponent;

public class FinancePrefixSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FinancePrefixSettingVM financePrefixSetting)
    {
        return View(financePrefixSetting);
    }
}
