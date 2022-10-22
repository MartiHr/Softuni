using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var applicationUser = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (applicationUser == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Book ID");
            }

            if (!applicationUser.ApplicationUsersBooks.Any(ub => ub.BookId == bookId))
            {
                var userBook = new ApplicationUserBook()
                {
                    ApplicationUserId = userId,
                    ApplicationUser = applicationUser,
                    BookId = bookId,
                    Book = book
                };

                applicationUser.ApplicationUsersBooks.Add(userBook);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var books = await context.Books
                .Include(b => b.Category)
                .ToListAsync();

            var booksModels = books
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Author = b.Author,
                    Category = b.Category.Name,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title
                });

            return booksModels;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories
                .ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetMineAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(ub => ub.Book)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.ApplicationUsersBooks
                .Select(ub => new BookViewModel()
                {
                    Id = ub.BookId,
                    Author = ub.Book.Author,
                    Category = ub.Book.Category.Name,
                    Description = ub.Book.Description,
                    ImageUrl = ub.Book.ImageUrl,
                    Rating = ub.Book.Rating,
                    Title = ub.Book.Title
                });
        }

        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            var applicationUser = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (applicationUser == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var userBook = applicationUser.ApplicationUsersBooks.FirstOrDefault(ub => ub.BookId == bookId);

            if (userBook != null)
            {
                applicationUser.ApplicationUsersBooks.Remove(userBook);

                await context.SaveChangesAsync();
            }
        }
    }
}
