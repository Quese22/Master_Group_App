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
        public string Username { get; set; }
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
        [Display(Name = "Commitment key #1")]
        public string Commitment1 { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise goals bring about measureable results!")]
        [Display(Name = "Commitment key #2")]
        public string Commitment2 { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise goals bring about measureable results!")]
        [Display(Name = "Commitment key #3")]
        public string Commitment3 { get; set; }
      

        public GroupCheckListItem Quese { get; set; }

        [Required]
        [Display(Name = "Checklist Item #1")]
        public string Check1 { get; set; }
        [Required]
        [Display(Name = "Checklist Item #2")]
        public string Check2 { get; set; }
        [Required]
        [Display(Name = "Checklist Item #3")]
        public string Check3 { get; set; }
    }
}
