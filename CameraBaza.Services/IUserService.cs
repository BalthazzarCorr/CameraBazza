namespace CameraBazza.Services
{
   using System;
   using Models;

   public interface IUserService
   {
      UserDetailsModel GetUserProfile(string id);

      bool UserExistsById(string id);

      void SaveLoginDate(string username, DateTime logginTime);

      EditProfileModel GetProfileEditInfo(string id);

      EditProfileModel EdtiProfile(string id);
   }
}
