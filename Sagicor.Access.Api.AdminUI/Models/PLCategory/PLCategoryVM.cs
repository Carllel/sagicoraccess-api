using System.ComponentModel.DataAnnotations;

namespace Sagicor.Access.Api.AdminUI.Models.PLCategory
{
    public class PLCategoryVM
    {
        public Guid Id { get; set; }
        [Required] 
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
