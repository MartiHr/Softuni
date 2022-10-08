using ForumDemoApp.Data;
using ForumDemoApp.Data.Models;
using ForumDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumDemoApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumDbContext context;

        public PostsController(ForumDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await context.Posts
                .Where(p => p.IsDeleted == false)
                .Select(p => new PostViewModel 
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddPostViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await context.Posts.AddAsync(new Post
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .FirstOrDefaultAsync();

            if (post != null)
            {
                return View(post);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = await context.Posts.FindAsync(model.Id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.IsDeleted = true;
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
