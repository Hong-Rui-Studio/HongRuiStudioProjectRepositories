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
    public class SystemMenusBll : ISystemMenusBll
    {

        private ISystemMenusDal _dal = new SystemMenusDal();


        public async Task<int> AddMenusAsync(string title, string link, string icons, int parentId = 0)
        {
            return await _dal.AddAsync(new SystemMenus 
            {
                Title= title,
                Link=link,
                Icons=icons,
                ParentId=parentId
            });
        }

        public async Task<int> DeleteMenusAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditMenusAsync(int id, string title, string link, string icons, int parentId = 0)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Title = title;
            data.Link = link;
            data.Icons = icons;
            data.ParentId= parentId;
            data.UpdateTime= DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public async Task<List<SystemMenusDto>> GetAllMenusAsync()
        {
            var data = await _dal.QueryAsync();
            return !data.Any() ? new List<SystemMenusDto>() 
                : data.Select(m => new SystemMenusDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Link=m.Link,
                    Icons  = m.Icons, 
                    ParentId=m.ParentId,
                    UpdateTime= m.UpdateTime
                }).ToList();
        }

        public async Task<List<SystemMenusDto>> GetAllMenusByParentIdAsync(int parentId)
        {
            var data = await _dal.QueryAsync(m => m.ParentId == parentId);
            return !data.Any() ? new List<SystemMenusDto>()
                : data.Select(m => new SystemMenusDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Link = m.Link,
                    Icons = m.Icons,
                    ParentId = m.ParentId,
                    UpdateTime = m.UpdateTime
                }).ToList();
        }

        public async Task<SystemMenusDto> GetMenusByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? new SystemMenusDto() : new SystemMenusDto 
            {
                Id = data.Id,
                Title = data.Title,
                Link = data.Link,
                Icons = data.Icons,
                ParentId = data.ParentId
            }; 

        }

        public async Task<List<SystemMenusDto>> GetMenusByTitleAsync(string title)
        {
            var data = await _dal.QueryAsync(m => m.Title.Contains(title));
            return !data.Any() ? new List<SystemMenusDto>()
                : data.Select(m => new SystemMenusDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Link = m.Link,
                    Icons = m.Icons,
                    ParentId = m.ParentId,
                    UpdateTime = m.UpdateTime
                }).ToList();
        }

        public SystemMenusDto GetMenusById(int id) 
        {
            var data = _dal.Query(id);
            return data == null ? new SystemMenusDto() : new SystemMenusDto
            {
                Id = data.Id,
                Title = data.Title,
                Link = data.Link,
                Icons = data.Icons,
                ParentId = data.ParentId
            };
        }
    }
}
