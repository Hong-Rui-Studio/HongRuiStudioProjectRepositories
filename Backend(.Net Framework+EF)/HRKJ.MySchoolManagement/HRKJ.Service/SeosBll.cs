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
    public class SeosBll : ISeosBll
    {
        private ISeosDal dal = new SeosDal();

        public async Task<int> AddSeosAsync(string title, string keyword, string description, int menusId)
        {
            return await dal.AddAsync(new Seos
            {
                Title= title,
                Keyword= keyword,
                Description= description,
                MenusId= menusId
            });
        }

        public async Task<int> DeleteSeosAsync(int id)
        {
            var data = await dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            return await dal.DeleteAsync(data);
        }

        public async Task<int> EditSeosAsync(int id, string title, string keyword, string description, int menusId)
        {
            var data = await dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;

            data.Title = title;
            data.Keyword= keyword;
            data.Description = description;
            data.MenusId= menusId;
            data.UpdateTime = DateTime.Now;
            return await dal.EditAsync(data);
        }

        public List<SeosDto> GetAllSeos()
        {
            var data = dal.Query();
            return data.Any() ? data.Select(s => new SeosDto 
            {
                Id = s.Id,
                Title = s.Title,
                Keyword= s.Keyword,
                Description = s.Description,
                MenusId= s.MenusId,
                UpdateTime= s.UpdateTime
            }).ToList() : new List<SeosDto>();
        }

        public async Task<List<SeosDto>> GetAllSeosAsync()
        {
            var data = await dal.QueryAsync();
            return data.Any() ? data.Select(s => new SeosDto
            {
                Id = s.Id,
                Title = s.Title,
                Keyword = s.Keyword,
                Description = s.Description,
                MenusId = s.MenusId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SeosDto>();
        }

        public SeosDto GetSeosById(int id)
        {
            var data = dal.Query(id);
            return data == null ? new SeosDto() : new SeosDto 
            {
                Id = data.Id,
                Title = data.Title,
                Keyword = data.Keyword,
                Description = data.Description,
                MenusId = data.MenusId,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<SeosDto> GetSeosByIdASync(int id)
        {
            var data =await  dal.QueryAsync(id);
            return data == null ? new SeosDto() : new SeosDto
            {
                Id = data.Id,
                Title = data.Title,
                Keyword = data.Keyword,
                Description = data.Description,
                MenusId = data.MenusId,
                UpdateTime = data.UpdateTime
            };
        }

        public SeosDto GetSeosByMenusId(int menusId)
        {
            var data = dal.Query(s => s.MenusId == menusId);

            return data.Any() ? data.Select(s => new SeosDto
            {
                Id = s.Id,
                Title = s.Title,
                Keyword = s.Keyword,
                Description = s.Description,
                MenusId = s.MenusId,
                UpdateTime = s.UpdateTime
            }).First() : new SeosDto();
        }

        public async Task<SeosDto> GetSeosByMenusIdAsync(int menusId)
        {
            var data =await dal.QueryAsync(s => s.MenusId == menusId);

            return data.Any() ? data.Select(s => new SeosDto
            {
                Id = s.Id,
                Title = s.Title,
                Keyword = s.Keyword,
                Description = s.Description,
                MenusId = s.MenusId,
                UpdateTime = s.UpdateTime
            }).First() : new SeosDto();
        }

        public List<SeosDto> GetSeosByTitle(string title)
        {
            var data = dal.Query(s => s.Title.Contains(title));
            return data.Any() ? data.Select(s => new SeosDto 
            {
                Id = s.Id,
                Title = s.Title,
                Keyword = s.Keyword,
                Description = s.Description,
                MenusId = s.MenusId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SeosDto>();
        }

        public async Task<List<SeosDto>> GetSeosByTitleAsync(string title)
        {
            var data =await dal.QueryAsync(s => s.Title.Contains(title));
            return data.Any() ? data.Select(s => new SeosDto
            {
                Id = s.Id,
                Title = s.Title,
                Keyword = s.Keyword,
                Description = s.Description,
                MenusId = s.MenusId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SeosDto>();
        }
    }
}
