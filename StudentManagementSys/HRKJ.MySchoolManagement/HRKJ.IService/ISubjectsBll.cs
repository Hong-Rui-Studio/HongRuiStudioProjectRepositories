using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface ISubjectsBll
    {
        Task<int> AddSubjectsAsync(string title, int gradesId);
        Task<int> EditSubjectsAsync(int id, string title, int gradesId);
        Task<int> DeleteSubjectsAsync(int id);
        Task<List<SubjectsDto>> GetAllSubjectsAsync();
        List<SubjectsDto> GetAllSubjects();

        Task<List<SubjectsDto>> GetSubjectsByTitleAsync(string title);
        List<SubjectsDto> GetSubjectsByTitle(string title);

        Task<List<SubjectsDto>> GetSubjectsByGradesIdAsync(int gradesId);
        List<SubjectsDto> GetSubjectsByGradesId(int gradesId);

        Task<SubjectsDto> GetSubjectsByIdAsync(int id);
        SubjectsDto GetSubjectsById(int id);

    }
}
