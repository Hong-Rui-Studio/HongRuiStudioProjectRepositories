using System;


namespace HRGS.Dtos
{
    public class AdminsDto
    {
        public Guid Id { get; set; }
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
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }



    }
}
