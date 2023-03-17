using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IWebMenusBll
    {
        Task<int> AddWebMenusAsync(string title, string link, string icon, int parentId);
        Task<int> EditWebMenusAsync(int id,string title, string link, string icon, int parentId);
        Task<int> DeleteWebMenusAsync(int id);

        Task<List<WebMenusDto>> GetAllMenusAsync();
        Task<List<WebMenusDto>> GetMenusByTitleAsync(string title);
        Task<WebMenusDto> GetMenusByIdAsync(int id);
        Task<List<WebMenusDto>> GetMenusByParentIdAsync(int parentId);

        List<WebMenusDto> GetAllMenus();
        List<WebMenusDto> GetMenusByTitle(string title);
        WebMenusDto GetMenusById(int id);
        List<WebMenusDto> GetMenusByParentId(int parentId);
    }
}
