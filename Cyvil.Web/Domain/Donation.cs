using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Cyvil.Web.Domain;

public class Donation : Entity
{
    public long Id { get; set; }

    [Precision(7, 2)]
    public decimal Amount { get; set; } = 0.0m;

    [EmailAddress]
    public string DonorEmail { get; set; } = string.Empty;
    public string DonorName { get; set; } = string.Empty;

    public long CampaignId { get; set; }
    public virtual Campaign? Campaign { get; set; }

}