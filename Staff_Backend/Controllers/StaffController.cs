using Microsoft.AspNetCore.Mvc;
using Staff_Backend.Models;
using Staff_Backend.Services.StaffService;

namespace Staff_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> GetStaffAll()
        {
            return Ok( await _staffService.GetAllStaff());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> Create(StaffModel StaffData)
        {
            return Ok(await _staffService.CreateStaff(StaffData));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> GetById(int Id)
        {
            return Ok(await _staffService.GetByIdStaff(Id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> Update(StaffModel StaffData)
        {
            return Ok(await _staffService.UpdateStaff(StaffData));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> Delete(int Id)
        {
            return Ok(await _staffService.DeleteStaff(Id));
        }

        [HttpPut("Active")]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> ActiveOrInactive(int Id, bool Active)
        {
            return Ok(await _staffService.ActiveOrInactiveStaff(Id, Active));
        }
    }
}
