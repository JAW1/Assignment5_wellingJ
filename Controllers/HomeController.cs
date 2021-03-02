using Assignment5_wellingJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment5_wellingJ.Models.ViewModels;

namespace Assignment5_wellingJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private iLibraryRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, iLibraryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {
            return View(new LibraryListViewModel
            {
                Libraries = _repository.Libraries
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //creating ability to show page numbering dynamically depending on how many items are part of a category
                    TotalNumItems = category == null ? _repository.Libraries.Count() :
                    _repository.Libraries.Where (x => x.Category == category).Count()
                },
                CurrentCategory = category

            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
