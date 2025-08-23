using Staff_Backend.Models;

namespace Staff_Backend.Services.StaffService
{
    public interface IStaffService
    {
        Task<ServiceResponse<List<StaffModel>>> CreateStaff(StaffModel StaffData);
        Task<ServiceResponse<List<StaffModel>>> GetAllStaff();
        Task<ServiceResponse<List<StaffModel>>> GetByIdStaff(int Id);
        Task<ServiceResponse<List<StaffModel>>> UpdateStaff(StaffModel StaffData);
        Task<ServiceResponse<List<StaffModel>>> DeleteStaff(int Id);
        Task<ServiceResponse<List<StaffModel>>> ActiveOrInactiveStaff(int Id, bool Active);
    }

}
