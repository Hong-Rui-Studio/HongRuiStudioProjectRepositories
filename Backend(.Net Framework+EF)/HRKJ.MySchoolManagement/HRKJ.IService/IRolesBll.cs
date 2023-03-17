using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IRolesBll
    {
        Task<int> AddRolesAsync(string title);
        Task<int> EditRolesAsync(int id, string title);
        Task<int> DeleteRolesAsync(int id);

        Task<List<RolesDto>> GetAllRolesAsync();
        Task<List<RolesDto>> GetRolesByTitleAsync(string title);

        Task<RolesDto> GetRolesByIdAsync(int id);

        RolesDto GetRoleById(int id);
    }
}
