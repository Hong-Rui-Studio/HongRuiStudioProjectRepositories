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
    public class SubjectsBll : ISubjectsBll
    {
        private ISubjectsDal _dal = new SubjectsDal();
        public async Task<int> AddSubjectsAsync(string title, int gradesId)
        {
            return await _dal.AddAsync(new Subjects 
            {
                Title= title,
                GradesId= gradesId
            });
        }

        public async Task<int> DeleteSubjectsAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditSubjectsAsync(int id, string title, int gradesId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            data.Title = title;
            data.GradesId= gradesId;
            data.UpdateTime= DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<SubjectsDto> GetAllSubjects()
        {
            var data = _dal.Query();
            return data.Any() ? data.Select(s => new SubjectsDto
            {
                Id = s.Id,
                Title = s.Title,
                GradesId = s.GradesId,
                UpdateTime= s.UpdateTime
            }).ToList() : new List<SubjectsDto>();
        }

        public async Task<List<SubjectsDto>> GetAllSubjectsAsync()
        {
            var data = await  _dal.QueryAsync();
            return data.Any() ? data.Select(s => new SubjectsDto
            {
                Id = s.Id,
                Title = s.Title,
                GradesId = s.GradesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SubjectsDto>();
        }

        public List<SubjectsDto> GetSubjectsByGradesId(int gradesId)
        {
            var data = _dal.Query(s => s.GradesId == gradesId);
            return data.Any() ? data.Select(s => new SubjectsDto
            {
                Id = s.Id,
                Title = s.Title,
                GradesId = s.GradesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SubjectsDto>();
        }

        public async Task<List<SubjectsDto>> GetSubjectsByGradesIdAsync(int gradesId)
        {
            var data = await _dal.QueryAsync(s => s.GradesId == gradesId);
            return data.Any() ? data.Select(s => new SubjectsDto
            {
                Id = s.Id,
                Title = s.Title,
                GradesId = s.GradesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SubjectsDto>();
        }

        public SubjectsDto GetSubjectsById(int id)
        {
            var data = _dal.Query(id);
            return data == null || string.IsNullOrEmpty(data.Title) ? new SubjectsDto() : new SubjectsDto 
            {
                Id = data.Id,
                Title = data.Title,
                GradesId = data.GradesId,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<SubjectsDto> GetSubjectsByIdAsync(int id)
        {
            var data = await  _dal.QueryAsync(id);
            return data == null || string.IsNullOrEmpty(data.Title) ? new SubjectsDto() : new SubjectsDto
            {
                Id = data.Id,
                Title = data.Title,
                GradesId = data.GradesId,
                UpdateTime = data.UpdateTime
            };
        }

        public List<SubjectsDto> GetSubjectsByTitle(string title)
        {
            var data = _dal.Query(s => s.Title.Contains(title));
            return data.Any() ? data.Select(s => new SubjectsDto
            {
                Id = s.Id,
                Title = s.Title,
                GradesId = s.GradesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SubjectsDto>();
        }

        public async Task<List<SubjectsDto>> GetSubjectsByTitleAsync(string title)
        {
            var data = await _dal.QueryAsync(s => s.Title.Contains(title));
            return data.Any() ? data.Select(s => new SubjectsDto
            {
                Id = s.Id,
                Title = s.Title,
                GradesId = s.GradesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<SubjectsDto>();
        }
    }
}
