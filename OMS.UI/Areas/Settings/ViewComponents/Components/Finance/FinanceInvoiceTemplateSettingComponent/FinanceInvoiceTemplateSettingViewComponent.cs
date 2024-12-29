using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Settings.ViewModels;

namespace OMS.UI.Areas.Settings.ViewComponents.Components.Finance.FinanceInvoiceTemplateSettingComponent;

public class FinanceInvoiceTemplateSettingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FinanceInvoiceTemplateSettingVM financeInvoiceTemplateSetting)
    {
        return View(financeInvoiceTemplateSetting);
    }
}
