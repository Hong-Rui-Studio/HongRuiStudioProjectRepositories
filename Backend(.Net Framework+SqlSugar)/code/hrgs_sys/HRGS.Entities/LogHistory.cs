using System;

namespace HRGS.Entities
{
    public class LogHistory :BaseEntity
    {
        public Guid AdminsId { get; set; }

        public string Details { get; set; }
    }
}