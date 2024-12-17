﻿namespace OMS.UI.Areas.Configuration.ViewModels;

public class RoleVM
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CompanyId { get; set; }
    public int DepartmentId { get; set; }
    public int DesignationId { get; set; }
    public string? CompanyName { get; set; }
    public string? DepartmentName { get; set; }
    public string? DesignationName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
}