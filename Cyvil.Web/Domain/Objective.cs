using Microsoft.EntityFrameworkCore;

namespace Cyvil.Web.Domain;

public class Objective : Entity
{
    public long Id { get; set; }

    public string Label { get; set; } = string.Empty;

    [Precision(5, 2)]
    public decimal PercentageComplete { get; set; } = 0.0m;

    public bool IsCompleted { get; set; } = false;

    public DateTime? CompletionDate { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeleteDate { get; set; }

    public long CampaignId { get; set; }
    public virtual Campaign? Campaign { get; set; }

    public virtual ICollection<ActionItem> ActionItems { get; set; } = [];
}