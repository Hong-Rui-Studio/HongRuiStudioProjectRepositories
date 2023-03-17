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
namespace HRKJ.Service
{
    public class FriendLinksBll : IFriendLinksBll
    {
        private IFriendLinksDal dal = new FriendLinksDal();

        public async Task<int> AddFriendLinksAsync(string title, string link, int isShow)
        {
            return await dal.AddAsync(new FriendLinks 
            {
                Title= title,
                Link=link,
                IsShow=isShow
            });
        }

        public async Task<int> DeleteFriendLinksAsync(int id)
        {
            var data =await dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;

            return await dal.DeleteAsync(data);
        }

        public async Task<int> EditFriendLinksAsync(int id, string title, string link, int isShow)
        {
            var data = await dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;
            data.Title = title;
            data.Link= link;
            data.IsShow=isShow;
            data.UpdateTime= DateTime.Now;
            return await dal.EditAsync(data);
        }

        public  List<FriendLinksDto> GetAllFriendLinks()
        {
            var data =  dal.Query();
            return data.Any() ? data.Select(f => new FriendLinksDto 
            {
                Id=f.Id,
                Title=f.Title,
                Link=f.Link,
                IsShow = f.IsShow,
                UpdateTime = f.UpdateTime
            }).ToList() : new List<FriendLinksDto>();
        }

        public async Task<List<FriendLinksDto>> GetAllFriendLinksAsync()
        {
            var data =await  dal.QueryAsync();
            return data.Any() ? data.Select(f => new FriendLinksDto
            {
                Id = f.Id,
                Title = f.Title,
                Link = f.Link,
                IsShow = f.IsShow,
                UpdateTime = f.UpdateTime
            }).ToList() : new List<FriendLinksDto>();
        }

        public  FriendLinksDto GetFriendLinksById(int id)
        {
            var data = dal.Query(id);
            return data == null || string.IsNullOrEmpty(data.Title)
                    ? new FriendLinksDto()
                    : new FriendLinksDto 
                    {
                        Id = data.Id,
                        Title = data.Title,
                        Link = data.Link,
                        IsShow = data.IsShow,
                        UpdateTime = data.UpdateTime
                    };

        }

        public async Task<FriendLinksDto> GetFriendLinksByIdAsync(int id)
        {
            var data =await  dal.QueryAsync(id);
            return data == null || string.IsNullOrEmpty(data.Title)
                    ? new FriendLinksDto()
                    : new FriendLinksDto
                    {
                        Id = data.Id,
                        Title = data.Title,
                        Link = data.Link,
                        IsShow = data.IsShow,
                        UpdateTime = data.UpdateTime
                    };
        }

        public  List<FriendLinksDto> GetFriendLinksByIsShow(int isShow)
        {
            var data = dal.Query(f => f.IsShow == isShow);
            return data.Any() ? data.Select(f => new FriendLinksDto
            {
                Id = f.Id,
                Title = f.Title,
                Link = f.Link,
                IsShow = f.IsShow,
                UpdateTime = f.UpdateTime
            }).ToList() : new List<FriendLinksDto>();
        }

        public async Task<List<FriendLinksDto>> GetFriendLinksByIsShowAsync(int isShow)
        {
            var data =await  dal.QueryAsync(f => f.IsShow == isShow);
            return data.Any() ? data.Select(f => new FriendLinksDto
            {
                Id = f.Id,
                Title = f.Title,
                Link = f.Link,
                IsShow = f.IsShow,
                UpdateTime = f.UpdateTime
            }).ToList() : new List<FriendLinksDto>();
        }

        public List<FriendLinksDto> GetFriendLinksByTitle(string title)
        {
            var data = dal.Query(f => f.Title.Contains(title));
            return data.Any() ? data.Select(f => new FriendLinksDto
            {
                Id = f.Id,
                Title = f.Title,
                Link = f.Link,
                IsShow = f.IsShow,
                UpdateTime = f.UpdateTime
            }).ToList() : new List<FriendLinksDto>();
        }

        public async Task<List<FriendLinksDto>> GetFriendLinksByTitleAsync(string title)
        {
            var data =await  dal.QueryAsync(f => f.Title.Contains(title));
            return data.Any() ? data.Select(f => new FriendLinksDto
            {
                Id = f.Id,
                Title = f.Title,
                Link = f.Link,
                IsShow = f.IsShow,
                UpdateTime = f.UpdateTime
            }).ToList() : new List<FriendLinksDto>();
        }
    }
}
