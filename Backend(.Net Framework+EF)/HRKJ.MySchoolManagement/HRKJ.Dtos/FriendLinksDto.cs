using System;

namespace HRKJ.Dtos
{
    public class FriendLinksDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int IsShow { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
