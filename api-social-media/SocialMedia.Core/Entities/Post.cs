using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public partial class Post
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
    }
}
