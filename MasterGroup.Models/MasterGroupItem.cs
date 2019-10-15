using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Models
{
    public class MasterGroupItem
    {   [Required]
        [Display(Name="User")]
        public Guid OwnerID { get; set; }
        [Key]
        public Guid GroupID { get; set; }
        [Required]
        [Display(Name = "Subject of Mastery")]
        public string Subject { get; set; }
        [Required]
        [Display(Name="Group Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name="Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
