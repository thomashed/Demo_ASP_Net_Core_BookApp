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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<BookModel> Books { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // TODO: can I call this OnGetAsync?
        public async Task OnGet()
        {
            // assign books to be all of the books from the database
            Books = await _db.Book.ToListAsync();
        }
    }
}