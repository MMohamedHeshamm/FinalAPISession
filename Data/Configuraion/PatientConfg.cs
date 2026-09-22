using FinalAPISession.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAPISession.Data.Configuraion
{
    public class PatientConfg : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Doctors).WithMany(x => x.patients);

        }
    }
}
