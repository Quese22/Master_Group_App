using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MasterGroup.Models
{
    public class PostCreate
    {
        public int GroupID { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "A good title will help others find your question too")]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Message")]
        [MaxLength(2000,ErrorMessage = "This isn't a novel, just a message.")]
        public string Content { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}
