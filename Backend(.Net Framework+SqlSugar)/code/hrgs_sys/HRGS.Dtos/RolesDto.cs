using System;


namespace HRGS.Dtos
{
    public class RolesDto
    {
        public Guid Id { get; set; }

        public string RolesTitle { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
