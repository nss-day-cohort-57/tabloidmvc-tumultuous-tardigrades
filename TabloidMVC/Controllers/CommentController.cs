using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
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
            
           Comment comment = _commentRepo.GetCommentById(id);
            if (comment == null)
            {
                NotFound();
            }
         
            return View(comment);
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Comment comment)
        {
            try
            {
                _commentRepo.UpdateComment(comment);
                return RedirectToAction("Index", new { id = comment.PostId });
            }
            catch(Exception)
            {
                return View(comment);
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            Comment comment = _commentRepo.GetCommentById(id);
            return View(comment);
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Comment comment)
        {
            try
            {
                int postId = _commentRepo.GetCommentById(id).PostId;
                _commentRepo.DeleteComment(id);
                return RedirectToAction("Index", new { id = postId });
            }
            catch(Exception)
            {
                return View(comment);
            }
        }

        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
