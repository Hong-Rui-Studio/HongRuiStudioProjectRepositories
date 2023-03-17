using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface ISystemMenusBll
    {

        Task<int> AddMenusAsync(string title,string link ,string icons,int parentId=0);
        Task<int> EditMenusAsync(int id,string title, string link, string icons, int parentId = 0);
        Task<int> DeleteMenusAsync(int id);

        Task<List<SystemMenusDto>> GetAllMenusAsync();

        Task<List<SystemMenusDto>> GetAllMenusByParentIdAsync(int parentId);

        Task<List<SystemMenusDto>> GetMenusByTitleAsync(string title);

        Task<SystemMenusDto> GetMenusByIdAsync(int id);

        SystemMenusDto GetMenusById(int id);
    }
}
