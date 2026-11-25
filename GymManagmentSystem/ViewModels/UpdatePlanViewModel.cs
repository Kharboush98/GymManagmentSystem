using System.ComponentModel.DataAnnotations;

namespace GymManagmentSystem.ViewModels
{
    public class UpdatePlanViewModel
    {
        [Display(Name = "Plan")]
        public string Name { get; set; } = default;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200 , MinimumLength = 5 , ErrorMessage = "Description must be between 5 and 200")]
        public string Description { get; set; } = default;

        [Required(ErrorMessage = "Duration is required")]
        [Display(Name = "Duration(Days)")]
        [Range(1 , 365 , ErrorMessage = "Duration must be between 1 and 365")]
        public int DurationDays { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price(EGP)")]
        [Range(0.01, 10000, ErrorMessage = "Price must be greater than 0 and less than 10000")]
        public decimal Price { get; set; }
    }
}
