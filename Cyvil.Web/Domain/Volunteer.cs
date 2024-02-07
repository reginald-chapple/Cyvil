using System.ComponentModel;

namespace Cyvil.Web.Domain;

public class Volunteer : Entity
{
    public VolunteerStatus Status { get; set; } = VolunteerStatus.Pending;

    public long OpportunityId { get; set; }
    public virtual Opportunity? Opportunity { get; set; }

    public string UserId { get; set; } = string.Empty;
    public virtual ApplicationUser? User { get; set; }
}

public enum VolunteerStatus
{
    [Description("Pending")]
    Pending,
    [Description("Review")]
    Review,
    [Description("Accepted")]
    Accepted,
    [Description("Declined")]
    Declined
}