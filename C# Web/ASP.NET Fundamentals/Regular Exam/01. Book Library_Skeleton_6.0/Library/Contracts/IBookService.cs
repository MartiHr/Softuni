using Library.Data.Models;
using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<IEnumerable<BookViewModel>> GetMineAsync(string userId);

        Task AddBookToCollectionAsync(int bookId, string userId);

        Task RemoveBookFromCollectionAsync(int bookId, string userId);
    }
}
