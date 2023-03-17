using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IStudentsBll
    {
        Task<int> AddStudentsAsync(string name, DateTime bornDate, int gender, string email, string phone, string pwd, string qqNum, string wechat, int classesId);

        Task<int> EditStudentsAsync(int id, string name, DateTime bornDate, int gender, string email, string phone, string pwd, string qqNum, string wechat, int classesId);

        Task<int> DeleteStudentsAsync(int id);

        Task<List<StudentsDto>> GetAllStudentsAsync();

        List<StudentsDto> GetAllStudents();

        Task<List<StudentsDto>> GetStudentsByNameAsync(string name);

        List<StudentsDto> GetStudentsByName(string name);

        StudentsDto GetStudentsById(int id);

        Task<StudentsDto> GetStudentsByIdAsync(int id);

        Task<List<StudentsDto>> GetStudentsByClassesIdAsync(int classesId);

        List<StudentsDto> GetStudentsByClassesId(int classesId);
    }
}

