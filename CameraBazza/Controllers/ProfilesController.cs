namespace CameraBazza.Web.Controllers
{
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Mvc;
   using Services;
   using Services.Models;

   public class ProfilesController : Controller
   {
      private readonly ICamerasService cameraService;
      private readonly IUserService userService;

      public ProfilesController(ICamerasService cameraService, IUserService userService)
      {
         this.cameraService = cameraService;
         this.userService = userService;
      }

      public IActionResult Details(string id)
      {
         var model = new ProfileViewModel();

         if (this.userService.UserExistsById(id))
         {
            model.UserDetailses = this.userService.GetUserProfile(id);
            model.Cameras = this.cameraService.GetCamerasDetailsForUser(id);

            return View(model);
         }

         return BadRequest();
      }

      public IActionResult Edit(string id)
      {
         if (this.userService.UserExistsById(id) && this.User.GetUserId() == id)
         {
            EditProfileModel editProfile = this.userService.GetProfileEditInfo(id);

            return View(editProfile);
         }
         return BadRequest();
      }
   }
}
