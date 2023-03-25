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
            var data = _adminsRepo.Query(id);
            return data == null ? null : new AdminsDto 
            {
                Id  = data.Id,
                NickName = data.NickName,
                BornDate = data.BornDate,
                Gender = data.Gender,
                Email = data.Email,
                Tel = data.Tel,
                Photo = data.Photo,
                Images = data.Images,
                WeChat = data.WeChat,
                RolesId= data.RolesId,
                Address = data.Address,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<AdminsDto> GetAdminsByIdAsync(Guid id)
        {
            var data = await _adminsRepo.QueryAsync(id);
            return data == null ? null : new AdminsDto
            {
                Id = data.Id,
                NickName = data.NickName,
                BornDate = data.BornDate,
                Gender = data.Gender,
                Email = data.Email,
                Tel = data.Tel,
                Photo = data.Photo,
                Images = data.Images,
                WeChat = data.WeChat,
                RolesId = data.RolesId,
                Address = data.Address,
                UpdateTime = data.UpdateTime
            };
        }

        public List<AdminsDto> GetAdminsByNickName(string nickname)
        {
            var data = _adminsRepo.Query(a => a.NickName.Contains(nickname));
            return data == null || data.Count <= 0 ? new List<AdminsDto>()
                    : data.Select(a => new AdminsDto 
                    {
                        Id = a.Id,
                        NickName = a.NickName,
                        BornDate = a.BornDate,
                        Gender = a.Gender,
                        Email = a.Email,
                        Tel = a.Tel,
                        Photo = a.Photo,
                        Images = a.Images,
                        WeChat = a.WeChat,
                        RolesId = a.RolesId,
                        Address = a.Address,
                        UpdateTime = a.UpdateTime
                    }).ToList();
        }

        public async Task<List<AdminsDto>> GetAdminsByNickNameAsync(string nickname)
        {
            var data =await _adminsRepo.QueryAsync(a => a.NickName.Contains(nickname));
            return data == null || data.Count <= 0 ? new List<AdminsDto>()
                    : data.Select(a => new AdminsDto
                    {
                        Id = a.Id,
                        NickName = a.NickName,
                        BornDate = a.BornDate,
                        Gender = a.Gender,
                        Email = a.Email,
                        Tel = a.Tel,
                        Photo = a.Photo,
                        Images = a.Images,
                        WeChat = a.WeChat,
                        RolesId = a.RolesId,
                        Address = a.Address,
                        UpdateTime = a.UpdateTime
                    }).ToList();
        }

        public List<AdminsDto> GetAdminsByRolesId(Guid rolesId)
        {
            var data = _adminsRepo.Query(a => a.RolesId == rolesId);
            return data == null || data.Count <= 0 ? new List<AdminsDto>()
                    : data.Select(a => new AdminsDto
                    {
                        Id = a.Id,
                        NickName = a.NickName,
                        BornDate = a.BornDate,
                        Gender = a.Gender,
                        Email = a.Email,
                        Tel = a.Tel,
                        Photo = a.Photo,
                        Images = a.Images,
                        WeChat = a.WeChat,
                        RolesId = a.RolesId,
                        Address = a.Address,
                        UpdateTime = a.UpdateTime
                    }).ToList();
        }

        public async Task<List<AdminsDto>> GetAdminsByRolesIdAsync(Guid rolesId)
        {
            var data =await _adminsRepo.QueryAsync(a => a.RolesId == rolesId);
            return data == null || data.Count <= 0 ? new List<AdminsDto>()
                    : data.Select(a => new AdminsDto
                    {
                        Id = a.Id,
                        NickName = a.NickName,
                        BornDate = a.BornDate,
                        Gender = a.Gender,
                        Email = a.Email,
                        Tel = a.Tel,
                        Photo = a.Photo,
                        Images = a.Images,
                        WeChat = a.WeChat,
                        RolesId = a.RolesId,
                        Address = a.Address,
                        UpdateTime = a.UpdateTime
                    }).ToList();
        }

        public List<AdminsDto> GetAll()
        {
            var data = _adminsRepo.Query();
            return data == null || data.Count <= 0 ? new List<AdminsDto>()
                    : data.Select(a => new AdminsDto
                    {
                        Id = a.Id,
                        NickName = a.NickName,
                        BornDate = a.BornDate,
                        Gender = a.Gender,
                        Email = a.Email,
                        Tel = a.Tel,
                        Photo = a.Photo,
                        Images = a.Images,
                        WeChat = a.WeChat,
                        RolesId = a.RolesId,
                        Address = a.Address,
                        UpdateTime = a.UpdateTime
                    }).ToList();
        }

        public async Task<List<AdminsDto>> GetAllAdmins()
        {
            var data =await  _adminsRepo.QueryAsync();
            return data == null || data.Count <= 0 ? new List<AdminsDto>()
                    : data.Select(a => new AdminsDto
                    {
                        Id = a.Id,
                        NickName = a.NickName,
                        BornDate = a.BornDate,
                        Gender = a.Gender,
                        Email = a.Email,
                        Tel = a.Tel,
                        Photo = a.Photo,
                        Images = a.Images,
                        WeChat = a.WeChat,
                        RolesId = a.RolesId,
                        Address = a.Address,
                        UpdateTime = a.UpdateTime
                    }).ToList();
        }
    }
}
