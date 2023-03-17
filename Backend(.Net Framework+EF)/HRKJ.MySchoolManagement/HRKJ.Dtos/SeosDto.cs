using System;

namespace HRKJ.Dtos
{
    public class SeosDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public int MenusId { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
