using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabloidMVC.Models;
using TabloidMVC.Repositories;
using System;

namespace TabloidMVC.Controllers
{
    public class SubscriptionController : Controller
    {

        private readonly ISubscriptionRepository _subscriptionRepo;
        public SubscriptionController(ISubscriptionRepository subscriptionRepo)
        {
            _subscriptionRepo = subscriptionRepo;
        }

        // GET: SubscriptionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubscriptionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubscriptionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subscription subscription)
        {
            try
            {
                subscription.BeginDateTime = DateTime.Now;

                _subscriptionRepo.AddSubscription(subscription);
                return RedirectToAction("Details", "Post");
            }
            catch(Exception)
            {
                return View(subscription);
            }
        }

        // GET: SubscriptionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubscriptionController/Edit/5
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

        // GET: SubscriptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubscriptionController/Delete/5
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
    }
}
