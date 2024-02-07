using System.ComponentModel.DataAnnotations;

namespace Cyvil.Web.Domain;

public class Meeting : Entity
{
    public long Id { get; set; }

    public string Slug { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeleteDate { get; set; }

    [DataType(DataType.Date)]
    public DateOnly Date { get; set; }

    [DataType(DataType.Time)]
    public TimeOnly StartTime { get; set; }

    [DataType(DataType.Time)]
    public TimeOnly EndTime { get; set; }

    public long CampaignId { get; set; }
    public virtual Campaign? Campaign { get; set; }

    public virtual ICollection<MeetingAttendee> Attendees { get; set; } = [];
    public virtual ICollection<Invite> Invites { get; set; } = [];
}