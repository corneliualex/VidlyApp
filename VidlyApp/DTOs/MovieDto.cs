using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyApp.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public DateTime ReleaseDate { get; set; }

        public DateTime AddedDate { get; set; }


        public short NumberInStock { get; set; }

        //public Gendre Gendre { get; set; }

        public byte GendreId { get; set; }
    }
}