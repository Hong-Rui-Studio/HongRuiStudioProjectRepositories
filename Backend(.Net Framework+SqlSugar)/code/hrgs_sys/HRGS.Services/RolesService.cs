using HRGS.Dtos;
using HRGS.Entities;
using HRGS.IRepositories;
using HRGS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRGS.Services
{
    public class RolesService : IRolesService
    {
        private IRolesRepository _dal;
        public RolesService(IRolesRepository dal)
        {
            _dal = dal;
        }


        public async Task<int> AddRolesAsync(string title)
        {
            return await _dal.AddAsync(new Roles 
            {
                RolesTitle = title
            });
        }

        public async Task<int> DeleteRolesAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.RolesTitle)) 
            {
                return -1;
            }
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditRolesAsync(Guid id, string title)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.RolesTitle))
            {
                return -1;
            }
            data.RolesTitle = title;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<RolesDto> GetAllRoles()
        {
            var list = _dal.Query();
            return list.Any() ? list.Select(r => new RolesDto 
            {
                Id = r.Id,
                RolesTitle = r.RolesTitle,
                UpdateTime = r.UpdateTime
            }).ToList() : new List<RolesDto>();
        }

        public async Task<List<RolesDto>> GetAllRolesAsync()
        {
            var list = await  _dal.QueryAsync();
            return list.Any() ? list.Select(r => new RolesDto
            {
                Id = r.Id,
                RolesTitle = r.RolesTitle,
                UpdateTime = r.UpdateTime
            }).ToList() : new List<RolesDto>();
        }

        public RolesDto GetRolesById(Guid id)
        {
            var data = _dal.Query(id);
            return data == null ? new RolesDto() : new RolesDto 
            {
                Id = data.Id, 
                RolesTitle = data.RolesTitle,
                CreateTime = data.CreateTime,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<RolesDto> GetRolesByIdAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? new RolesDto() : new RolesDto
            {
                Id = data.Id,
                RolesTitle = data.RolesTitle,
                CreateTime = data.CreateTime,
                UpdateTime = data.UpdateTime
            };
        }

        public List<RolesDto> GetRolesByTitle(string title)
        {
            var list = _dal.Query(r => r.RolesTitle.Contains(title));
            return list.Any() ? list.Select(r => new RolesDto
            {
                Id = r.Id,
                RolesTitle = r.RolesTitle,
                UpdateTime = r.UpdateTime
            }).ToList() : new List<RolesDto>();
        }

        public async Task<List<RolesDto>> GetRolesByTitleAsync(string title)
        {
            var list =await  _dal.QueryAsync(r => r.RolesTitle.Contains(title));
            return list.Any() ? list.Select(r => new RolesDto
            {
                Id = r.Id,
                RolesTitle = r.RolesTitle,
                UpdateTime = r.UpdateTime
            }).ToList() : new List<RolesDto>();
        }
    }
}
