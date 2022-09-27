using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;
using TabloidMVC.Repositories;

namespace TabloidMVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IPostRepository _postRepo;

        public CommentController(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepo = commentRepository;
            _postRepo = postRepository;
        }
        // GET: CommentController
        public ActionResult Index(int id)
        {
            Post post = _postRepo.GetPublishedPostById(id);

            ViewCommentsViewModel vm = new ViewCommentsViewModel()
            {
                PostId = post.Id,
                PostTitle = post.Title,
                Comments = _commentRepo.GetCommentsByPostId(id)
            };

            return View(vm);
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentController/Create
        public ActionResult Create(int id)
        {
            Comment comment = new Comment() { PostId = id };

            return View(comment);
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Comment comment)
        {
            try
            {
                comment.CreateDateTime = DateTime.Now;
                comment.UserProfile = new UserProfile() { Id = GetCurrentUserProfileId() };
                comment.PostId = id;

                _commentRepo.AddComment(comment);

                return RedirectToAction("Details", "Post", new {id = comment.PostId});
            }
            catch
            {
                return View(comment);
            }
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
