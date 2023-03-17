using System;


namespace HRGS.Dtos
{
    public class WebMenusDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Links { get; set; }

        public string Icons { get; set; }


        public Guid ParentId { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
