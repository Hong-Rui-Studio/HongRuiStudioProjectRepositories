using HRKJ.Dtos;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface ICopyrightBll
    {
        Task<CopyrightDto> GetCopyrightByIdAsync(int id);

        Task<int> AddCopyrightAsync(string title, string content, string phone, string tel, string address, string photo, string images, string logo, string smallLogo, string remark1, string remark2);

        Task<int> EditCopyrightAsync(int id, string title, string content, string phone, string tel, string address, string photo, string images, string logo, string smallLogo, string remark1, string remark2);
    }
}
