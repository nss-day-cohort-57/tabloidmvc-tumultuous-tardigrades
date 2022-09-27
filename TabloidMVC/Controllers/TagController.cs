using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TabloidMVC.Repositories;
using TabloidMVC.Models;
using System;


namespace TabloidMVC.Controllers
{
    public class TagController : Controller
    {
        // GET: TagController
        public ActionResult Index()
        {
            List<Tag> tags = _tagRepo.GetAll();
            return View(tags);
        }

        // GET: TagController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            try
            {
                _tagRepo.AddTag(tag);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Edit/5
        public ActionResult Edit(int id)
        {
            Tag tags = _tagRepo.GetTagById(id);
            return View(tags);

        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tag tag)
        {
            try
            {
                _tagRepo.UpdateTag(tag);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(tag);
            }
        }

        // GET: TagController/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: TagController/Delete/5
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

        private readonly ITagRepository _tagRepo;
        public TagController(ITagRepository tagRepository)
        {
            _tagRepo = tagRepository;
        }
    }
}
