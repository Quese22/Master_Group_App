using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Data
{
    public class GroupCheckLists
    {
        [Key, ForeignKey("Quese")]
        public int ListId { get; set; }
        //[ForeignKey("Quese")]
        //public int GroupID { get; set; }
        public MasterGroup Quese { get; set; }

        [Display(Name ="Checklist Item #1")]
        public string Check1 {get;set;} //bool?
        [Display(Name = "Checklist Item #2")]
        public string Check2 { get; set; } //bool?
        [Display(Name = "Checklist Item #3")]
        public string Check3 { get; set; } //bool??

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
