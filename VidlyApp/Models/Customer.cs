using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //data annotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }
        //By convention : ClassNameId it's recognized by VS and treats it as a foreign key
        public byte MembershipTypeId { get; set; }//for optimization instead of using the entire Membership object we may only need the foreign key              
    }
}