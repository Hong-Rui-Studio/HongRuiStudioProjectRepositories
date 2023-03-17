using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IUsersBll
    {
        Task<int> AddUsersAsync(string realName, DateTime bornDate, int gender, string email, string phone, string pwd, string qqNumber, string weChat, int rolesId, string photo, string smallPhoto);
        Task<int> EditUsersAsync(int id, string realName, DateTime bornDate, int gender, string email, string phone,  string qqNumber, string weChat, int rolesId, string photo, string smallPhoto);
        Task<int> DeleteUsersAsync(int id);
        Task<int> ChangeUsersPwdAsync(int id, string newPwd);
        Task<List<UsersDto>> GetAllUsersAsync();
        Task<List<UsersDto>> GetUsersByRolesIdAsync(int rolesId);
        Task<List<UsersDto>> GetUsersByTitleAsync(string title);
        Task<UsersDto> GetUsersByIdAsync(int Id);

        //List<UsersDto> GetAllUsers();
        // List<UsersDto> GetUsersByRolesId(int rolesId);
        // List<UsersDto> GetUsersByTitle(string title);
        // UsersDto GetUsersById(int Id);

        Task<UsersDto> LoginAsync(string email, string pwd);

    }
}
