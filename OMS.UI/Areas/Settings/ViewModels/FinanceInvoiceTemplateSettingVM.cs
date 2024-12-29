﻿namespace OMS.UI.Areas.Settings.ViewModels;

public class FinanceInvoiceTemplateSettingVM
{
    public int Id { get; set; }
    public string? FIRBTemplateJsonSettings { get; set; }
    public List<FIRBTemplateSettingVM>? FIRBTemplateSettings { get; set; }
}
public class FIRBTemplateSettingVM
{
    public int Id { get; set; }
    public string? ImageURL { get; set; }
    public bool isSelected { get; set; }
}