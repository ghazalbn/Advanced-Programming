using System;
using System.ComponentModel.DataAnnotations;
namespace BookFinder
{
    public class Form
    {
        [Required(AllowEmptyStrings=false)]
        public string BookName { get; set; }
    }
}
