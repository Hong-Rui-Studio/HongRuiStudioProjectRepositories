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
using System.Web;
using System.ComponentModel;

namespace HRKJ.Service
{
    public class UsersBll : IUsersBll
    {
        private IUsersDal dal = new UsersDal();

        public async Task<int> AddUsersAsync(string realName, DateTime bornDate, int gender, string email, string phone, string pwd, string qqNumber, string weChat, int rolesId,string photo,string smallPhoto)
        {
            return await dal.AddAsync(new Users 
            {
                RealName= realName,
                BornDate= bornDate,
                Gender= gender,
                Email= email,
                Phone= phone,
                Pwd= pwd,
                QQNumber= qqNumber,
                WeChat= weChat,
                RolesId= rolesId,
                Photo= photo,
                Images=smallPhoto
            });
        }

        public async Task<int> DeleteUsersAsync(int id)
        {
            var data = await dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await dal.DeleteAsync(data);
        }

        public async Task<int> EditUsersAsync(int id, string realName, DateTime bornDate, int gender, string email, string phone,string qqNumber, string weChat, int rolesId, string photo, string smallPhoto)
        {
            var data = await dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.RealName= realName;
            data.BornDate= bornDate;
            data.Gender= gender;
            data.Email= email;
            data.Phone= phone;
            data.QQNumber= qqNumber;
            data.WeChat= weChat;
            data.RolesId= rolesId;
            if(!string.IsNullOrEmpty(photo))
                data.Photo = photo;
            if(!string.IsNullOrEmpty(smallPhoto))
                data.Images= smallPhoto;
            data.UpdateTime = DateTime.Now;
            return await dal.EditAsync(data);
        }

        public async Task<int> ChangeUsersPwdAsync(int id, string newPwd) 
        {
            var data = await dal.QueryAsync(id);
            if (data == null) return -1;
            data.Pwd = newPwd;
            data.UpdateTime = DateTime.Now;
            return await dal.EditAsync(data);
        }


        public async Task<List<UsersDto>> GetAllUsersAsync()
        {
            var data = await dal.QueryAsync();
            return data.Select(u => new UsersDto 
            {
                Id = u.Id,
                RealName=u.RealName,
                BornDate=u.BornDate,
                Gender=u.Gender,
                Email=u.Email,
                Phone=u.Phone,
                QQNumber=u.QQNumber,
                WeChat=u.WeChat,
                Photo=u.Photo,
                Images=u.Images,
                RolesId=u.RolesId,
                UpdateTime=u.UpdateTime
            }).ToList();
        }

        public async Task<UsersDto> GetUsersByIdAsync(int Id)
        {
            var data = await dal.QueryAsync(Id);
            return data == null ? null : new UsersDto
            {
                Id = data.Id,
                RealName = data.RealName,
                BornDate = data.BornDate,
                Gender = data.Gender,
                Email = data.Email,
                Phone = data.Phone,
                QQNumber = data.QQNumber,
                WeChat = data.WeChat,
                Photo = data.Photo,
                Images = data.Images,
                RolesId = data.RolesId,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<List<UsersDto>> GetUsersByRolesIdAsync(int rolesId)
        {
            var data = await dal.QueryAsync(u => u.RolesId == rolesId);
            return data.Select(u =>new UsersDto
            {
                Id = u.Id,
                RealName = u.RealName,
                BornDate = u.BornDate,
                Gender = u.Gender,
                Email = u.Email,
                Phone = u.Phone,
                QQNumber = u.QQNumber,
                WeChat = u.WeChat,
                Photo = u.Photo,
                Images = u.Images,
                RolesId = u.RolesId,
                UpdateTime = u.UpdateTime
            }).ToList();
        }

        public async Task<List<UsersDto>> GetUsersByTitleAsync(string title)
        {
            var data = await dal.QueryAsync(u => u.RealName.Contains(title)) ;
            return data.Select(u => new UsersDto
            {
                Id = u.Id,
                RealName = u.RealName,
                BornDate = u.BornDate,
                Gender = u.Gender,
                Email = u.Email,
                Phone = u.Phone,
                QQNumber = u.QQNumber,
                WeChat = u.WeChat,
                Photo = u.Photo,
                Images = u.Images,
                RolesId = u.RolesId,
                UpdateTime = u.UpdateTime
            }).ToList();
        }


        public async Task<UsersDto> LoginAsync(string email, string pwd) 
        {
            var data = await dal.QueryAsync(u => u.Email.Equals(email) && u.Pwd.Equals(pwd));
            return data.Any() ? new UsersDto 
            {
                Id = data[0].Id,
                Email = data[0].Email,
                Pwd = data[0].Pwd,
                RealName = data[0].RealName,
                BornDate= data[0].BornDate,
                Gender = data[0].Gender,
                Phone= data[0].Phone,
                Photo = data[0].Photo,
                QQNumber = data[0].QQNumber,
                WeChat = data[0].WeChat,
                RolesId= data[0].RolesId,
                Images= data[0].Images,
                UpdateTime= data[0].UpdateTime
            
            } : null;
        }
    }
}
