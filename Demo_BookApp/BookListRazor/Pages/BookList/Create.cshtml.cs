using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        // bind to the view's Book props entered in the form
        // this way, we won't need to pass in the bookObj, 
        // when invoking the Post Method later
        [BindProperty]
        public BookModel Book { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            // check if the incoming request bind to the model props correctly
            // if valid, add to database
            if (ModelState.IsValid)
            {
                // not added to DB yet - but added a que
                await _db.Book.AddAsync(Book);
                // push data in EF's que, to the DB
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }




            throw new NotImplementedException();
        }
    }
}