﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyApp.Models;

namespace VidlyApp.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Gendre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}