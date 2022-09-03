namespace BeachIsland.Server.Data.Configurations
{
    using BeachIsland.Server.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartnerEntityTypeConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Partner>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
