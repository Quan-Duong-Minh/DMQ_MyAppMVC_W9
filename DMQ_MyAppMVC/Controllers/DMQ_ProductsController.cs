using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMQ_MyAppMVC.Data;
using DMQ_MyAppMVC.Models;

namespace DMQ_MyAppMVC.Controllers
{
    public class DMQ_ProductsController : Controller
    {
        private readonly DMQ_AppDbContext _context;

        public DMQ_ProductsController(DMQ_AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dMQ_AppDbContext = _context.DMQ_Products.Include(d => d.DMQ_Category);
            return View(await dMQ_AppDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dMQ_Product = await _context.DMQ_Products
                .Include(d => d.DMQ_Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dMQ_Product == null) return NotFound();

            return View(dMQ_Product);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.DMQ_Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,SalePrice,Status,CategoryId,CreatedDate,Image,Description")] DMQ_Product dMQ_Product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dMQ_Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.DMQ_Categories, "Id", "Name", dMQ_Product.CategoryId);
            return View(dMQ_Product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dMQ_Product = await _context.DMQ_Products.FindAsync(id);
            if (dMQ_Product == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(_context.DMQ_Categories, "Id", "Name", dMQ_Product.CategoryId);
            return View(dMQ_Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,SalePrice,Status,CategoryId,CreatedDate,Image,Description")] DMQ_Product dMQ_Product)
        {
            if (id != dMQ_Product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dMQ_Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DMQ_ProductExists(dMQ_Product.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.DMQ_Categories, "Id", "Name", dMQ_Product.CategoryId);
            return View(dMQ_Product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dMQ_Product = await _context.DMQ_Products
                .Include(d => d.DMQ_Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dMQ_Product == null) return NotFound();

            return View(dMQ_Product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dMQ_Product = await _context.DMQ_Products.FindAsync(id);
            if (dMQ_Product != null)
            {
                _context.DMQ_Products.Remove(dMQ_Product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DMQ_ProductExists(int id)
        {
            return _context.DMQ_Products.Any(e => e.Id == id);
        }
    }
}