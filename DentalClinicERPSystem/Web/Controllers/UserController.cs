using Business.DTO;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    public readonly IUserService _userService;
    public readonly RoleManager<IdentityRole> _roleManager;
    public UserController (IUserService userService, RoleManager<IdentityRole> roleManager)
    {
        _userService = userService;
        _roleManager = roleManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllUsersAsync();
        return View(users);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View(new CreateUserViewModel
        {
            User = new CreateUserDto(),
            Roles = await _roleManager.Roles
                .AsNoTracking()
                .Where(r => r.Name != null)
                .Select(r => r.Name!)
                .ToListAsync(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _userService.CreateUserAsync(model.User);

        if (result.Succeeded)
            return RedirectToAction("Index");

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(model);
    }

}