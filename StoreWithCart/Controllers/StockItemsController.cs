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
    public class StockItemsController : Controller
    {
        private readonly StockContext _context;

        public StockItemsController(StockContext context)
        {
            _context = context;
        }

        // GET: StockItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockItem.ToListAsync());
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
                return BadRequest("Could not add item to cart.");
            }
            stockItem.QuantityInCart++;
            _context.Update(stockItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItemFromCart(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var stockItem = await _context.StockItem
                .FirstOrDefaultAsync(m => m.Id == id);

            if (stockItem == null)
            {
                return BadRequest("Could not remove item from cart.");
            }
            stockItem.QuantityInCart--;
            _context.Update(stockItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }

}
