namespace Cyvil.Web.Domain;

public class Opportunity : Entity
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool IsClosed { get; set; } = false;

    public long CampaignId { get; set; }
    public virtual Campaign? Campaign { get; set; }

    public virtual ICollection<Volunteer> Volunteers { get; set; } = [];

}