using MapOfTheProblematique.Models.DTOs;
using MapOfTheProblematque.Data;
using MapOfTheProblematque.Models;
using MapOfTheProblematque.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace MapOfTheProblematique.Controllers
{
    public class CascadeDropDown : Controller
    {
        private readonly ApplicationDbContext _context;
        public CascadeDropDown(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Classes = new SelectList(_context.StudyClass, "Id", "Name");
            return View();
        }  
        public JsonResult GetSubjects(int Id)
        { var subjects = _context.StudySubject.Where(s => s.StudyClassId == Id).ToList();

            return Json(subjects);
        }
        public JsonResult GetTopics(int Id)
        { var topics = _context.StudyTopic.Where(s => s.StudySubjectId == Id).ToList();

            return Json(topics);
        }
    }
}
