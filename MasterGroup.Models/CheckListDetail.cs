using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Models
{
    public class CheckListDetail
    {
        public int ListId { get; set; }
        [Display(Name = "Checklist Item #1")]
        public string Check1 { get; set; }
        [Display(Name = "Checklist Item #2")]
        public string Check2 { get; set; } 
        [Display(Name = "Checklist Item #3")]
        public string Check3 { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
