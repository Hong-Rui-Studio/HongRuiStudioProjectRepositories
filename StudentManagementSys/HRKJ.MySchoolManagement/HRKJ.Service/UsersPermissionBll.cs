using HRKJ.Dtos;
using HRKJ.IRepository;
using HRKJ.IService;
using HRKJ.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRKJ.Entity;
namespace HRKJ.Service
{
    public class UsersPermissionBll : IUsersPermissionBll
    {
        private IUsersPermissionsDal _dal = new UsersPermissionsDal(); 
        public async Task<int> AddUsersPermissionAsync(int rolesId, int menusId)
        {
            return await _dal.AddAsync(new UsersPermissions 
            {
                RolesId = rolesId,
                MenusId = menusId
            });
        }

        public async Task<int> DeleteUsersPermissionAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditUsersPermissionAsync(int id, int rolesId, int menusId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.RolesId = rolesId;
            data.MenusId= menusId;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<UsersPermissionDto> GetAllPermission()
        {
             var data = _dal.Query();
            return data.Any() ? data.Select(u => new UsersPermissionDto 
            {
                Id = u.Id,
                RolesId= u.RolesId,
                MenusId= u.MenusId,
                UpdateTime= u.UpdateTime
            }).ToList() : new List<UsersPermissionDto>();
        }

        public async Task<List<UsersPermissionDto>> GetAllPermissionAsync()
        {
            var data = await _dal.QueryAsync();
            return data.Any() ? data.Select(u => new UsersPermissionDto
            {
                Id = u.Id,
                RolesId = u.RolesId,
                MenusId = u.MenusId,
                UpdateTime = u.UpdateTime
            }).ToList() : new List<UsersPermissionDto>();
        }

        public UsersPermissionDto GetPermissionById(int id)
        {
            var data = _dal.Query(id);
            return data == null ? new UsersPermissionDto() : new UsersPermissionDto 
            {
                Id = data.Id,
                RolesId = data.RolesId,
                MenusId = data.MenusId,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<UsersPermissionDto> GetPermissionByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? new UsersPermissionDto() : new UsersPermissionDto
            {
                Id = data.Id,
                RolesId = data.RolesId,
                MenusId = data.MenusId,
                UpdateTime = data.UpdateTime
            };
        }

        public List<UsersPermissionDto> GetPermissionByRolesId(int rolesId)
        {
            var data = _dal.Query(u => u.RolesId == rolesId);
            return data.Any() ? data.Select(u => new UsersPermissionDto
            {
                Id = u.Id,
                RolesId = u.RolesId,
                MenusId = u.MenusId,
                UpdateTime = u.UpdateTime
            }).ToList() : new List<UsersPermissionDto>();
        }

        public async Task<List<UsersPermissionDto>> GetPermissionByRolesIdAsync(int rolesId)
        {
            var data = await _dal.QueryAsync(u => u.RolesId == rolesId);
            return data.Any() ? data.Select(u => new UsersPermissionDto
            {
                Id = u.Id,
                RolesId = u.RolesId,
                MenusId = u.MenusId,
                UpdateTime = u.UpdateTime
            }).ToList() : new List<UsersPermissionDto>();
        }


        public async Task<int> DeleteUsersPermissionAsync(int rolesId, int menusId) 
        {
            var data = await _dal.QueryAsync(up => up.RolesId == rolesId && up.MenusId == menusId);
            if (data.Count > 0)
            {
                return await _dal.DeleteAsync(data[0]);
            }
            return -1;
        }
    }
}
