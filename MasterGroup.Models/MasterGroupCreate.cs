using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Models
{
    public class MasterGroupCreate
    {
        [Required]
        [Display(Name = "Subject of Mastery")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Cool group name you want others to Join")]
        public string Name { get; set; }
        [MaxLength(350, ErrorMessage = "This should be pretty precise, the easier it is to understand, usually translates into easier goals to set, bringing about more succcess for your participants.")]
        public string Description { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise goals bring about measureable results!")]
        [Display(Name = "Commitment Item #1")]
        public string CheckItem1 { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise goals bring about measureable results!")]
        [Display(Name = "Commitment Item #2")]
        public string CheckItem2 { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise goals bring about measureable results!")]
        [Display(Name = "Commitment Item #3")]
        public string CheckItem3 { get; set; }
    }
}
