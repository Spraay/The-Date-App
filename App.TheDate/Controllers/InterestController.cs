using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using App.Repository.Abstract;
using App.Model.Entities;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class InterestController : Controller
    {
        
        private readonly IInterestRepository _interestRepository;

        public InterestController(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }




        // GET: Interests
        public IActionResult Index()
        {
            if (_interestRepository.Count()>0) return View(_interestRepository.GetAll());
            return NotFound();
        }
        
        // GET: Interests/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id.HasValue) return View(_interestRepository.GetSingle(_=>_.Id == id.Value) );
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
                _interestRepository.Add(interest);
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        // GET: Interests/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id.HasValue) return View(_interestRepository.GetSingle(_ => _.Id == id.Value));
            return null;
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,Name")] Interest interest)
        {
            if (id != interest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _interestRepository.Update(interest);
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

            var interest = _interestRepository.GetSingle(_ => _.Id == id.Value);

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
            _interestRepository.DeleteWhere(_=>_.Id == id);
            return RedirectToAction(nameof(Index));
        }

        private bool InterestExists(Guid id)
        {
            return _interestRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
