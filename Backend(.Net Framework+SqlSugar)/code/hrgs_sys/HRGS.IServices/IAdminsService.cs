using HRGS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRGS.IServices
{
    public interface IAdminsService
    {
        Task<int> AddAdminsAsync(string nickname, DateTime bornDate, int gender, string email, string tel, string pwd, string photo, string images, string address, string wechat, Guid rolesId);
        Task<int> EditAdminsAsync(Guid id,string nickname, DateTime bornDate, int gender, string email, string tel,  string photo, string images, string address, string wechat, Guid rolesId);
        Task<int> DeleteAdminsAsync(Guid id);


        Task<List<AdminsDto>> GetAllAdmins();
        List<AdminsDto> GetAll();

        Task<List<AdminsDto>> GetAdminsByNickNameAsync(string nickname);
        List<AdminsDto> GetAdminsByNickName(string nickname);

        Task<AdminsDto> GetAdminsByIdAsync(Guid id);
        AdminsDto GetAdminsById(Guid id);


        Task<List<AdminsDto>> GetAdminsByRolesIdAsync(Guid rolesId);
        List<AdminsDto> GetAdminsByRolesId(Guid rolesId);
    }
}
