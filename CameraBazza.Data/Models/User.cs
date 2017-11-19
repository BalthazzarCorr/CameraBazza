namespace CameraBazza.Data.Models
{
   using System.Collections.Generic;
   using Microsoft.AspNetCore.Identity;

   // Add profile data for application users by adding properties to the User class
   public class User : IdentityUser
   {
      public List<Camera> Cameras { get; set; } = new List<Camera>();
   }
}
