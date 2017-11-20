namespace CameraBazza.Web.Controllers
{
   using Data.Models;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models.Cameras;
   using Services;

   public class CamerasController : Controller
   {

      private readonly ICamerasService cameras;

      private readonly UserManager<User> userManager;


      public CamerasController(ICamerasService cameras, UserManager<User> userManager)
      {
         this.cameras = cameras;
         this.userManager = userManager;
      }

      [Authorize]
      public IActionResult Add() => View();

      [HttpPost]
      [Authorize]
      public IActionResult Add(AddCameraViewModel cameraModel)
      {
         if (!ModelState.IsValid)
         {
            return View(cameraModel);
         }
         this.cameras.Create(
            cameraModel.Make,
            cameraModel.Model,
            cameraModel.Price,
            cameraModel.Quantity,
            cameraModel.MinShutterSpeed,
            cameraModel.MaxShutterSpeed,
            cameraModel.MinISO,
            cameraModel.MaxISO,
            cameraModel.IsFullFrame,
            cameraModel.VideoResolution,
            cameraModel.LightMeterings,
            cameraModel.Description,
            cameraModel.ImageURL,
            this.userManager.GetUserId(User)
            );

         return RedirectToAction(nameof(HomeController.Index), "Home");
      }
   }
}
