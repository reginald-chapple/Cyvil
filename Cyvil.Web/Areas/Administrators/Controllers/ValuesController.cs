using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cyvil.Web.Data;
using Cyvil.Web.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cyvil.Web.Administrators.Controllers;

[Authorize(Roles = "Administrator")]
[Area("Administrators")]
[Route("[area]/[controller]")]
public class ValuesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ValuesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var values = _context.Values.OrderBy(c => c.Name);
        return View(await values.ToListAsync());
    }

    [Route("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [Route("Create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Details")] Value value)
    {
        if(ModelState.IsValid)
        {
            await _context.AddAsync(value);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(value);
    }
}
