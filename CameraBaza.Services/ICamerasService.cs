namespace CameraBazza.Services
{
   using System.Collections.Generic;
   using Data.Models;
   using Models;

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

      IEnumerable<CamerasListingModel> All();

      IEnumerable<CamerasListingModel> AllForUser(string id);

      CamerasDetailModel Details(int id);

      CamerasDetailModel Edit(int id);

      void Edit(int id, 
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
         string imgUrl);

      IEnumerable<CamerasListingModel> GetCamerasDetailsForUser(string id);

   }
}
