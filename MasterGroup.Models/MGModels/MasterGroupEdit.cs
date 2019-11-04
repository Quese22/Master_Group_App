using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Models
{
    public class MasterGroupEdit
    {
        public int GroupId { get; set; }
        public string Username { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Commit to action #1")]
        public string CheckItem1 { get; set; }
        [Display(Name = "Commit to action #2")]
        public string CheckItem2 { get; set; }
        [Display(Name = "Commit to action #3")]
        public string CheckItem3 { get; set; }
      
    }
}
