using System.ComponentModel.DataAnnotations;

namespace Cyvil.Web.Domain;

public class Community : Entity
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    public string About { get; set; } = string.Empty;

    public bool IsEnabled { get; set; } = false;

    public long? ParentId { get; set; }
    public virtual Community? Parent { get; set; }

    public long CauseId { get; set; }
    public virtual Cause? Cause { get; set; }

    public ICollection<CommunityMember> Members { get; set; } = [];
    public ICollection<Community> Subcommunities { get; set; } = [];
}