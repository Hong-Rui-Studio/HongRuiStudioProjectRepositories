using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IGradesBll
    {
        Task<int> AddGradesAsync(string title);
        Task<int> EditGradesAsync(int id,string title);
        Task<int> DeleteGradesAsync(int id);


        Task<List<GradesDto>> GetAllGradesAsync();
        List<GradesDto> GetAllGrades();

        Task<List<GradesDto>> GetGradesByTitleAsync(string title);
        List<GradesDto> GetGradesByTitle(string title);

        Task<GradesDto> GetGradesByIdAsync(int id);
        GradesDto GetGradesById(int id);
    }
}
