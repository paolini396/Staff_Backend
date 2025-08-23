using Staff_Backend.Models;

namespace Staff_Backend.Repositories
{
    public interface IStaffRepository
    {
        Task<StaffModel> CreateAsync(StaffModel StaffData);
        Task<List<StaffModel>> GetAllAsync();
        Task<StaffModel> GetByIdAsync(int id);
        Task<StaffModel> UpdateAsync(StaffModel StaffData);
        Task<StaffModel> DeleteAsync(StaffModel StaffData);
    }
}

