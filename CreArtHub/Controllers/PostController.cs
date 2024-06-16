using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adapter;
using CreArtHub.Domain.Entity;
using Microsoft.VisualBasic;
using CreArtHub.App.Interactors;
using CreArtHub.Shared.Dto;
using Microsoft.Extensions.Hosting;
using CreArtHub.Shared.Data;
using CreArtHub.Shared.Model;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using CreArtHub.App.Mappers;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CreArtHub.Client.Controllers
{
    
    public class PostController : Controller
    {
        private readonly WebDBContext _context;
        private readonly PostInteractor interactor;
        private readonly UserInteractor userInteractor;
        private readonly CommentInteractor commentInteractor;
        private readonly FileInteractor fileInteractor;

        public PostController(
            WebDBContext context, 
            PostInteractor interactor, 
            UserInteractor userInteractor, 
            CommentInteractor commentInteractor,
            FileInteractor fileInteractor)
        {
            _context = context;
            this.interactor = interactor;
            this.userInteractor = userInteractor;
            this.commentInteractor = commentInteractor;
            this.fileInteractor = fileInteractor;
        }

        // GET: Post
        public async Task<IActionResult> Index(string author, string title)
        {
            ViewData["CurrentAuthorFilter"] = author;
            ViewData["CurrentTitleFilter"] = title;

            Response<IEnumerable<PostDto>> response;
            if (User.IsInRole("admin"))
            {
                if (!String.IsNullOrEmpty(author) || !String.IsNullOrEmpty(title))
                {
                    return View(interactor.GetAllBySearch(author, title).Result.Value);
                }
                else
                {
                    return View(interactor.GetAll().Result.Value);
                }
            } 
            else 
            {
                if (!String.IsNullOrEmpty(author) || !String.IsNullOrEmpty(title))
                {
                    return View(interactor.GetAllBySearchNoSub(author, title).Result.Value);
                }
                else
                {
                    return View(interactor.GetAllNoSub().Result.Value);
                }
            }
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var postresponse = await interactor.GetById(id);
            var commentsresponse = await commentInteractor.GetAllByPostId(id);
            var filesresponse = await fileInteractor.GetAllByPostId(id);
            if (postresponse == null)
            {
                return NotFound();
            }
            PostModel postModel = new PostModel()
            {
                Post = postresponse.Value,
                Comments = commentsresponse.Value.ToList(),
                Files = filesresponse.Value.ToList(),
            };
            return View(postModel);
        }
        public async Task<IActionResult> AddComment(string CommentContent, string CommentAuthorEmail, int CommentPostId)
        {
            UserDto Author = userInteractor.GetByEmail(CommentAuthorEmail).Result.Value;
            CommentDto newComment = new CommentDto() 
            { 
                PostId = CommentPostId,
                AuthorId = Author.Id,
                Content = CommentContent,
                CreatedAt = DateTime.Now,
            };
            await commentInteractor.Create(newComment);
            return RedirectToAction("Details", new { id = CommentPostId });
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,AuthorId,Title,Content,Tags,CreatedAt,BySub")] Post post, IFormFile[] files)
        {
            if (ModelState.IsValid)
            {
                if (!(User.IsInRole("admin") || User.IsInRole("moderator")))
                {
                    var user = await userInteractor.GetByEmail(User.Identity.Name);
                    post.AuthorId = user.Value.Id;
                    post.CreatedAt = DateTime.Now;
                }
                if (string.IsNullOrEmpty(post.Tags))
                { 
                    string output = new string(post.Tags
                            .Where((c, i) => c != ' ' || (i > 0 && post.Tags[i - 1] == '#' && i < post.Tags.Length - 1 && post.Tags[i + 1] == '#'))
                            .ToArray());
                    post.Tags = output;
                }
                _context.Add(post);
                await _context.SaveChangesAsync();

                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Storage", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        FileDto newFileToDB = new FileDto() 
                        {
                            PostId = post.Id,
                            FileName = fileName,
                            FilePath = filePath,
                        };

                        await fileInteractor.Create(newFileToDB);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name", post.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name", post.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,AuthorId,Title,Content,Tags,CreatedAt,BySub")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (string.IsNullOrEmpty(post.Tags))
                    {
                        string output = new string(post.Tags
                                .Where((c, i) => c != ' ' || (i > 0 && post.Tags[i - 1] == '#' && i < post.Tags.Length - 1 && post.Tags[i + 1] == '#'))
                                .ToArray());
                        post.Tags = output;
                    }
                    await interactor.Update(post.ToDto());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name", post.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }

        public IActionResult Download(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Storage", fileName);

            if (System.IO.File.Exists(filePath))
            {
                // Определяем MIME-тип файла
                string contentType = "application/octet-stream"; // Пример MIME-типа, можно дополнить соответствующими типами для различных файлов

                // Возвращаем файл для скачивания
                return PhysicalFile(filePath, contentType, fileName);
            }
            else
            {
                // Если файл не найден, возвращаем ошибку HTTP 404
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile[] files, int postId)
        {
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Storage", fileName);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                        await fileInteractor.DeleteByPath(filePath);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    FileDto newFile = new FileDto() {
                        PostId = postId,
                        FileName = fileName,
                        FilePath = filePath,
                    };

                    await fileInteractor.Create(newFile);
                }
            }

            return RedirectToAction("Details", new { id = postId });
        }
        public async Task<IActionResult> DeleteFile(string fileName, int postId)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Storage", fileName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                await fileInteractor.DeleteByPath(filePath);
            }

            // После удаления файла перенаправляем пользователя на нужную страницу или представление
            return RedirectToAction("Details", new { id = postId });
        }
		public async Task<IActionResult> My()
		{
			var response = await interactor.GetAllByAuthorEmail(User.Identity.Name);
			return View(response.Value);
		}
	}
}
