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
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _dbContext;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public RoleController(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            this._roleManager = roleManager;
            this._dbContext = dbContext;
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();
            var userRoles = new List<UserRolesViewModel>();

            foreach (var role in roles)
            {
                var allRoles = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                userRoles.Add(allRoles);
            }
            return View(userRoles);
        }

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




