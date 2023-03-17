using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IUsersPermissionBll
    {
        Task<int> AddUsersPermissionAsync(int rolesId, int menusId);
        Task<int> EditUsersPermissionAsync(int id,int rolesId, int menusId);
        Task<int> DeleteUsersPermissionAsync(int id);
        Task<int> DeleteUsersPermissionAsync(int rolesId, int menusId);
        Task<List<UsersPermissionDto>> GetAllPermissionAsync();
        Task<List<UsersPermissionDto>> GetPermissionByRolesIdAsync(int rolesId);

        Task<UsersPermissionDto> GetPermissionByIdAsync(int id);

        List<UsersPermissionDto> GetAllPermission();
        List<UsersPermissionDto> GetPermissionByRolesId(int rolesId);
        UsersPermissionDto GetPermissionById(int id);
    }
}
