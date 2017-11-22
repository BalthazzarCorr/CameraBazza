namespace CameraBazza.Services.Models
{
   using System.Collections.Generic;

   public class ProfileViewModel
    {
      public UserDetailsModel UserDetailses { get; set; }

       public IEnumerable<CamerasListingModel> Cameras { get; set; } = new List<CamerasListingModel>();
   }
}
