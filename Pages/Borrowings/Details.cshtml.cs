using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Selin_Robert_Cristian_Lab2.Data;
using Selin_Robert_Cristian_Lab2.Models;

namespace Selin_Robert_Cristian_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Selin_Robert_Cristian_Lab2.Data.Selin_Robert_Cristian_Lab2Context _context;

        public DetailsModel(Selin_Robert_Cristian_Lab2.Data.Selin_Robert_Cristian_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; }
        public IList<Borrowing> BorrowingDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }

            if (_context.Borrowing != null)
            {
                BorrowingDetail = await _context.Borrowing
                .Include(b => b.Book)
                    .ThenInclude(b => b.Authors)
                .Include(b => b.Member).ToListAsync();
            }


            return Page();
        }
    }
}
