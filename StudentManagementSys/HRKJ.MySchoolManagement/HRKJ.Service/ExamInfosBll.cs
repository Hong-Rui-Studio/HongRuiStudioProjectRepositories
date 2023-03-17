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
    public class ExamInfosBll : IExamInfosBll
    {
        private IExamInfosDal _dal = new ExamInfosDal();
        public async Task<int> AddExamInfosAsync(string title, DateTime examTime, string subjectsId)
        {
            return await _dal.AddAsync(new ExamInfos
            {
                Title= title,
                ExamDate= examTime,
                SubjectsId= subjectsId
            });
        }

        public async Task<int> DeleteExamInfosAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditExamInfosAsync(int id, string title, DateTime examTime, string subjectsId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            data.Title = title;
            data.ExamDate = examTime;
            data.SubjectsId = subjectsId;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<ExamInfosDto> GetAllExamInfos()
        {
            var data = _dal.Query();
            return data.Any() ? data.Select(e => new ExamInfosDto
            {
                Id = e.Id,
                Title = e.Title,
                ExamDate = e.ExamDate,
                SubjectsId = e.SubjectsId,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamInfosDto>();
        }

        public async Task<List<ExamInfosDto>> GetAllExamInfosAsync()
        {
            var data =await _dal.QueryAsync();
            return data.Any() ? data.Select(e => new ExamInfosDto
            {
                Id = e.Id,
                Title = e.Title,
                ExamDate = e.ExamDate,
                SubjectsId = e.SubjectsId,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamInfosDto>();
        }

        public ExamInfosDto GetExamInfosById(int id)
        {
            var data = _dal.Query(id);
            return data == null || string.IsNullOrEmpty(data.Title) ? new ExamInfosDto() : new ExamInfosDto 
            {
                Id = data.Id,
                Title = data.Title,
                ExamDate = data.ExamDate,
                SubjectsId = data.SubjectsId,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<ExamInfosDto> GetExamInfosByIdAsync(int id)
        {
            var data =await _dal.QueryAsync(id);
            return data == null || string.IsNullOrEmpty(data.Title) ? new ExamInfosDto() : new ExamInfosDto
            {
                Id = data.Id,
                Title = data.Title,
                ExamDate = data.ExamDate,
                SubjectsId = data.SubjectsId,
                UpdateTime = data.UpdateTime
            };
        }

        public List<ExamInfosDto> GetExamInfosByTitle(string title)
        {
            var data = _dal.Query(e => e.Title.Contains(title));
            return data.Any() ? data.Select(e => new ExamInfosDto
            {
                Id = e.Id,
                Title = e.Title,
                ExamDate = e.ExamDate,
                SubjectsId = e.SubjectsId,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamInfosDto>();
        }

        public async Task<List<ExamInfosDto>> GetExamInfosByTitleAsync(string title)
        {
            var data =await _dal.QueryAsync(e => e.Title.Contains(title));
            return data.Any() ? data.Select(e => new ExamInfosDto
            {
                Id = e.Id,
                Title = e.Title,
                ExamDate = e.ExamDate,
                SubjectsId = e.SubjectsId,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamInfosDto>();
        }
    }
}
