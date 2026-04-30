using DesignPatternsDay.ChainOfResponsibility;
using DesignPatternsDay.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer();
            Employee managerAssistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee areaDirectorAssistant= new AreaDirectorAssistant();
            Employee areaDirector= new AreaDirector();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirectorAssistant);
            areaDirectorAssistant.SetNextApprover(areaDirector);

            treasurer.ProcessRequest(model);
            return View();
        }
    }
}
