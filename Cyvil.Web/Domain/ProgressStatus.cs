using System.ComponentModel;

namespace Cyvil.Web.Domain
{
    public enum ProgressStatus
    {
        [Description("Draft")]
        Draft,
        [Description("Postponed")]
        Postponed,
        [Description("In progress")]
        InProgress,
        [Description("Cancelled")]
        Cancelled,
        [Description("Completed")]
        Completed
    }
}