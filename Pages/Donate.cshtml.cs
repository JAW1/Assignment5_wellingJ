using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment5_wellingJ.Models;
using Assignment5_wellingJ.Infrastructure;

namespace Assignment5_wellingJ.Pages
{
    public class DonateModel : PageModel
    {
        private iLibraryRepository repository;

        //Constructor for DonateModel
        public DonateModel (iLibraryRepository repo, Cart cartServices)
        {
            repository = repo;
            Cart = cartServices;
        }
        //Properties for DonateModel
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Library library = repository.Libraries.FirstOrDefault(p => p.BookId == bookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(library, 1, library.Price);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
               cl.Library.BookId == bookId).Library);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
