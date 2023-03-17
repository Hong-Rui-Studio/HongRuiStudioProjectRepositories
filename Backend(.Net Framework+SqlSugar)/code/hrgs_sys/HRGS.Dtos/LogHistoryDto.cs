using System;


namespace HRGS.Dtos
{
    public class LogHistoryDto
    {
        public Guid Id { get; set; }

        public Guid AdminsId { get; set; }

        public string Details { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
