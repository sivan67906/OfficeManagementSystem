using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Finance.FinanceUnitSettingComponent;

public class FinanceUnitSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<FinanceUnitSettingVM> financeUnitSettings)
    {
        return View(financeUnitSettings);
    }
}
