namespace CameraBazza.Services.Implementation
{
   using System;
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
             => this.db.Cameras.Where(c => c.UserId == id)
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
         
      
      public CamerasDetailModel Details(int id)
         => this.db.Cameras
         .Where(s => s.Id == id)
         .Select(s => new CamerasDetailModel
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

      public CamerasDetailModel Edit(int id)
         => this.db.Cameras.Where(c => c.Id == id).Select(s => new CamerasDetailModel
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

      public CamerasDetailModel GetCameraCompleteEditInfromatio(int cameraId)
      {
         var cam = this.db.Cameras.First(c => c.Id == cameraId);

         CamerasDetailModel editCameraModel = new CamerasDetailModel()
         {
            Make = cam.Make,
            Model = cam.Model,
            Price = cam.Price,
            Id = cam.Id,
            Description = cam.Description,
            ImgUrl = cam.ImageURL,
            IsFullFrame = cam.IsFullFrame,
            MaxISO = cam.MaxISO,
            MinISO = cam.MinISO,
            MaxShutterSpeed = cam.MaxShutterSpeed,
            MinShutterSpeed = cam.MinShutterSpeed,
            Quantity = cam.Quantity,
            VideoResolution = cam.VideoResolution,
            LightMeterings = cam.LightMetering.GetMeterings()
         };

         return editCameraModel;
      }

      public bool CameraExists(int? id)
      {
         if (id is  null )
         {
            return false;
         }
        return this.db.Cameras.Any(c => c.Id == id);
      }

      public void Delete(int id)
      {
         var cam = this.db.Cameras.First(c=>c.Id == id);

         this.db.Remove(cam);

         this.db.SaveChanges();
      }


      public void Edit(int id, CameraMake make,
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
         string imgUrl
         )
      {
         var cameraExist = this.db.Cameras.Find(id);
         if (cameraExist == null)
         {
            return;
         }
         cameraExist.Make = make;
         cameraExist.Model = model;
         cameraExist.Price = price;
         cameraExist.Quantity = quantity;
         cameraExist.MinShutterSpeed = minShutterSpeed;
         cameraExist.MaxShutterSpeed = maxShutterSpeed;
         cameraExist.MinISO = minIso;
         cameraExist.MaxISO = maxIso;
         cameraExist.IsFullFrame = isFullFrame;
         cameraExist.VideoResolution = videoResolutino;
         cameraExist.LightMetering = lightMeterings.Cast<int>().Sum();
         cameraExist.Description = description;
         cameraExist.ImageURL = imgUrl;

         this.db.SaveChanges();

      }

      public IEnumerable<CamerasListingModel> GetCamerasDetailsForUser(string id)
             => this.db.Cameras.Where(c => c.UserId == id)
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

        
      
   }
}
