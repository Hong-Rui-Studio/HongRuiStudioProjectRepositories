using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IExamInfosBll
    {
        Task<int> AddExamInfosAsync(string title,DateTime examTime,string subjectsId);
        Task<int> EditExamInfosAsync(int id,string title, DateTime examTime, string subjectsId);
        Task<int> DeleteExamInfosAsync(int id);

        Task<List<ExamInfosDto>> GetAllExamInfosAsync();
        List<ExamInfosDto> GetAllExamInfos();

        Task<List<ExamInfosDto>> GetExamInfosByTitleAsync(string title);
        List<ExamInfosDto> GetExamInfosByTitle(string title);

        Task<ExamInfosDto> GetExamInfosByIdAsync(int id);

        ExamInfosDto GetExamInfosById(int id);

    }
}
