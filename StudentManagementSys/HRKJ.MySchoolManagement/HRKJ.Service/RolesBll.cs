using HRKJ.Dtos;
using HRKJ.IRepository;
using HRKJ.IService;
using HRKJ.Repository;
using System;
using System.Collections.Generic;
using HRKJ.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace HRKJ.Service
{
    public class RolesBll : IRolesBll
    {
        private IRolesDal _dal = new RolesDal();
        public async Task<int> AddRolesAsync(string title)
        {
            return await _dal.AddAsync(new Roles
            {
                Title= title
            });
        }

        public async Task<int> DeleteRolesAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditRolesAsync(int id, string title)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            data.Title= title;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public async Task<List<RolesDto>> GetAllRolesAsync()
        {
            var data = await _dal.QueryAsync();
            return data.Select(r => new RolesDto
            {
                Id = r.Id,
                Title = r.Title,
                UpdateTime = r.UpdateTime
            }).ToList();
        }

        public async Task<RolesDto> GetRolesByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? null : new RolesDto
            {
                Id = data.Id,
                Title = data.Title,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<List<RolesDto>> GetRolesByTitleAsync(string title)
        {
            var data = await _dal.QueryAsync(r => r.Title.Contains(title));
            return data.Select(r => new RolesDto
            {
                Id = r.Id,
                Title = r.Title,
                UpdateTime = r.UpdateTime
            }).ToList();
        }

        public RolesDto GetRoleById(int id)
        {
            var data = _dal.Query(id);
            return data == null ? null : new RolesDto { Id = data.Id, Title = data.Title };
        }
    }
}
