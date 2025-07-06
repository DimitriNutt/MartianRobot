using MartianRobot.Pages.PartialViews;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MartianRobot.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            MartianRobot = new MartianRobotModel
            {
                Input = string.Empty
            };
        }

        public MartianRobotModel MartianRobot { get; set; }

        public void OnGet()
        {
            MartianRobot = new MartianRobotModel
            {
                Input = string.Empty
            };
        }

        public void OnPost()
        {
            if (Request.Form.ContainsKey("Input"))
            {
                MartianRobot.Input = Request.Form["Input"]!;
                if (!string.IsNullOrWhiteSpace(MartianRobot.Input))
                {
                    MartianRobot.Output = MartianRobotRunner.Run(MartianRobot.Input);
                }
            }
        }
    }
}
