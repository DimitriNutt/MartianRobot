using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MartianRobot.Pages.PartialViews
{
    public class MartianRobotModel : PageModel
    {
        [BindProperty]
        public required string Input { get; set; }
        public string? Output { get; set; }

        public void OnGet() { }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Input))
            {
                Output = MartianRobotRunner.Run(Input);
            }
        }
    }
}