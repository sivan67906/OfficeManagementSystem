﻿namespace OMS.UI.Areas.Settings.ViewModels;

public class FinanceUnitSettingVM
{
    public int Id { get; set; }
    public string? FUnitCode { get; set; }
    public string? FUnitName { get; set; }
    public bool FIsDefault { get; set; }
}