using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5_wellingJ.Models;

namespace Assignment5_wellingJ.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private iLibraryRepository repository;
        public NavigationMenuViewComponent (iLibraryRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //viewbag used in this instance to pass this data between the controllers and views
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Libraries
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
