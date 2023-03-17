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
    public class GradesBll : IGradesBll
    {
        private IGradesDal _dal = new GradesDal();

        public async Task<int> AddGradesAsync(string title)
        {
            return await _dal.AddAsync(new Grades
            {
                Title= title
            });
        }

        public async Task<int> DeleteGradesAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditGradesAsync(int id, string title)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Title = title;
            data.UpdateTime= DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<GradesDto> GetAllGrades()
        {
            var data = _dal.Query();
            return data.Any() ? data.Select(g => new GradesDto 
            {
                Id = g.Id,
                Title = g.Title,
                UpdateTime = g.UpdateTime
            }).ToList() : new List<GradesDto>(); 
        }

        public async Task<List<GradesDto>> GetAllGradesAsync()
        {
            var data = await _dal.QueryAsync();
            return data.Any() ? data.Select(g => new GradesDto
            {
                Id = g.Id,
                Title = g.Title,
                UpdateTime = g.UpdateTime
            }).ToList() : new List<GradesDto>();
        }

        public GradesDto GetGradesById(int id)
        {
            var data= _dal.Query(id);
            return data == null ? new GradesDto() : new GradesDto 
            {
                Id = data.Id, 
                Title = data.Title,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<GradesDto> GetGradesByIdAsync(int id)
        {
            var data = await  _dal.QueryAsync(id);
            return data == null ? new GradesDto() : new GradesDto
            {
                Id = data.Id,
                Title = data.Title,
                UpdateTime = data.UpdateTime
            };
        }

        public List<GradesDto> GetGradesByTitle(string title)
        {
            var data = _dal.Query(g => g.Title.Contains(title));
            return data.Any() ? data.Select(g => new GradesDto
            {
                Id = g.Id,
                Title = g.Title,
                UpdateTime = g.UpdateTime
            }).ToList() : new List<GradesDto>();
        }

        public async Task<List<GradesDto>> GetGradesByTitleAsync(string title)
        {
            var data = await  _dal.QueryAsync(g => g.Title.Contains(title));
            return data.Any() ? data.Select(g => new GradesDto
            {
                Id = g.Id,
                Title = g.Title,
                UpdateTime = g.UpdateTime
            }).ToList() : new List<GradesDto>();
        }
    }
}
