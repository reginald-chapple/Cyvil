using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cyvil.Web.Models;
using Cyvil.Web.Data;
using Microsoft.AspNetCore.Identity;
using Cyvil.Web.Domain;
using Cyvil.Web.Data.Services;

namespace Cyvil.Web.Controllers;

[Route("[controller]")]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IUserService userService)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _context = context;
        _userService = userService;
    }

    [Route("~/")]
    public async Task<IActionResult> Index()
    {
        if (_signInManager.IsSignedIn(HttpContext.User))
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null && await _userManager.IsInRoleAsync(user, "Administrator"))
            {
                return RedirectToAction(nameof(Administrators.Controllers.HomeController.Index), "Home", new { area = "Administrators" });
            }
        }
        return View();
    }

    [Route("/Setup")]
    public async Task<IActionResult> Setup()
    {
        await _userService.CreateSuperUserAsync();
        return RedirectToAction(nameof(Index));
    }

    [Route("/Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
