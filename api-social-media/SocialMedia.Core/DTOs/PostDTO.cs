using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialMedia.Core.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UrlImage { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
