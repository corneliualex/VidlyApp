using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyApp.Models;

namespace VidlyApp.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

      
        //[Min18YearsOldIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //public MembershipType MembershipType { get; set; }
     
        public byte MembershipTypeId { get; set; }
    }
}