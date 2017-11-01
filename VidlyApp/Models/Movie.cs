using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyApp.Models
{
    //plain old clr object(POCO) 
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}


/*
 POCO :
    - Is a simple object created int the CLR(Common Language Runtime) of the .NET Framework which is unencumbered by inheritance or attributes. 
    - a POCO does not have any dependency on an external framework and generally does not have any behaviour
*/