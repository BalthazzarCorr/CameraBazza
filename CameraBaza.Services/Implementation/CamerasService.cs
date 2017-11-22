namespace CameraBazza.Services.Implementation
{

   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Data.Models;
   using Extensions;
   using Microsoft.AspNetCore.Identity;
   using Models;

   public class CamerasService : ICamerasService
   {
      private readonly CamerBazzaDbContext db;

      private readonly UserManager<User> users;

      public CamerasService(CamerBazzaDbContext db, UserManager<User> users)
      {
         this.db = db;
         this.users = users;
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
            LightMetering = lightMeterings.Cast<int>().Sum(),
            Description = description,
            ImageURL = imgUrl,
            UserId = userId
         };

         this.db.Add(camera);

         this.db.SaveChanges();
      }

      public IEnumerable<CamerasListingModel> All()
         => this.db.Cameras.Select(s => new CamerasListingModel
         {
            Id = s.Id,
            Make = s.Make,
            Model = s.Model,
            Price = s.Price,
            ImgUrl = s.ImageURL,
            Quantity = s.Quantity
         }).ToList();

      public IEnumerable<CamerasListingModel> AllForUser(string id)
      {
         var cameras = this.db.Cameras.Where(c => c.UserId == id)
            .Select(c => new CamerasListingModel()
            {
               Make = c.Make,
               Model = c.Model,
               Price = c.Price,
               ImgUrl = c.ImageURL,
               Id = c.Id,
               Quantity = c.Quantity,
               UserId = c.UserId
            }).ToList();

         return cameras;
      }

      public CamerasDetailModel Details(int id)
         => this.db.Cameras.Where(s => s.Id == id ).Select(s => new CamerasDetailModel
         {
            Make = s.Make,
            Model = s.Model,
            Price = s.Price,
            Description = s.Description,
            Quantity = s.Quantity,
            ImgUrl = s.ImageURL,
            IsFullFrame = s.IsFullFrame,
            MinShutterSpeed = s.MinShutterSpeed,
            MaxShutterSpeed = s.MaxShutterSpeed,
            VideoResolution = s.VideoResolution,
            MinISO = s.MinISO,
            MaxISO = s.MaxISO,
            Username = s.User.UserName,
            LightMeterings = s.LightMetering.GetMeterings(),

         }).FirstOrDefault();

      public IEnumerable<CamerasListingModel> GetCamerasDetailsForUser(string id)
      {
         var cameras = this.db.Cameras.Where(c => c.UserId == id)
            .Select(c => new CamerasListingModel()
            {
               Make = c.Make,
               Model = c.Model,
               Price = c.Price,
               ImgUrl = c.ImageURL,
               Id = c.Id,
               Quantity = c.Quantity ,
               UserId = c.UserId
            }).ToList();

         return cameras;
      }
   }
}
