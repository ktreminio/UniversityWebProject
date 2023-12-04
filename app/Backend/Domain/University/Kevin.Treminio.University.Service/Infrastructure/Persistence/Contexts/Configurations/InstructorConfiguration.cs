using Kevin.Treminio.University.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> entity)
        {
            entity.ToTable("Instructor");

            entity.Property(e => e.InstructorId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Instructor> entity);
    }
}
