using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorForm.Data
{
    public class Model
    {
        [Required]
        [StringLength(16, ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", 
            ErrorMessage = "Please check out the box!")]
        public bool IsValidatedDesign { get; set; }

    }
}
