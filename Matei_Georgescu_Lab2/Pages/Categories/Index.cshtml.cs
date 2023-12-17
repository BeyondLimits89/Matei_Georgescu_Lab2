﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matei_Georgescu_Lab2.Data;
using Matei_Georgescu_Lab2.Models;

namespace Matei_Georgescu_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Georgescu_Lab2.Data.Matei_Georgescu_Lab2Context _context;

        public IndexModel(Matei_Georgescu_Lab2.Data.Matei_Georgescu_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public IList<Book> Books { get;set; }
        public int SelectedCategoryId { get; set; }
        public async Task OnGetAsync(int cateogryID)
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }

            SelectedCategoryId = cateogryID;
            Books = await _context.Book
                                   .Include(b => b.Author)
                                   .Include(b => b.Publisher)
                                   .Where(b => b.BookCategories.Any(bc => bc.CategoryID == cateogryID))
                                   .ToListAsync();
        }
    }
}