﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Selin_Robert_Cristian_Lab2.Data;
using Selin_Robert_Cristian_Lab2.Models;

namespace Selin_Robert_Cristian_Lab2.Pages.Author
{
    public class DeleteModel : PageModel
    {
        private readonly Selin_Robert_Cristian_Lab2.Data.Selin_Robert_Cristian_Lab2Context _context;

        public DeleteModel(Selin_Robert_Cristian_Lab2.Data.Selin_Robert_Cristian_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Authors Authors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);

            if (authors == null)
            {
                return NotFound();
            }
            else 
            {
                Authors = authors;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }
            var authors = await _context.Authors.FindAsync(id);

            if (authors != null)
            {
                Authors = authors;
                _context.Authors.Remove(Authors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
