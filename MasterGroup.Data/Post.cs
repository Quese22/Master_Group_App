using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "A good title will help others find your question too")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500, ErrorMessage = "See if you can ask or explain your answer in less characters.")]
        public string Content { get; set; }
        [Required]
        [ForeignKey("Quese")]                       //this
        public int GroupId { get; set; }            //is how
        public virtual MasterGroup Quese { get; set; }  //you connect the tables
        [Required]
        public DateTimeOffset PostDate { get; set; }
    }
}
