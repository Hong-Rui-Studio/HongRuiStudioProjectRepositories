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
    public class CopyrightBll : ICopyrightBll
    {
        private ICopyrightDal dal = new CopyrightDal();


        public async Task<int> AddCopyrightAsync(string title, string content, string phone, 
            string tel, string address, string photo, string images, 
            string logo, string smallLogo, string remark1, string remark2)
        {
            return await dal.AddAsync(new Copyright 
            {
                Title = title,
                Content = content,
                Phone = phone,
                Tel =tel,
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
            var data = await dal.QueryAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return -1;

            data.Title = title;
            data.Content = content;
            data.Phone= phone;
            data.Tel=tel;
            data.Address = address;
            if(!string.IsNullOrEmpty(photo))
                data.Photo = photo;
            if(!string.IsNullOrEmpty(images))
                data.Images = images;
            if(!string.IsNullOrEmpty(logo))
                data.Logo = logo;
            if(!string.IsNullOrEmpty(smallLogo))
                data.SmallLogo = smallLogo;
            data.Remark1= remark1;
            data.Remark2= remark2;
            data.UpdateTime= DateTime.Now;
            return await dal.EditAsync(data);
        }

        public async Task<CopyrightDto> GetCopyrightInfoAsync()
        {
            var data = await dal.QueryAsync();

            return data.Any() ? data.Select(c => new CopyrightDto
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                Phone= c.Phone,
                Tel= c.Tel,
                Address = c.Address,
                Photo= c.Photo,
                Images= c.Images,
                Logo= c.Logo,
                SmallLogo= c.SmallLogo,
                Remark1= c.Remark1,
                Remark2= c.Remark2
            }).First() : new CopyrightDto();
        }
    }
}
