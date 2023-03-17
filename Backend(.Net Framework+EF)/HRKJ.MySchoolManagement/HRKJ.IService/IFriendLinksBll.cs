using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface IFriendLinksBll
    {
        Task<int> AddFriendLinksAsync(string title, string link, int isShow); 
        Task<int> EditFriendLinksAsync(int id,string title, string link, int isShow);
        Task<int> DeleteFriendLinksAsync(int id);

        Task<List<FriendLinksDto>> GetAllFriendLinksAsync();
        Task<List<FriendLinksDto>> GetFriendLinksByTitleAsync(string title);
        Task<FriendLinksDto> GetFriendLinksByIdAsync(int id);
        Task<List<FriendLinksDto>> GetFriendLinksByIsShowAsync(int isShow);

        List<FriendLinksDto> GetAllFriendLinks();
        List<FriendLinksDto> GetFriendLinksByTitle(string title);
        FriendLinksDto GetFriendLinksById(int id);
        List<FriendLinksDto> GetFriendLinksByIsShow(int isShow);
    }
}
