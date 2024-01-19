using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cyvil.Web.Data;
using Cyvil.Web.Domain;
using Microsoft.AspNetCore.Authorization;
using Cyvil.Web.Infrastructure.Helpers;

namespace Cyvil.Web.Administrators.Controllers;

[Authorize(Roles = "Administrator")]
[Area("Administrators")]
[Route("[area]/[controller]")]
public class CausesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CausesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Causes.Include(c => c.Parent).OrderBy(c => c.Name);
        return View(await applicationDbContext.ToListAsync());
    }

    [Route("{id}")]
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cause = await _context.Causes
            .Include(c => c.Parent)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cause == null)
        {
            return NotFound();
        }

        return View(cause);
    }

    // GET: Causes/Create
    [Route("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [Route("Create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Cause cause)
    {
        if (ModelState.IsValid)
        {
            cause.Slug = FriendlyUrlHelper.GetFriendlyTitle(cause.Name);
            _context.Add(cause);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cause);
    }

    [Route("{id}/Edit")]
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cause = await _context.Causes.FindAsync(id);
        if (cause == null)
        {
            return NotFound();
        }
        return View(cause);
    }

    [Route("{id}/Edit")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] Cause cause)
    {
        if (id != cause.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                cause.Slug = FriendlyUrlHelper.GetFriendlyTitle(cause.Name);
                _context.Update(cause);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauseExists(cause.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ParentId"] = new SelectList(_context.Causes, "Id", "Slug", cause.ParentId);
        return View(cause);
    }

    [Route("{id}/Delete")]
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cause = await _context.Causes
            .Include(c => c.Parent)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cause == null)
        {
            return NotFound();
        }

        return View(cause);
    }

    [Route("{id}/Delete")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var cause = await _context.Causes.FindAsync(id);
        if (cause != null)
        {
            _context.Causes.Remove(cause);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CauseExists(long id)
    {
        return _context.Causes.Any(e => e.Id == id);
    }
}

