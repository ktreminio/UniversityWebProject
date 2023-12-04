using Kevin.Treminio.University.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> entity)
        {
            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Grade).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Student)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Enrollment> entity);
    }
}
