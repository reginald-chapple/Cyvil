using System.Security.Claims;
using Cyvil.Web.Data;
using Cyvil.Web.Domain;
using Cyvil.Web.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cyvil.Web.Controllers;

[Route("[controller]")]
public class CampaignsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CampaignsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("Create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Problem,Goal,Beneficiaries,Importance,Solution,CauseId")] Campaign campaign)
    {
        if (ModelState.IsValid)
        {
            campaign.Slug = $"{FriendlyUrlHelper.GetFriendlyTitle(campaign.Name)}-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
            campaign.Users.Add(new CampaignUser
            {
                Role = CampaignUserRole.Creator,
                CanEditCampaign = true,
                CanDeleteCampaign = true,
                CanCreateOpportunity = true,
                CanEditOpportunity = true,
                CanDeleteOpportunity = true,
                CanCreateEvent = true,
                CanEditEvent = true,
                CanDeleteEvent = true,
                CanRemoveVolunteer = true,
                CanRemoveManager = true,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            });
            await _context.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCampaign), new { id = campaign.Id }, campaign);
        }
        return new JsonResult("Your campaign was not saved");
    }

    [Route("{id}/GetCampaign")]
    public async Task<IActionResult> GetCampaign(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var campaign = await _context.Campaigns.Include(c => c.Cause).FirstOrDefaultAsync(c => c.Id == id);

        if (campaign == null)
        {
            return NotFound();
        }

        return new JsonResult(new
        {
            Id = campaign.Id,
            Slug = campaign.Slug,
            Name = campaign.Name,
            Goal = campaign.Goal,
            Cause = campaign.Cause!.Name
        });
    }
}