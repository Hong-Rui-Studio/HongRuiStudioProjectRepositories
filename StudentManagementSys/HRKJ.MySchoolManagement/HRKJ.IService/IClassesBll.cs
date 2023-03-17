using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IClassesBll
    {
        Task<int> AddClassesAsync(string title, int gradesId);

        Task<int> EditClassesAsync(int id, string title, int gradesId);

        Task<int> DeleteClassesAsync(int id);

        Task<List<ClassesDto>> GetAllClassesAsync();

        List<ClassesDto> GetAllClasses();

        Task<List<ClassesDto>> GetClassesByTitleAsync(string title);

        List<ClassesDto> GetClassesByTitle(string title);

        Task<List<ClassesDto>> GetClassesByGradesIdAsync(int gradesId);

        List<ClassesDto> GetClassesByGradesId(int gradesId);

        Task<ClassesDto> GetClassesByIdAsync(int id);

        ClassesDto GetClassById(int id);
    }
}
