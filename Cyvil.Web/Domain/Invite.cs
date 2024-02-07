using System.ComponentModel.DataAnnotations;

namespace Cyvil.Web.Domain;

public class Invite : Entity
{
    public long Id { get; set; }

    public string Label { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeleteDate { get; set; }

    [EmailAddress]
    public string AttendeeEmail { get; set; } = string.Empty;
    public string AttendeeName { get; set; } = string.Empty;

    public long MeetingId { get; set; }
    public virtual Meeting? Meeting { get; set; }
}