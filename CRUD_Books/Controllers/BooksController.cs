
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Books.Models;
using System.Transactions;
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD_Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            // Check if the 'Books' entity set is not null
            // If not null, retrieve all books and pass them to the view
            // If null, return a problem message
            return _context.Books != null ? 
                          View(await _context.Books.ToListAsync()) :
                          Problem("Entity set 'BookDbContext.Books'  is null.");
        }


        // GET: Books/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            // If id is 0, create a new book object and pass it to the view
            // If id is not 0, find the book with the given id and pass it to the view
            if (id == 0)
                return View(new Book());
            else
                return View(_context.Books.Find(id));
        }

        // POST: Books/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Book_Id,Title,Author,Price,QuantityAvailable")] Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Book_Id == 0)
                {
                    //book.Date = DateTime.Now; 
                    _context.Add(book);
                }
                else
                    // Update the existing book in the context
                    _context.Update(book);
                // Save the changes to the database
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        
        
       

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookDbContext.Books'  is null.");
            }
            // Find the book with the given id
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                // Remove the book from the context
                _context.Books.Remove(book);
            }
            // Save the changes to the database
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}


//controller class for managing CRUD operations on the Book entity
// BooksController class is derived from the Controller base class,
// which provides functionality for handling HTTP requests and generating responses
// class has a private field _context of type BookDbContext, which is used to interact with the database using Entity Framework.
// The constructor injects an instance of BookDbContext into the controller, ensuring that the controller has access to the database context
// Index action method retrieves all books from the database and passes them to the Index view for display.
// If the Books entity set is null, a problem message is returned
// AddOrEdit action method is used for both adding new books and editing existing books.
// If the id parameter is 0, a new book object is created and passed to the view. If the id parameter is not 0, the book with the given id is retrieved from the database and passed to the view for editing
// AddOrEdit action method also handles the form submission for adding or editing a book. It checks if the model state is valid, and if so, it either adds the new book to the context
// or updates the existing book in the context. The changes are then saved to the database
// DeleteConfirmed action method is used to delete a book from the database. It first checks if the Books entity set is null, and if so, returns a problem message.
// It then finds the book with the given id and removes it from the context. The changes are then saved to the database
// includes attributes, such as [HttpPost], [ValidateAntiForgeryToken], and [Bind], to handle form submissions and protect against security vulnerabilities
// like cross-site request forgery (CSRF) attacks