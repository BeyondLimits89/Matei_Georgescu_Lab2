using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matei_Georgescu_Lab2.Data;
using Matei_Georgescu_Lab2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Matei_Georgescu_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Matei_Georgescu_Lab2.Data.Matei_Georgescu_Lab2Context _context;

        public EditModel(Matei_Georgescu_Lab2.Data.Matei_Georgescu_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
{
                return NotFound();
            }

            Book = await _context.Book
                  .Include(b => b.Publisher)
                  .Include(b => b.Author)
                  .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                  .AsNoTracking()
                  .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Book);

            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bookToUpdate = await _context.Book
                .Include(i => i.Publisher)
                .Include(i =>i.Author)
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Book>(bookToUpdate, "Book",i => i.Title, i => i.Author, i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");

            return Page();   

           /* if (bookToUpdate == null)
            {
                return NotFound();
            }
            _context.Attach(Book).State = EntityState.Modified;*/

           
        }

        private bool BookExists(int id)
        {
          return (_context.Book?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
