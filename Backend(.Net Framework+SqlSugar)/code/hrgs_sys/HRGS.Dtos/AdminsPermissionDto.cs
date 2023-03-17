using System;


namespace HRGS.Dtos
{
    public class AdminsPermissionDto
    {
        public Guid Id { get; set; }

        public Guid RolesId { get; set; }

        public Guid MenusId { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
