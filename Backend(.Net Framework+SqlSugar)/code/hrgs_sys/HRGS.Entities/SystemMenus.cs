using System;

namespace HRGS.Entities
{
    public class SystemMenus : BaseEntity
    {
        public string Title { get; set; }

        public string Links { get; set; }

        public string Icons { get; set; }

        public Guid ParentId { get; set; }
    }
}