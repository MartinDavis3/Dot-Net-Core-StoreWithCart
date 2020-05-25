using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreWithCart.Data;
using StoreWithCart.Models;

namespace StoreWithCart.Controllers
{
    public class ShopItemsController : Controller
    {
        private readonly StockContext _context;

        public ShopItemsController(StockContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockItem
                .Where( x => x.QuantityInCart == 0)
                .ToListAsync());
        }
        public async Task<IActionResult> AddItemToCart(int? id)
        { 
            if (id == null)
            { 
                return RedirectToAction("Index");
            }

            var stockItem = await _context.StockItem
                .FirstOrDefaultAsync(m => m.Id == id);

            if (stockItem == null)
            {
                return BadRequest("Could add item to cart.");
            }
            stockItem.QuantityInCart = 1;
            _context.Update(stockItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
