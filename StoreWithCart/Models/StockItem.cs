using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWithCart.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public decimal Price { get; set; }
        public int QuantityInCart { get; set; }
    }
}
