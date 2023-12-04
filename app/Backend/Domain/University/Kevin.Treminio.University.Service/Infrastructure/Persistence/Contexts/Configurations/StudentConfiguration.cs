using Kevin.Treminio.University.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Address)
                .HasMaxLength(150);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30);
            entity.Property(e => e.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Student> entity);
    }
}
