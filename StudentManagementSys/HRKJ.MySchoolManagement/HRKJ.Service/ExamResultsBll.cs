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
    public class ExamResultsBll : IExamResultsBll
    {
        private IExamResultsDal _dal = new ExamResultsDal();

        public async Task<int> AddExamResultsAsync(int examId, int studentId, decimal scores)
        {
            return await _dal.AddAsync(new ExamResults 
            {
                ExamId= examId,
                StudentId= studentId,
                Scores= scores
            });
        }

        public async Task<int> DeleteExamResultsAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;

            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditExamResultsAsync(int id, int examId, int studentId, decimal scores)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.ExamId= examId;
            data.StudentId= studentId;
            data.Scores= scores;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<ExamResultsDto> GetAllExamResults()
        {
            var data = _dal.Query();
            return data.Any() ? data.Select(e => new ExamResultsDto 
            {
                Id = e.ExamId,
                StudentId= e.StudentId,
                Scores= e.Scores,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamResultsDto>();
        }

        public async Task<List<ExamResultsDto>> GetAllExamResultsAsync()
        {
            var data =await _dal.QueryAsync();
            return data.Any() ? data.Select(e => new ExamResultsDto
            {
                Id = e.ExamId,
                StudentId = e.StudentId,
                Scores = e.Scores,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamResultsDto>();
        }

        public List<ExamResultsDto> GetExamResultsByExamId(int examId)
        {
            var data = _dal.Query(e => e.ExamId == examId);
            return data.Any() ? data.Select(e => new ExamResultsDto
            {
                Id = e.ExamId,
                StudentId = e.StudentId,
                Scores = e.Scores,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamResultsDto>();
        }

        public async Task<List<ExamResultsDto>> GetExamResultsByExamIdAsync(int examId)
        {
            var data = await _dal.QueryAsync(e => e.ExamId == examId);
            return data.Any() ? data.Select(e => new ExamResultsDto
            {
                Id = e.ExamId,
                StudentId = e.StudentId,
                Scores = e.Scores,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamResultsDto>();
        }

        public ExamResultsDto GetExamResultsById(int id)
        {
            var data = _dal.Query(id);
            return data == null ? new ExamResultsDto() : new ExamResultsDto 
            {
                Id = data.Id,
                ExamsId = data.ExamId,
                StudentId = data.StudentId,
                Scores = data.Scores,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<ExamResultsDto> GetExamResultsByIdAsync(int id)
        {
            var data =await  _dal.QueryAsync(id);
            return data == null ? new ExamResultsDto() : new ExamResultsDto
            {
                Id = data.Id,
                ExamsId = data.ExamId,
                StudentId = data.StudentId,
                Scores = data.Scores,
                UpdateTime = data.UpdateTime
            };
        }

        public List<ExamResultsDto> GetExamResultsByStudentId(int studentId)
        {
            var data = _dal.Query(e => e.StudentId == studentId);
            return data.Any() ? data.Select(e => new ExamResultsDto
            {
                Id = e.ExamId,
                StudentId = e.StudentId,
                Scores = e.Scores,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamResultsDto>();
        }

        public async Task<List<ExamResultsDto>> GetExamResultsByStudentIdAsync(int studentId)
        {
            var data =await _dal.QueryAsync(e => e.StudentId == studentId);
            return data.Any() ? data.Select(e => new ExamResultsDto
            {
                Id = e.ExamId,
                StudentId = e.StudentId,
                Scores = e.Scores,
                UpdateTime = e.UpdateTime
            }).ToList() : new List<ExamResultsDto>();
        }
    }
}
