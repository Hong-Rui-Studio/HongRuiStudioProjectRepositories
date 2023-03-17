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
    public class StudentsBll : IStudentsBll
    {
        private IStudentsDal _dal = new StudentsDal();
        public async Task<int> AddStudentsAsync(string name, DateTime bornDate, int gender, string email, string phone, string pwd, string qqNum, string wechat, int classesId)
        {
            return await _dal.AddAsync(new Students
            {
                RealName= name,
                BornDate= bornDate,
                Gender=gender,
                Email=email,
                Phone=phone,
                Pwd = pwd,
                QQNumber=qqNum,
                WeChat=wechat,
                ClassesId=classesId
            });
        }

        public async Task<int> DeleteStudentsAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.RealName))
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditStudentsAsync(int id, string name, DateTime bornDate, int gender, string email, string phone, string pwd, string qqNum, string wechat, int classesId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.RealName))
                return -1;
            data.RealName = name;
            data.BornDate = bornDate;
            data.Gender = gender;
            data.Email = email;
            data.Phone = phone;
            data.QQNumber = qqNum;
            data.WeChat = wechat;
            data.ClassesId = classesId;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public List<StudentsDto> GetAllStudents()
        {
            var data = _dal.Query();
            return data.Any() ? data.Select(s => new StudentsDto 
            {
                Id = s.Id,
                RealName= s.RealName,
                BornDate = s.BornDate,
                Gender = s.Gender,
                Email = s.Email,
                Phone = s.Phone,
                Pwd = s.Pwd,
                QQNumber= s.QQNumber,
                WeChat= s.WeChat,
                ClassesId= s.ClassesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<StudentsDto>();
        }

        public async Task<List<StudentsDto>> GetAllStudentsAsync()
        {
            var data =await  _dal.QueryAsync();
            return data.Any() ? data.Select(s => new StudentsDto
            {
                Id = s.Id,
                RealName = s.RealName,
                BornDate = s.BornDate,
                Gender = s.Gender,
                Email = s.Email,
                Phone = s.Phone,
                Pwd = s.Pwd,
                QQNumber = s.QQNumber,
                WeChat = s.WeChat,
                ClassesId = s.ClassesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<StudentsDto>();
        }

        public List<StudentsDto> GetStudentsByClassesId(int classesId)
        {
            var data = _dal.Query(s => s.ClassesId == classesId);
            return data.Any() ? data.Select(s =>new StudentsDto
            {
                Id = s.Id,
                RealName = s.RealName,
                BornDate = s.BornDate,
                Gender = s.Gender,
                Email = s.Email,
                Phone = s.Phone,
                Pwd = s.Pwd,
                QQNumber = s.QQNumber,
                WeChat = s.WeChat,
                ClassesId = s.ClassesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<StudentsDto>();
        }

        public async Task<List<StudentsDto>> GetStudentsByClassesIdAsync(int classesId)
        {
            var data =await  _dal.QueryAsync(s => s.ClassesId == classesId);
            return data.Any() ? data.Select(s => new StudentsDto
            {
                Id = s.Id,
                RealName = s.RealName,
                BornDate = s.BornDate,
                Gender = s.Gender,
                Email = s.Email,
                Phone = s.Phone,
                Pwd = s.Pwd,
                QQNumber = s.QQNumber,
                WeChat = s.WeChat,
                ClassesId = s.ClassesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<StudentsDto>();
        }

        public StudentsDto GetStudentsById(int id)
        {
            var data = _dal.Query(id);
            return data == null ? new StudentsDto() : new StudentsDto 
            {
                Id = data.Id,
                RealName = data.RealName,
                BornDate = data.BornDate,
                Gender = data.Gender,
                Email = data.Email,
                Phone = data.Phone,
                Pwd = data.Pwd,
                QQNumber = data.QQNumber,
                WeChat = data.WeChat,
                ClassesId = data.ClassesId,
                UpdateTime = data.UpdateTime
            }; 
        }

        public async Task<StudentsDto> GetStudentsByIdAsync(int id)
        {
            var data =await  _dal.QueryAsync(id);
            return data == null ? new StudentsDto() : new StudentsDto
            {
                Id = data.Id,
                RealName = data.RealName,
                BornDate = data.BornDate,
                Gender = data.Gender,
                Email = data.Email,
                Phone = data.Phone,
                Pwd = data.Pwd,
                QQNumber = data.QQNumber,
                WeChat = data.WeChat,
                ClassesId = data.ClassesId,
                UpdateTime = data.UpdateTime
            };
        }

        public List<StudentsDto> GetStudentsByName(string name)
        {
            var data = _dal.Query(s => s.RealName.Contains(name));
            return data.Any() ? data.Select(s => new StudentsDto
            {
                Id = s.Id,
                RealName = s.RealName,
                BornDate = s.BornDate,
                Gender = s.Gender,
                Email = s.Email,
                Phone = s.Phone,
                Pwd = s.Pwd,
                QQNumber = s.QQNumber,
                WeChat = s.WeChat,
                ClassesId = s.ClassesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<StudentsDto>();
        }

        public async Task<List<StudentsDto>> GetStudentsByNameAsync(string name)
        {
            var data = await _dal.QueryAsync(s => s.RealName.Contains(name));
            return data.Any() ? data.Select(s => new StudentsDto
            {
                Id = s.Id,
                RealName = s.RealName,
                BornDate = s.BornDate,
                Gender = s.Gender,
                Email = s.Email,
                Phone = s.Phone,
                Pwd = s.Pwd,
                QQNumber = s.QQNumber,
                WeChat = s.WeChat,
                ClassesId = s.ClassesId,
                UpdateTime = s.UpdateTime
            }).ToList() : new List<StudentsDto>();
        }
    }
}
