using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required] //Column name will no longer be nullable
        [StringLength(255)]
        public string Name { get; set; }

        //? before variable declaration makes it nullable? 
        [Display(Name="Date of Birth")]
        public DateTime? Birthdate { get; set;  }

        public bool IsSubscribedtoNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}