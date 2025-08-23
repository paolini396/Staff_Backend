using Staff_Backend.Models;
using Staff_Backend.Repositories;
using System.Collections.Generic;

namespace Staff_Backend.Services.StaffService
{
    public class StaffService : IStaffService
    {

        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository));
        }        

        async Task<ServiceResponse<List<StaffModel>>> IStaffService.CreateStaff(StaffModel StaffData)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();
            serviceResponse.Data = new List<StaffModel>();

            try
            {
                if (StaffData == null)
                {
                    serviceResponse.Message = "É necessário informar os dados para cadastrar.";
                    serviceResponse.Success = false;

                    return serviceResponse;
                    
                }

                StaffModel StaffDataParsed = await _staffRepository.CreateAsync(StaffData);

                serviceResponse.Data.Add(StaffDataParsed);
                serviceResponse.Message = "Staff Criado com sucesso!";

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false; 
            }

            return serviceResponse;
        }

        async Task<ServiceResponse<List<StaffModel>>> IStaffService.GetAllStaff()
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();
            serviceResponse.Data = new List<StaffModel>();

            try
            {
                serviceResponse.Data = await _staffRepository.GetAllAsync();

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }


        async Task<ServiceResponse<List<StaffModel>>> IStaffService.GetByIdStaff(int Id)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();
            serviceResponse.Data = new List<StaffModel>();
            try
            {
                if (Id == 0)
                {
                    
                    serviceResponse.Message = "É necessário informar o ID.";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                StaffModel StaffDataParsed = await _staffRepository.GetByIdAsync(Id);

                if (StaffDataParsed == null)
                {
                    serviceResponse.Message = "Staff não encontrado.";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                serviceResponse.Data.Add(StaffDataParsed);
                serviceResponse.Message = "Staff encontrado.";

            }catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        async Task<ServiceResponse<List<StaffModel>>> IStaffService.UpdateStaff(StaffModel StaffData)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();
            serviceResponse.Data = new List<StaffModel>();

            try
            {
                if (StaffData == null)
                {
                    serviceResponse.Message = "É necessário informar dados para atualizar.";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                StaffModel StaffDataValid = await _staffRepository.GetByIdAsync(StaffData.Id);

                if (StaffDataValid == null)
                {
                    serviceResponse.Message = $"ID {StaffData.Id} não encontrado.";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                StaffData.CreateAt = StaffDataValid.CreateAt;
                StaffData.UpdateAt = DateTime.Now.ToLocalTime();

                StaffModel StaffDataResult = await _staffRepository.UpdateAsync(StaffData);

                serviceResponse.Data.Add(StaffDataResult);
                serviceResponse.Message = "Staff Atualizado!";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }


        Task<ServiceResponse<List<StaffModel>>> IStaffService.DeleteStaff(int Id)
        {
            throw new NotImplementedException();
        }

     
        async Task<ServiceResponse<List<StaffModel>>> IStaffService.ActiveOrInactiveStaff(int Id, bool Active)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();
            serviceResponse.Data = new List<StaffModel>();

            try
            {
                StaffModel StaffData = await _staffRepository.GetByIdAsync(Id);

                if (StaffData == null)
                {
                    serviceResponse.Message = $"ID {Id} não encontrado.";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                StaffData.Active = Active;
                StaffData.UpdateAt = DateTime.Now.ToLocalTime();

                StaffModel StaffDataResult = await _staffRepository.UpdateAsync(StaffData);

                serviceResponse.Data.Add(StaffDataResult);
                string status = Active ? "Ativado" : "Desativado";
                serviceResponse.Message = $"Staff {status} com Sucesso.";

            }
            catch (Exception ex)
            {
               serviceResponse.Message= ex.Message;
               serviceResponse.Success = false;
            }

            return serviceResponse;
        }

    }
}
