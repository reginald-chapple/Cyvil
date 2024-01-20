using Cyvil.Web.Data;
using Cyvil.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cyvil.Web.ViewComponents;

public class SaveCampaignViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public SaveCampaignViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        ViewData["Cause"] = new SelectList(_context.Causes, "Id", "Name");
        return View(new Campaign());
    }
}