using CalcDB.Models;
using CalcDB.Repositories;
using System.Web.Mvc;
using System.Linq;
using WebCalc.Models;
using CalcDB.NHibernate.Repositories;

namespace WebCalc.Controllers
{
    [Authorize]
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Index()
        {
            var operationRepository = new NHBaseRepository<Operation>();
            var dbOperations = operationRepository.GetAll();
            var operations = dbOperations.Select(o => new OperationViewModel()
            {
                Id = o.Id,
                Name = o.Name,
                OwnerId = o.Owner.Id
            });

            return View(operations);
        }
    }
}