﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ.Models.ViewModels
{
    public class LibraryListViewModel
    {
        public IEnumerable<Library> Libraries { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
