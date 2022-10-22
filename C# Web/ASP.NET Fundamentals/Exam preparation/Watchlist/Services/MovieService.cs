using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var movie = new Movie()
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title,
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                var userMovie = new UserMovie()
                {
                    UserId = user.Id,
                    User = user,
                    MovieId = movieId,
                    Movie = movie
                };

                user.UsersMovies.Add(userMovie);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            var movies = await context.Movies
                .Include(m => m.Genre)
                .ToListAsync();

            var moviesModel = movies
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Director = m.Director,
                    Genre = m.Genre.Name,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title
                });

            return moviesModel;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UsersMovies
                .Select(um => new MovieViewModel()
                {
                    Id = um.MovieId,
                    Director = um.Movie.Director,
                    Genre = um.Movie.Genre.Name,
                    ImageUrl = um.Movie.ImageUrl,
                    Rating = um.Movie.Rating,
                    Title = um.Movie.Title
                });
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                var userMovie = user.UsersMovies.FirstOrDefault(um => um.MovieId == movieId);

                if (movie != null)
                {
                    user.UsersMovies.Remove(userMovie);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
