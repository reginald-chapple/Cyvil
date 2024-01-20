using System.ComponentModel;

namespace Cyvil.Web.Domain;

public class CampaignUser : Entity
{
    public long Id { get; set; }

    public CampaignUserRole Role { get; set; } = CampaignUserRole.Volunteer;

    public bool CanEditCampaign { get; set; } = false;

    public bool CanDeleteCampaign { get; set; } = false;

    public bool CanCreateOpportunity { get; set; } = false;

    public bool CanEditOpportunity { get; set; } = false;

    public bool CanDeleteOpportunity { get; set; } = false;

    public bool CanCreateEvent { get; set; } = false;

    public bool CanEditEvent { get; set; } = false;

    public bool CanDeleteEvent { get; set; } = false;

    public bool CanRemoveVolunteer { get; set; } = false;

    public bool CanRemoveManager { get; set; } = false;

    public long CampaignId { get; set; }
    public virtual Campaign? Campaign { get; set; }

    public string UserId { get; set; } = string.Empty;
    public virtual ApplicationUser? User { get; set; }
}

public enum CampaignUserRole
{
    [Description("Creator")]
    Creator,
    [Description("Manager")]
    Manager,
    [Description("Volunteer")]
    Volunteer
}