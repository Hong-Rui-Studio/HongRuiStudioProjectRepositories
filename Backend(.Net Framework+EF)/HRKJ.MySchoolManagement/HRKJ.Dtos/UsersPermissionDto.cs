using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Dtos
{
    public class UsersPermissionDto
    {
        public int Id { get; set; }
        public int RolesId { get; set; }
        public int MenusId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
