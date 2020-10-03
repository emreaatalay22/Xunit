using System;
using System.ComponentModel.DataAnnotations;

namespace xUnitTest
{
    public partial class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? Stock { get; set; }
    }
}
