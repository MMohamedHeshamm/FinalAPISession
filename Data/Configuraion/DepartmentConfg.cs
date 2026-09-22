using FinalAPISession.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAPISession.Data.Configuraion
{
    public class DepartmentConfg : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);  

            builder.HasMany(x=>x.doctors).WithOne(x=>x.Department).HasForeignKey(x=>x.DepartmentId).OnDelete(DeleteBehavior.Cascade);   

        }
    }
}
