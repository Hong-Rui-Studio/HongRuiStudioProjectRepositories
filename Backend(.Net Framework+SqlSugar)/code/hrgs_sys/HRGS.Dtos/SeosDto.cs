using System;


namespace HRGS.Dtos
{
    public class SeosDto 
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string KeyWord { get; set; }

        public string Description { get; set; }
        public Guid MenusId { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }


    }
}
