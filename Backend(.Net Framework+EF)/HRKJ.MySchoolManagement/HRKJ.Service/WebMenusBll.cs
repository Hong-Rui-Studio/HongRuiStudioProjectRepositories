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
    public class WebMenusBll : IWebMenusBll
    {
        private IWebMenusDal dal = new WebMenusDal();
        public async Task<int> AddWebMenusAsync(string title, string link, string icon, int parentId)
        {
            return await dal.AddAsync(new WebMenus 
            {
                Title = title,
                Link = link,
                Icons= icon,
                ParentId = parentId
            });
        }

        public async Task<int> DeleteWebMenusAsync(int id)
        {
            var data = await dal.QueryAsync(id);

            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            return await dal.DeleteAsync(data);

        }

        public async Task<int> EditWebMenusAsync(int id, string title, string link, string icon, int parentId)
        {
            var data = await dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            data.Title = title;
            data.Link= link;
            data.Icons= icon;
            data.ParentId = parentId;
            data.UpdateTime= DateTime.Now;
            return await dal.EditAsync(data);
        }

        public  List<WebMenusDto> GetAllMenus()
        {
            var data =  dal.Query();
            return data.Any() ? data.Select(w => new WebMenusDto 
            {
                Id = w.Id,
                Title = w.Title,
                Link = w.Link,
                Icons= w.Icons,
                ParentId = w.ParentId,
                UpdateTime= w.UpdateTime
            }).ToList() : new List<WebMenusDto>();
        }

        public async  Task<List<WebMenusDto>> GetAllMenusAsync()
        {
            var data =await  dal.QueryAsync();
            return data.Any() ? data.Select(w => new WebMenusDto
            {
                Id = w.Id,
                Title = w.Title,
                Link = w.Link,
                Icons = w.Icons,
                ParentId = w.ParentId,
                UpdateTime = w.UpdateTime
            }).ToList() : new List<WebMenusDto>();
        }

        public WebMenusDto GetMenusById(int id)
        {
            var data = dal.Query(id);
            return data == null ? new WebMenusDto() : new WebMenusDto
            { 
                Id = data.Id,
                Title = data.Title,
                Link= data.Link,
                Icons = data.Icons,
                ParentId = data.ParentId,
                UpdateTime= data.UpdateTime
            };
        }

        public async Task<WebMenusDto> GetMenusByIdAsync(int id)
        {
            var data =await dal.QueryAsync(id);
            return data == null ? new WebMenusDto() : new WebMenusDto
            {
                Id = data.Id,
                Title = data.Title,
                Link = data.Link,
                Icons = data.Icons,
                ParentId = data.ParentId,
                UpdateTime = data.UpdateTime
            };
        }

        public List<WebMenusDto> GetMenusByParentId(int parentId)
        {
            var data = dal.Query(w => w.ParentId == parentId);
            return data.Any() ? data.Select(w => new WebMenusDto
            {
                Id = w.Id,
                Title = w.Title,
                Link = w.Link,
                Icons = w.Icons,
                ParentId = w.ParentId,
                UpdateTime = w.UpdateTime
            }).ToList() : new List<WebMenusDto>();   
        }

        public async Task<List<WebMenusDto>> GetMenusByParentIdAsync(int parentId)
        {
            var data = await  dal.QueryAsync(w => w.ParentId == parentId);
            return data.Any() ? data.Select(w => new WebMenusDto
            {
                Id = w.Id,
                Title = w.Title,
                Link = w.Link,
                Icons = w.Icons,
                ParentId = w.ParentId,
                UpdateTime = w.UpdateTime
            }).ToList() : new List<WebMenusDto>();
        }

        public List<WebMenusDto> GetMenusByTitle(string title)
        {
            var data = dal.Query(w => w.Title.Contains(title));
            return data.Any() ? data.Select(w => new WebMenusDto
            {
                Id = w.Id,
                Title = w.Title,
                Link = w.Link,
                Icons = w.Icons,
                ParentId = w.ParentId,
                UpdateTime = w.UpdateTime
            }).ToList() : new List<WebMenusDto>();
        }

        public async Task<List<WebMenusDto>> GetMenusByTitleAsync(string title)
        {
            var data =await  dal.QueryAsync(w => w.Title.Contains(title));
            return data.Any() ? data.Select(w => new WebMenusDto
            {
                Id = w.Id,
                Title = w.Title,
                Link = w.Link,
                Icons = w.Icons,
                ParentId = w.ParentId,
                UpdateTime = w.UpdateTime
            }).ToList() : new List<WebMenusDto>();
        }
    }
}
