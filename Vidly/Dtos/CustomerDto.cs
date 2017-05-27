using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please enter customer's name.")] //Column name will no longer be nullable
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //? before variable declaration makes it nullable? 
        //[Display(Name = "Date of Birth")]
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedtoNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        //public MembershipType MembershipType { get; set; }

        //[Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}