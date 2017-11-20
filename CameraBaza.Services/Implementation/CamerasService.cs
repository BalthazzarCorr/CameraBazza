namespace CameraBazza.Services.Implementation
{
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Data.Models;

   public class CamerasService : ICamerasService
   {
      private readonly CamerBazzaDbContext db;

      public CamerasService(CamerBazzaDbContext db)
      {
         this.db = db;
      }

      public void Create(CameraMake make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed,
         MinISO minIso, int maxIso, bool isFullFrame, string videoResolutino, IEnumerable<LightMetering> lightMeterings, string description, string imgUrl, string userId)
      {

         var camera = new Camera
         {
            Make = make,
            Model = model,
            Price = price,
            Quantity = quantity,
            MinShutterSpeed = minShutterSpeed,
            MaxShutterSpeed = maxShutterSpeed,
            MinISO = minIso,
            MaxISO = maxIso,
            IsFullFrame = isFullFrame,
            VideoResolution = videoResolutino,
            LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
            Description = description,
            ImageURL = imgUrl,
            UserId = userId
         };

         this.db.Add(camera);

         this.db.SaveChanges();
      }
   }
}
