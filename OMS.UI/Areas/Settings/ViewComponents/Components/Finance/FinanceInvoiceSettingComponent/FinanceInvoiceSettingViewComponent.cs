using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Finance.FinanceInvoiceSettingComponent;

public class FinanceInvoiceSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FinanceInvoiceSettingVM financeInvoiceSetting)
    {
        return View(financeInvoiceSetting);
    }
}
