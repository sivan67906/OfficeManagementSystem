using System.ComponentModel.DataAnnotations;

namespace ConfigurationServices.CQRS.MVC.Areas.Settings.Models
{
    public class LeadSourceVM
    {
        [Key]
        public int Id { get; set; }
        public string? source { get; set; }
    }
}
