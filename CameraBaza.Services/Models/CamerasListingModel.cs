namespace CameraBazza.Services.Models
{
   using Data.Models;

   public class CamerasListingModel
   {
      public int Id { get; set; }

      public CameraMake Make { get; set; }

      public string Model { get; set; }

      public decimal Price { get; set; }

      public int Quantity { get; set; }

      public string ImgUrl { get; set; }

      public string UserId { get; set; }

   }
}
