using HRGS.Dtos;
using HRGS.IRepositories;
using HRGS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRGS.Entities;
namespace HRGS.Services
{
    public class AdminsService : IAdminsService
    {
        private IAdminsRepository _adminsRepo;
        public AdminsService(IAdminsRepository adminsRepo)
        {
            _adminsRepo = adminsRepo;
        }
        public async Task<int> AddAdminsAsync(string nickname, DateTime bornDate, int gender, string email, string tel, string pwd, string photo, string images, string address, string wechat, Guid rolesId)
        {
            return await _adminsRepo.AddAsync(new Admins 
            {
                NickName = nickname,
                BornDate = bornDate,
                Gender = gender,
                Email = email,
                Tel = tel,
                Pwd = pwd,
                Photo = photo,
                Images = images,
                Address = address,
                WeChat = wechat,
                RolesId = rolesId
            });
        }

        public async Task<int> DeleteAdminsAsync(Guid id)
        {
            var data = await _adminsRepo.QueryAsync(id);
            if (data == null)
                return -1;
            return await _adminsRepo.DeleteAsync(data);
        }

        public async Task<int> EditAdminsAsync(Guid id, string nickname, DateTime bornDate, int gender, string email, string tel, string photo, string images, string address, string wechat, Guid rolesId)
        {
            var data = await _adminsRepo.QueryAsync(id);
            if (data == null)
                return -1;
            data.NickName = nickname;
            data.BornDate = bornDate;
            data.Gender = gender;
            data.Email = email;
            data.Tel = tel;
            if(!string.IsNullOrEmpty(photo))
                data.Photo = photo;
            if(!string.IsNullOrEmpty(images))
                data.Images = images;
            data.WeChat = wechat;
            data.RolesId = rolesId; 
            data.Address = address;
            data.UpdateTime = DateTime.Now;
            return await _adminsRepo.EditAsync(data);
        }

        public AdminsDto GetAdminsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AdminsDto> GetAdminsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<AdminsDto> GetAdminsByNickName(string nickname)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdminsDto>> GetAdminsByNickNameAsync(string nickname)
        {
            throw new NotImplementedException();
        }

        public List<AdminsDto> GetAdminsByRolesId(Guid rolesId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdminsDto>> GetAdminsByRolesIdAsync(Guid rolesId)
        {
            throw new NotImplementedException();
        }

        public List<AdminsDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<AdminsDto>> GetAllAdmins()
        {
            throw new NotImplementedException();
        }
    }
}
