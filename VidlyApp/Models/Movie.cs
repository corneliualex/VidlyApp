using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyApp.Models
{
    //plain old clr object(POCO) 
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public short NumberInStock { get; set; }

        public Gendre Gendre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GendreId { get; set; }
    }
}


/*
 POCO :
    - Is a simple object created int the CLR(Common Language Runtime) of the .NET Framework which is unencumbered by inheritance or attributes. 
    - a POCO does not have any dependency on an external framework and generally does not have any behaviour
*/