using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem (Library lib, int qty, double price)
        {
            CartLine line = Lines
                .Where(l => l.Library.BookId == lib.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Library = lib,
                    Quantity = qty,
                    Price = price
                });
            }
            else
            {
                line.Quantity += qty;
                line.Price += price;
            }
        }
        public virtual void RemoveLine(Library lib) =>
            Lines.RemoveAll(x => x.Library.BookId == lib.BookId);
        public virtual void Clear() => Lines.Clear();
        public decimal ComputeTotalSum()
        {
            return Lines.Sum(e => (decimal) e.Price * e.Quantity);
        }
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Library Library { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
    }
}
