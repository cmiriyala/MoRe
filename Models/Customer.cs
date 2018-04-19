using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MoRe.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Subscribe to News Letter ?")]
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Type of Membership")]
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Name")]
        public byte MembershipTypeId { get; set; }
        [Display(Name="Date of Birth")]
        public DateTime? Birthdate { get; set; }

    }

}