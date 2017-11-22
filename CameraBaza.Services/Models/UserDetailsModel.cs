namespace CameraBazza.Services.Models
{
   using System;

   public class UserDetailsModel
   {
      public string Username { get; set; }

      public string UserId { get; set; }

      public string Email { get; set; }

      public DateTime? LastLogin { get; set; }

      public string Phone { get; set; }

      public int CamerasInStock { get; set; }

      public int CamerasInOutOfStock { get; set; }


   }
}
