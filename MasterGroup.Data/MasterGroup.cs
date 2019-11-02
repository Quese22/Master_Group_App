using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Data
{
    public class MasterGroup
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string Username { get; set; }

        [Required]
        [Display(Name="Subject of Mastery")]
        public string Subject { get; set; }


        [Required]
        [Display(Name="Cool group name you want others to Join")]
        public string Name { get; set; }


        [MaxLength(350, ErrorMessage ="This should be pretty precise, the easier it is to understand, usually translates into easier goals to set, bringing about more succcess for your participants!!")]
        public string Description { get; set; }


        [ForeignKey("Quese")]
        public int ListId { get; set; }
        public virtual GroupCheckLists Quese { get; set; }


        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise commitments bring about measureable results")]
        [Display(Name="Commitment #1")]
        public string CheckItem1 { get; set; }


        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise commitments bring about measureable results")]
        [Display(Name = "Commitment #2")]
        public string CheckItem2 { get; set; }


        [Required]
        [MaxLength(150, ErrorMessage = "Too long, precise commitments bring about measureable results")]
        [Display(Name = "Commitment #3")]
        public string CheckItem3 { get; set; }


        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
