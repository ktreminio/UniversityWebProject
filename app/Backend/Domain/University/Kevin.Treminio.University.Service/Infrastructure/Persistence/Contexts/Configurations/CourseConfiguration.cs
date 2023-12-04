using Kevin.Treminio.University.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Credits).HasColumnType("tinyint");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Course> entity);
    }
}
