namespace OMS.UI.Areas.Configuration.ViewModels;

public sealed class BusinessTypeVM
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
}