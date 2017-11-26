namespace CameraBazza.Web.Controllers
{
   using System.Linq;
   using Data.Models;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models.Cameras;
   using Services;
   using Services.Models;


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

         if (cameraModel.LightMeterings == null || !cameraModel.LightMeterings.Any())
         {
            ModelState.AddModelError(nameof(cameraModel.LightMeterings),"Please select one of the check boxes");
         }
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

      [Authorize]
      public IActionResult Edit(int id) => View(this.cameras.Edit(id));

      [Authorize]
      [HttpPost]
      public IActionResult Edit(int id, CamerasDetailModel camModel)
      {
         if (!ModelState.IsValid)
         {
            return View(camModel);
         }

         this.cameras.Edit(
            id,
            camModel.Make,
            camModel.Model,
            camModel.Price,
            camModel.Quantity,
            camModel.MinShutterSpeed,
            camModel.MaxShutterSpeed,
            camModel.MinISO,
            camModel.MaxISO,
            camModel.IsFullFrame,
            camModel.VideoResolution,
            camModel.LightMeterings,
            camModel.Description,
            camModel.ImgUrl
         );
         return this.RedirectToAction("Index","Home");
      }

      [Authorize]
      public IActionResult All()
         => View(this.cameras.All());

      [Authorize]
      public IActionResult Details(int id) => View(this.cameras.Details(id));


      [Authorize]
      public IActionResult Delete(int id)
      {
         if (this.cameras.CameraExists(id))
         {
            var cameraForDeleteing = this.cameras.GetCameraCompleteEditInfromatio(id);

            return View(cameraForDeleteing);
         }

         return NotFound();
      }

      [Authorize]
      [HttpPost]
      public IActionResult Destroy(int id)
      {
         if (this.cameras.CameraExists(id))
         {
            this.cameras.Delete(id);

            return RedirectToAction("Index","Home");
         }

         return NotFound();
      }


   }
}
