using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matei_Georgescu_Lab2.Data;
using Matei_Georgescu_Lab2.Models;

namespace Matei_Georgescu_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Matei_Georgescu_Lab2.Data.Matei_Georgescu_Lab2Context _context;

        public DetailsModel(Matei_Georgescu_Lab2.Data.Matei_Georgescu_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Book).ThenInclude(b => b.Author)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
