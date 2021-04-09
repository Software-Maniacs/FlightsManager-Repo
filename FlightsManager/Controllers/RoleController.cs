using FlightsManager.Data;
using FlightsManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    /// <summary>
    /// The controller for all the user roles.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _dbContext;


        /// <summary>
        /// The constructor for the controller.
        /// </summary>
        /// <param name="roleManager">Provides the APIs for managing the roles.</param>
        /// <param name="dbContext">The database context.</param>
        public RoleController(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            this._roleManager = roleManager;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Method that returns the view where a role can be created.
        /// </summary>
        /// <returns>The said view.</returns>
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        /// <summary>
        /// Method that creates a role.
        /// </summary>
        /// <param name="role">The view containing the new role.</param>
        /// <returns>Redirects to Index.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// The method for Index.
        /// </summary>
        /// <returns>A view containing all the roles.</returns>
        public async Task<IActionResult> Index()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();
            var userRoles = new List<UserRolesViewModel>();

            foreach (var role in roles)
            {
                var allRoles = new UserRolesViewModel
                {
                    RoleId = role.Id, RoleName = role.Name
                };
                userRoles.Add(allRoles);
            }
            return View(userRoles);
        }

        /// <summary>
        /// Method that returns a view through which the name of a role can be edited.
        /// </summary>
        /// <param name="id">ID of the requested role.</param>
        /// <returns>If the role is found, the method returns a view of the role. If not - a NotFound result.</returns>
        [HttpGet]
        public async Task<IActionResult> EditRoleName(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return NotFound();
            }


            var userRoles = new UserRolesViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };

            return View(userRoles);
        }

        /// <summary>
        /// Method that edits a role's name.
        /// </summary>
        /// <param name="rolesViewModel">The view containing the new role name.</param>
        /// <returns>If successful, the method redirects back to Index. If not, it returns back the view. If the role is not found - a NotFound result.</returns>
        [HttpPost]
        public async Task<IActionResult> EditRoleName(UserRolesViewModel rolesViewModel)
        {
            var role = await _roleManager.FindByIdAsync(rolesViewModel.RoleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {rolesViewModel.RoleId} cannot be found";
                return NotFound();
            }
            else
            {
                role.Id = rolesViewModel.RoleId;
                role.Name = rolesViewModel.RoleName;
             
                var result = await _roleManager.UpdateAsync(role);
                _dbContext.SaveChanges();

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(rolesViewModel);
            }
        }

        /// <summary>
        /// Method that deletes a role.
        /// </summary>
        /// <param name="id">The ID of the requested role.</param>
        /// <returns>If the role is deleted, the method redirects to Index. If not, it again redirects to Index. If the role is not found, the method returns a NotFound result.</returns>
            public async Task<IActionResult> Delete(string id)

            {
                IdentityRole role = await _roleManager.FindByIdAsync(id);

                if (role != null)
                {
                    IdentityResult result = await _roleManager.DeleteAsync(role);
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
                    ModelState.AddModelError("", "Role not found");
                }
                return View("Index");
            }
        }
    }




