using System;
using System.ComponentModel.DataAnnotations;


namespace HRKJ.Entity
{
    public class UsersPermissions : BaseEntity
    {
        [Required]
        public int RolesId { get; set; }

        [Required]
        public int MenusId { get; set; }
    }
}
