﻿using System;
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
    public class CreateModel : PageModel
    {
        private readonly Selin_Robert_Cristian_Lab2.Data.Selin_Robert_Cristian_Lab2Context _context;

        public CreateModel(Selin_Robert_Cristian_Lab2.Data.Selin_Robert_Cristian_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
                .Include(b => b.Authors)
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Authors.LastName + " " + x.Authors.FirstName
                });

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}