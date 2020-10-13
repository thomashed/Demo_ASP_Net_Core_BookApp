using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor
{
    public class UpsertModel : PageModel
    {

        private ApplicationDbContext _dbContext;
        [BindProperty]
        public BookModel Book { get; set; }

        public UpsertModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new BookModel();
            if (id == null)
            {
                // create
                return Page();
            }

            // udpate
            Book = await _dbContext.Book.FirstOrDefaultAsync(u => u.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        //we'll be redirecting to a page, so we return IActionResult
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    _dbContext.Book.Add(Book);
                }
                else
                {
                    _dbContext.Book.Update(Book);
                }

                // save model changes to db
                await _dbContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnDelete()
        {





            throw new NotImplementedException();
        }

    }
}