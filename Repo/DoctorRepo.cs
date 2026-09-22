using FinalAPISession.Data;
using FinalAPISession.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAPISession.Repo
{
    public class DoctorRepo : Generic<Doctor>
    {
        public DoctorRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        //Get BY ID
        public override async Task<Doctor?> GetBYID(int id)
        {
            return await _appDbContext.doctors.Include(x=>x.Department).FirstOrDefaultAsync(x=>x.Id==id);

        }
    }
}
