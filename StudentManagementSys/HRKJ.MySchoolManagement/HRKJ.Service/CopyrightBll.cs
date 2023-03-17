using HRKJ.Dtos;
using HRKJ.IService;
using HRKJ.IRepository;
using HRKJ.Repository;
using HRKJ.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Service
{
    public class CopyrightBll : ICopyrightBll
    {
        private ICopyrightDal _dal = new CopyrightDal();

        public async Task<int> AddCopyrightAsync(string title, string content, string phone, string tel, 
            string address, string photo, string images, string logo, string smallLogo, string remark1, 
            string remark2)
        {
            return await _dal.AddAsync(new Copyright
            {
                Title = title,
                Content = content,
                Phone = phone,
                Tel = tel,
                Address = address,
                Photo = photo,
                Images = images,
                Logo = logo,
                SmallLogo = smallLogo,
                Remark1 = remark1,
                Remark2 = remark2
            });
        }

        public async Task<int> EditCopyrightAsync(int id, string title, string content, string phone, string tel, string address, string photo, string images, string logo, string smallLogo, string remark1, string remark2)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;

            data.Title = title;
            data.Content= content;
            data.Phone = phone; 
            data.Tel = tel;
            data.Address = address;
            if (!string.IsNullOrEmpty(photo))
                data.Photo = photo;
            if (!string.IsNullOrEmpty(images))
                data.Images = images;
            if (!string.IsNullOrEmpty(logo))
                data.Logo = logo;
            if (!string.IsNullOrEmpty(smallLogo))
                data.SmallLogo = smallLogo;
            data.Remark1 = remark1;
            data.Remark2 = remark2;
            data.UpdateTime= DateTime.Now;
            return await _dal.EditAsync(data); 
        }

        public async Task<CopyrightDto> GetCopyrightByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? null : new CopyrightDto 
            {
                Id = data.Id,
                Title = data.Title,
                Content = data.Content, 
                Phone = data.Phone,
                Tel = data.Tel,
                Address = data.Address,
                Photo = data.Photo,
                Images = data.Images,
                Logo = data.Logo,
                SmallLogo = data.SmallLogo,
                Remark1 = data.Remark1,
                Remark2 = data.Remark2
            };
        }

        
    }
}
