using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IExamResultsBll
    {
        Task<int> AddExamResultsAsync(int examId, int studentId, decimal scores);

        Task<int> EditExamResultsAsync(int id, int examId, int studentId, decimal scores);

        Task<int> DeleteExamResultsAsync(int id);

        List<ExamResultsDto> GetAllExamResults();
        Task<List<ExamResultsDto>> GetAllExamResultsAsync();

        List<ExamResultsDto> GetExamResultsByStudentId(int studentId);
        Task<List<ExamResultsDto>> GetExamResultsByStudentIdAsync(int studentId);

        List<ExamResultsDto> GetExamResultsByExamId(int examId);
        Task<List<ExamResultsDto>> GetExamResultsByExamIdAsync(int examId);

        ExamResultsDto GetExamResultsById(int id);

        Task<ExamResultsDto> GetExamResultsByIdAsync(int id);
    }
}
