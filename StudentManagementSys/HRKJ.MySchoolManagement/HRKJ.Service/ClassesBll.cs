using HRKJ.Dtos;
using HRKJ.IRepository;
using HRKJ.IService;
using HRKJ.Repository;
using HRKJ.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Service
{
    public class ClassesBll : IClassesBll
    {
        private IClassesDal _dal = new ClassesDal();

        public async Task<int> AddClassesAsync(string title, int gradesId)
        {
            return await _dal.AddAsync(new Classes 
            {
                Title = title,
                GradesId = gradesId
            });
        }

        public async Task<int> DeleteClassesAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditClassesAsync(int id, string title, int gradesId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Title = title;
            data.GradesId= gradesId;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<ClassesDto> GetAllClasses()
        {
            var data = _dal.Query();
            return data.Any() ? data.Select(c => new ClassesDto 
            {
                Id = c.Id,
                Title = c.Title,
                GradesId= c.GradesId,
                UpdateTime = c.UpdateTime

            }).ToList() : new List<ClassesDto>();
        }

        public async Task<List<ClassesDto>> GetAllClassesAsync()
        {
            var data = await _dal.QueryAsync();
            return data.Any() ? data.Select(c => new ClassesDto
            {
                Id = c.Id,
                Title = c.Title,
                GradesId = c.GradesId,
                UpdateTime = c.UpdateTime

            }).ToList() : new List<ClassesDto>();
        }

        public ClassesDto GetClassById(int id)
        {
            var data = _dal.Query(id);
            return data == null ? new ClassesDto() : new ClassesDto 
            {
                Id = data.Id,
                Title = data.Title,
                GradesId = data.GradesId,
                UpdateTime = data.UpdateTime
            };
        }

        public List<ClassesDto> GetClassesByGradesId(int gradesId)
        {
            var data = _dal.Query(c => c.GradesId == gradesId);
            return data.Any() ? data.Select(c => new ClassesDto
            {
                Id = c.Id,
                Title = c.Title,
                GradesId = c.GradesId,
                UpdateTime = c.UpdateTime

            }).ToList() : new List<ClassesDto>();
        }

        public async Task<List<ClassesDto>> GetClassesByGradesIdAsync(int gradesId)
        {
            var data = await _dal.QueryAsync(c => c.GradesId == gradesId);
            return data.Any() ? data.Select(c => new ClassesDto
            {
                Id = c.Id,
                Title = c.Title,
                GradesId = c.GradesId,
                UpdateTime = c.UpdateTime

            }).ToList() : new List<ClassesDto>();
        }

        public async Task<ClassesDto> GetClassesByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? new ClassesDto() : new ClassesDto
            {
                Id = data.Id,
                Title = data.Title,
                GradesId = data.GradesId,
                UpdateTime = data.UpdateTime
            };
        }

        public List<ClassesDto> GetClassesByTitle(string title)
        {
            var data = _dal.Query(c => c.Title.Contains(title));
            return data.Any() ? data.Select(c => new ClassesDto
            {
                Id = c.Id,
                Title = c.Title,
                GradesId = c.GradesId,
                UpdateTime = c.UpdateTime

            }).ToList() : new List<ClassesDto>();
        }

        public async Task<List<ClassesDto>> GetClassesByTitleAsync(string title)
        {
            var data =await _dal.QueryAsync(c => c.Title.Contains(title));
            return data.Any() ? data.Select(c => new ClassesDto
            {
                Id = c.Id,
                Title = c.Title,
                GradesId = c.GradesId,
                UpdateTime = c.UpdateTime

            }).ToList() : new List<ClassesDto>();
        }
    }
}
