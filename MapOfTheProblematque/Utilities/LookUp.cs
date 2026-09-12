using Microsoft.AspNetCore.Mvc.Rendering;

namespace MapOfTheProblematque.Utilities
{
    public class LookUp
    {
        public static List<SelectListItem> GetProblemTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Puzzle" },
                new SelectListItem { Value = "2", Text = "Riddle" },
                new SelectListItem { Value = "3", Text = "Crossword" },
                new SelectListItem { Value = "4", Text = "Theory" }
            };
        }
    }
}
