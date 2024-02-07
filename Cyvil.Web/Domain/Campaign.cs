using System.ComponentModel.DataAnnotations;

namespace Cyvil.Web.Domain;

public class Campaign : Entity
{
    public Campaign() {}
    
    public long Id { get; set; }

    public string Slug { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public bool IsPublished { get; set; } = false;

    public string Goal { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    public string Problem { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    public string Beneficiaries { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    public string Importance { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    public string Solution { get; set; } = string.Empty;

    public ProgressStatus Status { get; set; } = ProgressStatus.Draft;

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeleteDate { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Deadline { get; set; }

    public DateTime? PublishDate { get; set; }

    public long CauseId { get; set; }
    public virtual Cause? Cause { get; set; }

    // public long CityId { get; set; }
    // public virtual City? City { get; set; }

    public virtual ICollection<CampaignUser> Users { get; set; } = [];
    public virtual ICollection<Donation> Donations { get; set; } = [];
    public virtual ICollection<Meeting> Meetings { get; set; } = [];
    public virtual ICollection<Expediture> Expeditures { get; set; } = [];
    public virtual ICollection<Opportunity> Opportunities { get; set; } = [];
    public virtual ICollection<Objective> Objectives { get; set; } = [];

    public int DaysPassed()
    {
        if (PublishDate.HasValue)
        {
            return (DateTime.Now.Date - PublishDate.Value.Date).Days;
        }
        return 0; 
    }
}