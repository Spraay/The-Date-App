using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Service;
using DAO.Data;
using Entity;
using System;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class InterestController : Controller
    {
        
        private readonly IInterestService _interestService;

        public InterestController(
            IInterestService interest)
        {
            _interestService = interest;
        }

       
        // GET: Interests
        public IActionResult Index()
        {
            if (_interestService.Any()) return View(_interestService.GetList());
            return NotFound();
        }
        
        // GET: Interests/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id.HasValue) return View(_interestService.Get(id.Value) );
            return NotFound();
        }

        // GET: Interests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                _interestService.Add(interest.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        // GET: Interests/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id.HasValue) return View(_interestService.Get(id.Value) );
            return null;
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,Name")] Interest interest)
        {
            if (id != interest.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _interestService.Update(interest.ID, interest.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        // GET: Interests/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = _interestService.Get(id.Value);

            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _interestService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool InterestExists(Guid id)
        {
            return _interestService.GetList().Any(e => e.ID == id);
        }
    }
}
