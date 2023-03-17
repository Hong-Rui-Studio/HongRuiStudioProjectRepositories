using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRGS.Dtos;
namespace HRGS.IServices
{
    public interface IRolesService
    {
        
        Task<int> AddRolesAsync(string title);

        Task<int> EditRolesAsync(Guid id, string title);

        Task<int> DeleteRolesAsync(Guid id);

        Task<List<RolesDto>> GetAllRolesAsync();

        Task<List<RolesDto>> GetRolesByTitleAsync(string title);

        List<RolesDto> GetAllRoles();

        List<RolesDto> GetRolesByTitle(string title);

        Task<RolesDto> GetRolesByIdAsync(Guid id);
        RolesDto GetRolesById(Guid id);
    }
}
