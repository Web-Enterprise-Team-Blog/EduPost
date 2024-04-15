using EduPost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace EduPost.Service
{
    public class AvatarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly ImageConverter _imageConverter;

        public AvatarViewComponent(UserManager<User> userManager, ImageConverter imageConverter)
        {
            _userManager = userManager;
            _imageConverter = imageConverter;
        }

     
        public async Task<IViewComponentResult> InvokeAsync(int? userId = null)
        {
            User user = null;

            if (!userId.HasValue)
            {
                user = await _userManager.GetUserAsync(HttpContext.User);
            }
            else
            {
                user = await _userManager.FindByIdAsync(userId.Value.ToString());
            }

            string avatarBase64;
            string imagePath = "images/user.jpg";
            string defaultAvatarBase64 = _imageConverter.ImageToBase64(imagePath);

            if (user?.Avatar != null && user.Avatar.Length > 0)
            {
                avatarBase64 = Convert.ToBase64String(user.Avatar);
            }
            else
            {
                avatarBase64 = defaultAvatarBase64;
            }

            return View((object)avatarBase64);
        }
    }
    public class ImageConverter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageConverter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string ImageToBase64(string relativeImagePath)
        {
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, relativeImagePath);
            try
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                return Convert.ToBase64String(imageBytes);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
