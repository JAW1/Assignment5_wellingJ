using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ.Models
{
    public class Library
    {
        //Adding all of the different attributes to the model
        [Key]
        //This will be an auto key
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        //required but if it doesn't have data then it will be null
        public string AuthorMiddleName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^\d{2,3}[-]{0,1}\d{10}|\d{9,11}$", ErrorMessage = "Not a valid ISBN")]
        public string Isbn { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int NumPages { get; set; }
    }
}
