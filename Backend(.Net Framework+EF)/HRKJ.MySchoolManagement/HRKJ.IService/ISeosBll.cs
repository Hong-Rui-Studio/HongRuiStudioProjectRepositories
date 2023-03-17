using HRKJ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IService
{
    public interface ISeosBll
    {
        Task<int> AddSeosAsync(string title, string keyword, string description, int menusId);
        Task<int> EditSeosAsync(int id, string title, string keyword, string description, int menusId);
        Task<int> DeleteSeosAsync(int id);

        Task<List<SeosDto>> GetAllSeosAsync();
        Task<List<SeosDto>> GetSeosByTitleAsync(string title);
        Task<SeosDto> GetSeosByIdASync(int id);
        Task<SeosDto> GetSeosByMenusIdAsync(int menusId);
        List<SeosDto> GetAllSeos();
        List<SeosDto> GetSeosByTitle(string title);
        SeosDto GetSeosById(int id);
        SeosDto GetSeosByMenusId(int menusId);
    }
}
