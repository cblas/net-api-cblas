using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
