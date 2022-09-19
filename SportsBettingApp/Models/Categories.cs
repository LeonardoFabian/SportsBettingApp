using Microsoft.AspNetCore.Mvc;
using SportsBettingApp.Validations;
using System.ComponentModel.DataAnnotations;

namespace SportsBettingApp.Models
{
    public class Categories
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "The length of the {0} field must be between {2} and {1}")]
        [Display(Name = "Category Name")]
        [FirstLetterToUppercase]
        [Remote(action: "VerifyIfCategoryAlreadyExists", controller: "Categories")]
        public string Name { get; set; }
    }
}
