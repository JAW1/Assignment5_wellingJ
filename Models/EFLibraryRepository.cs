using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ.Models
{
    public class EFLibraryRepository : iLibraryRepository
    {
        private Amazon2DBContext _context;
        //Constructor
        public EFLibraryRepository(Amazon2DBContext context)
        {
            _context = context;
        }
    
    public IQueryable<Library> Libraries => _context.Libraries;
    }

}
