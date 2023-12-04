using Kevin.Treminio.University.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> entity)
        {
            entity.ToTable("CourseAssignment");
            entity.HasKey(e => new { e.InstructorId, e.CourseId });

            entity.Property(e => e.InstructorId)
                .IsRequired();

            entity.Property(e => e.CourseId)
                .IsRequired();

            entity.HasOne(d => d.Course)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Instructor)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CourseAssignment> entity);
    }
}
