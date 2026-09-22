using FinalAPISession.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAPISession.Data.Configuraion
{
    public class DeviceConfg : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.Patient).WithOne(x=>x.Device).HasForeignKey<Device>(x=>x.PatientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
