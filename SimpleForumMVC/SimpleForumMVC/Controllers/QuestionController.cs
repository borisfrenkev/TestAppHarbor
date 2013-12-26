using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleForumMVC.Models;
using SimpleForumMVC.Data;
using System.Web.Security;

namespace SimpleForumMVC.Controllers
{
    public class QuestionController : Controller
    {
        private ForumContext db = new ForumContext();
        private int pageSize = 10;

        // GET: /Question/
        public ActionResult Index(int? page)
        {
            int pageCurr=page!=null?(int)page:1;
   
            var questions = db.Questions.Include(q => q.ApplicationUser).Include(q => q.Category)
                .OrderBy(q=>q.LastAnswerDate).Skip((pageCurr-1)*pageSize).Take(pageSize);
            PagingInfo pageInfo = new PagingInfo
            {   
                CurrentPage=pageCurr,
                TotalItems=db.Questions.Count(),
                ItemsPerPage=pageSize
                
            };
            ViewBag.PageInfo = pageInfo;

            return View(questions);
        }

        // GET: /Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: /Question/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName");
            var categories = db.Categories.OrderBy(c => c.Name);
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: /Question/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                question.CreationDate = DateTime.Now;
                question.LastAnswerDate = DateTime.Now;
                string currentUserName = User.Identity.Name;
                ApplicationUser appUser = db.Users.Where(x => x.UserName == currentUserName).FirstOrDefault();
                question.ApplicationUser = appUser;
                question.LastApplicationUser = appUser;
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            var categories = db.Categories.OrderBy(c => c.Name);
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            return View(question);
        }

        // GET: /Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName", question.ApplicationUserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", question.CategoryId);
            return View(question);
        }

        // POST: /Question/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName", question.ApplicationUserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", question.CategoryId);
            return View(question);
        }

        // GET: /Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: /Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
