using MapOfTheProblematique.Models.DTOs;
using MapOfTheProblematque.Data;
using MapOfTheProblematque.Models;
using MapOfTheProblematque.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MapOfTheProblematque.Controllers
{
    public class ProblemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProblemController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index(string Name, string Description, string Category, int CountryId)
        {

            var problems = _context.Problem.Include(c => c.Country).AsQueryable();
            if (!string.IsNullOrEmpty(Name))
            {
                problems = problems.Where(p => p.Name.Contains(Name));
            }
            if (!string.IsNullOrEmpty(Description))
            {
                problems = problems.Where(p => p.Description.Contains(Description));
            }
            if (!string.IsNullOrEmpty(Category))
            {
                problems = problems.Where(p => p.Category == Category);

            }
            if (CountryId != 0)
            {
                problems = problems.Where(p => p.CountryId == CountryId);
            }

            var problemTypes = LookUp.GetProblemTypes();


            ViewBag.ProblemType = new SelectList(problemTypes, "Value", "Text");
            ViewBag.Countries = new SelectList(_context.Country, "Id", "Name");

            return View(problems.ToList());
        }



        public IActionResult Create()
        {
            var problemTypes = LookUp.GetProblemTypes();


            ViewBag.ProblemType = new SelectList(problemTypes, "Value", "Text");
            ViewBag.Countries = new SelectList(_context.Country, "Id", "Name");
            return View();
        }



        [HttpPost]
        public IActionResult Create(Problem problem)
        {
            if (ModelState.IsValid)
            {

                _context.Add(problem);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));


            }
            var problemTypes = LookUp.GetProblemTypes();

            ViewBag.ProblemType = new SelectList(problemTypes, "Value", "Text");
            ViewBag.Countries = new SelectList(_context.Country, "Id", "Name");

            return View(problem);
        }
        public IActionResult Email()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Email(EmailDto model)
        {
            var mail = new Email(model.To, model.Subject, model.Body);
            mail.Send();

            return View(mail);
        }
        public IActionResult Edit(int? id)
        {
            var problemTypes = LookUp.GetProblemTypes();


            ViewBag.ProblemType = new SelectList(problemTypes, "Value", "Text");
            ViewBag.Countries = new SelectList(_context.Country, "Id", "Name");
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var problem = _context.Problem.Find(id);
            if (problem == null)
            {
                return RedirectToAction(nameof(Index));
            }


            return View(problem);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Problem problem)
        {
            var problemTypes = LookUp.GetProblemTypes();


            ViewBag.ProblemType = new SelectList(problemTypes, "Value", "Text");
            ViewBag.Country = new SelectList(_context.Country, "Id", "Name");
            if (id != problem.Id)
            {
                return RedirectToAction(nameof(Index));


            }
            if (ModelState.IsValid)
            {
                try
                {
                    var existingProblem = _context.Problem.FirstOrDefault(o => o.Name == problem.Name && o.Id != problem.Id);
                    if (existingProblem != null)
                    {
                        ModelState.AddModelError("Id", "A problem with this Name already exists");
                        return View(problem);

                    }
                    _context.Update(problem);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction(nameof(Index));//placeholder?

                }


            }


            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Recursion(int number)
        //{
        //    recursion.recursion(number);
        //    int factorialResult = recursion.ReverseCountFactorialRecursion(5);
        //    int sumResult = recursion.SumOfHunderd(100);
        //    ViewBag.FactorialResult = factorialResult;
        //    ViewBag.SumResult = sumResult;
        //    return View();
        //}
        public IActionResult Delete(int id)
        {
            var problem = _context.Problem.Find(id);
            if (problem != null)
            {
                _context.Problem.Remove(problem);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetCities(int CountryId)
        {
            var cities = _context.City.Where(c => c.Country.Id == CountryId).Select(c => new { c.Id, c.Name }).ToList();
            return Json(cities);

        }
        public async Task<JsonResult> IsProblemAvailable(string Name, int? id)
        {
            var problem = await _context.Problem.FirstOrDefaultAsync(o => o.Name == Name && o.Id != id);
            if (problem == null)
            {
                return Json(true);
            }

            else
            {
                return Json($"A problem with this Name already exists.");

            }


        }
    }
       
}
