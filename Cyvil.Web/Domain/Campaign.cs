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

    [DataType(DataType.Date)]
    public DateTime? Deadline { get; set; }

    public DateTime? PublishDate { get; set; }

    public long CauseId { get; set; }
    public virtual Cause? Cause { get; set; }

    // public long CityId { get; set; }
    // public virtual City? City { get; set; }

    public int DaysPassed()
    {
        if (PublishDate.HasValue)
        {
            return (DateTime.Now.Date - PublishDate.Value.Date).Days;
        }
        return 0; 
    }
}