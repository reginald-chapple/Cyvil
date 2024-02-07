using Cyvil.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyvil.Web.Data.EntityConfigurations
{
    public class CommunityMemberConfiguration : IEntityTypeConfiguration<CommunityMember>
    {
        public void Configure(EntityTypeBuilder<CommunityMember> builder)
        {
            builder.HasKey(x => new { x.CommunityId, x.MemberId });

            builder.HasOne(x => x.Community)
                .WithMany(a => a.Members)
                .HasForeignKey(x => x.CommunityId)
                .IsRequired();

            builder.HasOne(x => x.Member)
                .WithMany(a => a.Communities)
                .HasForeignKey(x => x.MemberId)
                .IsRequired();
        }
    }
}