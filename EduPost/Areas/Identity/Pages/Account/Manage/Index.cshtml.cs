// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EduPost.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

		public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        //public string Username { get; set; }
        public string Faculty { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string? DisplayAvatar { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /*[Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }*/
            public string Username { get; set; }
            [BindProperty]
            public IFormFile InputAvatar { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            string faculty = user.Faculty;
            string role = user.Role;
            string email = user.Email;
            string userName = await _userManager.GetUserNameAsync(user);
            byte[]? avatar = user.Avatar;
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            //Username = userName;
            Faculty = faculty;
            Role = role;
            Email = email;
            if(avatar != null)
            {
                DisplayAvatar = Convert.ToBase64String(avatar);
            }
            
            Input = new InputModel
            {
                //PhoneNumber = phoneNumber
                Username = userName,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var test = Input.InputAvatar;
			var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //default code
            /*var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }*/

            //change username
            var userName = await _userManager.GetUserNameAsync(user);
            if (Input.Username != userName)
            {
                user.UserName = Input.Username;
                _context.Update(user);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    StatusMessage = "Unexpected error when trying to change User Name.";
                    return RedirectToPage();
                }
            }

            //change avatar
            if (Input.InputAvatar != null)
            { 
                user.Avatar = await ImageToByte(Input.InputAvatar);
                _context.Update(user);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    StatusMessage = "Unexpected error when trying to update the avatar.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        private async Task<byte[]?> ImageToByte(IFormFile? image)
        {
            using(var stream = new MemoryStream())
            {
                if(image != null)
                {
                    await image.CopyToAsync(stream);
				    stream.Position = 0;
                    return stream.ToArray();
                }
				return null;
			}
        }
	}
}
