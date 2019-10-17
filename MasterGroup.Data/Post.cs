using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Data
{
   public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string Username { get; set; }
        [Required]
        [MinLength(10, ErrorMessage ="A good title will help others find your question too")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500,ErrorMessage ="See if you can ask or explain your answer in less characters.")]
       public string Content { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public DateTimeOffset PostDate { get; set; }
    }
}
