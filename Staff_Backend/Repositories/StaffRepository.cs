using Microsoft.EntityFrameworkCore;
using Staff_Backend.Data;
using Staff_Backend.Models;

namespace Staff_Backend.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public async Task<StaffModel> CreateAsync(StaffModel StaffData)
        {
            _context.Staff.Add(StaffData);
            await _context.SaveChangesAsync();

            return StaffData;
        }
        public async Task<List<StaffModel>> GetAllAsync()
        {
            List<StaffModel> StaffData = _context.Staff.ToList(); 

            return StaffData;
        }

        public async Task<StaffModel> GetByIdAsync(int Id)
        {
            StaffModel StaffData = _context.Staff.AsNoTracking().FirstOrDefault(item => item.Id == Id);

            return StaffData;
        }

        public async Task<StaffModel> UpdateAsync(StaffModel StaffData)
        {
            _context.Staff.Update(StaffData);
            await _context.SaveChangesAsync();

            return StaffData;
        }

        public async Task<StaffModel> DeleteAsync(StaffModel StaffData)
        {
            _context.Staff.Remove(StaffData);
            await _context.SaveChangesAsync();
            return StaffData;
        }

    }
}
