using System;
namespace HRKJ.Dtos
{
    public class SystemMenusDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Icons { get; set; }
        public int ParentId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
