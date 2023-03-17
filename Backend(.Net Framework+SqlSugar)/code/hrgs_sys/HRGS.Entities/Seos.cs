using System;

namespace HRGS.Entities
{
    public class Seos :BaseEntity
    {
        public string Title { get; set; }
        public string KeyWord { get; set; }
        public string Description { get; set; }
        public Guid MenusId { get; set; }
    }
}