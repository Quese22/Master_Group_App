using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Models
{
    public class PostListItem
    {
        public int GroupId { get; set; }
        public int PostId { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name="Date of Creation")]
        public DateTimeOffset PostDate { get; set; }
    }
}
