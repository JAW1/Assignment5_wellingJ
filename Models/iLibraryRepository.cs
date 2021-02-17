using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ.Models
{
    public interface iLibraryRepository
    {
        IQueryable<Library> Libraries { get; }
    }
}
