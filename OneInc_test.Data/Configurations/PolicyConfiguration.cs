using OneInc_test.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OneInc_test.Data.Configurations
{
    public class PolicyConfiguration : EntityTypeConfiguration<Policy>
    {
        public void SetConfiguration()
        {
            Property(e => e.Id).HasDatabaseGeneratedOption
                (DatabaseGeneratedOption.Identity);
            Property(e => e.StartDate).HasColumnType("date");
            Property(e => e.EndDate).HasColumnType("date");
            Property(e => e.BirthDate).HasColumnType("date");
            Property(e => e.ObjectName).IsRequired().HasMaxLength(40);
            Property(e => e.PolicyNumber)
                .HasDatabaseGeneratedOption(
                    DatabaseGeneratedOption.Computed);
            Property(e => e.UpdateDate).HasColumnType("date");
            Property(e => e.NameOwner).IsRequired().HasMaxLength(30);
            Property(e => e.SurnameOwner).IsRequired().HasMaxLength(50);
            Property(e => e.MonthCreated).HasColumnName("MonthCreated");
        }
    }
}