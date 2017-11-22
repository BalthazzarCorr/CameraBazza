using System;

namespace CameraBazza.Services.Models
{
   using System.ComponentModel.DataAnnotations;

   public class EditProfileModel
    {
      [Required]
       public string UserId { get; set; }

       [Required]
       [EmailAddress]
       [Display(Name = "Email")]
       public string Email { get; set; }

       [Required]
       [DataType(DataType.Password)]
       [Display(Name = "Password")]
       public string Password { get; set; }

       [Required]
       [Display(Name = "Phone")]
       public string Phone { get; set; }

       [Required]
       [DataType(DataType.Password)]
       public string CurrentPassword { get; set; }

       public DateTime? LastLogin { get; set; }
   }
}
