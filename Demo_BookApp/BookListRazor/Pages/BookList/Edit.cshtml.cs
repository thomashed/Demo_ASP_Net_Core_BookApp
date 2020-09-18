using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private ApplicationDbContext _dbContext;
        [BindProperty]
        public BookModel Book { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGet(int id)
        {
            Book = await _dbContext.Book.FindAsync(id);
        }

        //we'll be redirecting to a page, so we return IActionResult
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // retrieve book we wanna change from DB
                var bookFromDb = await _dbContext.Book.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.ISBN = Book.ISBN;
                bookFromDb.Author = Book.Author;

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