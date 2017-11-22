namespace CameraBazza.Services.Models
{
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using Data.Models;

   public class CamerasDetailModel : CamerasListingModel
   {

      [Display(Name = "Is Full Frame:")]
      public bool IsFullFrame { get; set; }

      [Display(Name = "Min Shutter Speed:")]
      public int MinShutterSpeed { get; set; }

      [Display(Name = "Max Shutter Speed:")]
      public int MaxShutterSpeed { get; set; }

      [Display(Name = "Video Resolution:")]
      public string VideoResolution { get; set; }

      [Display(Name = "Light Metering")]
      public IEnumerable<LightMetering> LightMeterings { get; set; } = new List<LightMetering>();

      public string Description { get; set; }


      public MinISO MinISO { get; set; }

      public int MaxISO { get; set; }
      

      public string Username { get; set; }
   }
}
