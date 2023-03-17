using System;

namespace HRGS.Entities
{
    public class AdminsPermission : BaseEntity
    {
        public Guid RolesId { get; set; }

        public Guid MenusId { get; set; }
    }
}