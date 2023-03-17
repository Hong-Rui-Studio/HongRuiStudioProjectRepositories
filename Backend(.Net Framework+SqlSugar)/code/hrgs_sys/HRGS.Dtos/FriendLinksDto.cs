using System;


namespace HRGS.Dtos
{
    public class FriendLinksDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Links { get; set; }
        public int IsShow { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
