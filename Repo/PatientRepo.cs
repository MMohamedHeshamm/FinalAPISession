using FinalAPISession.Data;
using FinalAPISession.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAPISession.Repo
{
    public class PatientRepo : Generic<Patient>
    {
        public PatientRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        //Get ALL
        public override async Task<IEnumerable<Patient>> GetAll()
        {
            return await _appDbContext.patients.Include(x=>x.Device).Include(x=>x.Doctors).ToListAsync();
        }

        //Add
        public override async Task Add(Patient entity)
        {
            //add device data
            if(entity.Device != null) 
                await _appDbContext.devices.AddAsync(entity.Device);

            //add patient data
            await _appDbContext.patients.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

        }

        //Get By ID 
        public virtual async Task<Patient?> GetBYID(int id)
        {
            return await _appDbContext.patients.Include(x=>x.Device).Include(x=>x.Doctors).FirstOrDefaultAsync(x=>x.Id==id);

        }
    }
}
