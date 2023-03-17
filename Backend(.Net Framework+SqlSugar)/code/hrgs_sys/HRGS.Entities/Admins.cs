using System;

namespace HRGS.Entities
{
    public class Admins : BaseEntity
    {
        public string NickName { get; set; }
        public DateTime BornDate { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Pwd { get; set; }
        public string Photo { get; set; }
        public string Images { get; set; }
        public string Address { get; set; }
        public string WeChat { get; set; }
        public Guid RolesId { get; set; }
    }
}