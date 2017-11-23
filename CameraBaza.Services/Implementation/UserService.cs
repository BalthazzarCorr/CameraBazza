namespace CameraBazza.Services.Implementation
{
   using System;
   using Data;
   using Data.Models;
   using System.Linq;
   using Microsoft.AspNetCore.Identity;
   using Models;

   public class UserService : IUserService
   {

      private readonly CamerBazzaDbContext db;

      private readonly UserManager<User> users;

      public UserService(CamerBazzaDbContext db, UserManager<User> users)
      {
         this.db = db;
         this.users = users;

      }

      public UserDetailsModel GetUserProfile(string id)
      {
         var profile = this.db.Users.Where(u => u.Id == id)
            .Select(u => new UserDetailsModel()
            {
               Username = u.UserName,
               LastLogin = u.LastLogin,
               UserId = u.Id,
               Email = u.Email,
               Phone = u.PhoneNumber,
               CamerasInStock = u.Cameras.Count(c => c.Quantity > 0),
               CamerasInOutOfStock = u.Cameras.Count(c => c.Quantity <= 0)
            }).FirstOrDefault();

         return profile;
      }

      public bool UserExistsById(string id)
      {
         if (id is null)
         {
            return false;
         }

         return this.db.Users.Any(u => u.Id == id);
      }



      public void SaveLoginDate(string username, DateTime logginTime)
      {
         var user = this.db.Users.First(u => u.UserName == username);

         user.LastLogin = logginTime;

         this.db.SaveChanges();
      }

      public EditProfileModel GetProfileEditInfo(string id)
             => this.db.Users.Where(u => u.Id == id)
            .Select(u => new EditProfileModel()
            {
               UserId = u.Id,
               Email = u.Email,
               Phone = u.PhoneNumber,
               LastLogin = u.LastLogin
            }).First();

      public EditProfileModel EdtiProfile(string id)
      {
         throw new NotImplementedException();
      }
   }
}
