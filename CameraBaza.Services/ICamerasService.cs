namespace CameraBazza.Services
{
   using System.Collections.Generic;
   using Data.Models;

   public interface ICamerasService
   {
      void Create(
         CameraMake make,
         string model, 
         decimal price, 
         int quantity, 
         int minShutterSpeed,
         int maxShutterSpeed,
         MinISO minIso,
         int maxIso,
         bool isFullFrame,
         string videoResolutino,
         IEnumerable<LightMetering> lightMeterings,
         string description,
         string imgUrl,
         string userId
         );

   }
}
