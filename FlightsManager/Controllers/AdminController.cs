using FlightsManager.Data;
using FlightsManager.Models;
using FlightsManager.Models.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    /// <summary>
    /// The controller for Admin.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IPasswordHasher<ApplicationUser> _passwordHasher;
        private ApplicationDbContext _dbContext;

        /// <summary>
        /// The default constructor for AdminController.
        /// </summary>
        /// <remarks>
        /// When the constructor is initiated, the controller connects to the database.
        /// </remarks>
        /// <param name="userManager">Provides the APIs for managing user.</param>
        /// <param name="roleManager">Provides the APIs for managing roles.</param>
        /// <param name="passwordHasher">Provides an abstraction for hashing passwords.</param>
        /// <param name="dbContext">The database context.</param>
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IPasswordHasher<ApplicationUser> passwordHasher, ApplicationDbContext dbContext)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._passwordHasher = passwordHasher;
            this._dbContext = dbContext;
        }
        /// <summary>
        /// Index action.
        /// </summary>
        /// <returns>View of Index.</returns>
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// Method that lists all users.
        /// </summary>
        /// <returns>A view, containing the list of users.</returns>
        public async Task<IActionResult> UserList()
        {
            //var users = await _userManager.Users.Where(u => u.ReservationID == null).ToListAsync();

            var users = await _userManager.Users.Where(u => u.ReservationID == null).ToListAsync();
            var getAllUsersViewModel = new List<GetAllUsersViewModel>();

            foreach (ApplicationUser user in users)
            {
                var allUsersVM = new GetAllUsersViewModel
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    Email = user.Email,
                    UserPIN = user.UserPIN,
                    TelephoneNumber = user.PhoneNumber,
                    Roles = await GetUserRoles(user)
                };
                getAllUsersViewModel.Add(allUsersVM);
            }
            return View(getAllUsersViewModel);
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        /// <summary>
        /// Method that redirects to the Create view.
        /// </summary>
        /// <returns>A view, where the admin can create a user.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            CreateUserViewModel model = new CreateUserViewModel();
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            return View(model);
        }

        /// <summary>
        /// Method through which the admin creates a user.
        /// </summary>
        /// <param name="createUser">The needed info for the user to be created.</param>
        /// <returns>If successful, the method redirects to index. If not, it returns back the view.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel createUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName= createUser.Username,
                    FirstName= createUser.FirstName,
                    LastName= createUser.LastName,
                    Email= createUser.Email,
                    PhoneNumber= createUser.TelephoneNumber,
                    Address= createUser.Address,
                    UserPIN= createUser.UserPIN,
                };
                var result = await _userManager.CreateAsync(appUser, createUser.Password);

                if (result.Succeeded)
                {
                    var currentUser = _userManager.FindByIdAsync(appUser.Id);
                    var role = _roleManager.FindByIdAsync(createUser.Roles).Result;
                    await _userManager.AddToRoleAsync(appUser, role.Name);
                     _dbContext.SaveChanges();

                    return RedirectToAction("Index");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(createUser);
        }

        /// <summary>
        /// Method that gets the Edit view.
        /// </summary>
        /// <param name="id">The ID of the requested user.</param>
        /// <returns>If found, it returns the Edit view with the info of the user on it. If not - a NotFound result.</returns>
       [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return NotFound();
            }


            var userViewModel = new EditUserViewModel
            {
                UserId=user.Id,
               Username=user.UserName,
               FirstName=user.FirstName,
               LastName=user.LastName,
               Email=user.Email,
               UserPIN=user.UserPIN,
               Address=user.Address,
               TelephoneNumber=user.PhoneNumber,
            };

            return View(userViewModel);
        }
        /// <summary>
        /// Method through which a user is edited.
        /// </summary>
        /// <param name="userViewModel">The view, containing the user's new info.</param>
        /// <returns>If successful, it redirects to Index. If not, it returns the view again. If the user can't be found - a NotFound result.</returns>
      
        public async Task<IActionResult> Edit(EditUserViewModel userViewModel)
        {
            var user = await _userManager.FindByIdAsync(userViewModel.UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userViewModel.UserId} cannot be found";
                return NotFound();
            }
            else
            {
                user.UserName = userViewModel.Username;
                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;
                user.Email = userViewModel.Email;
                user.UserPIN = userViewModel.UserPIN;
                user.Address = userViewModel.Address;
                user.PhoneNumber = userViewModel.TelephoneNumber;

               var result = await _userManager.UpdateAsync(user);
                _dbContext.SaveChanges();

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
               
                return View(userViewModel);
            }
        }

        /// <summary>
        /// Method through which a user is deleted.
        /// </summary>
        /// <param name="id">The ID of the requested user.</param>
        /// <returns>If successful, the method redirects to Index. If not, it returns a NotFound result. If the requested user's info is not valid, it returns back the view.</returns>
        public async Task<IActionResult> Delete(string id)

        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser !=null)
            {
                IdentityResult result = await _userManager.DeleteAsync(appUser);
                await _dbContext.SaveChangesAsync();

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
                
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View("Index");
        }

    }
}

