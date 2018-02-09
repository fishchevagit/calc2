using CalcConsole;
using CalcDB.Models;
using CalcDB.NHibernate.Repositories;
using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {

        #region Protected Members

        protected IOperationRepository OperationRepository { get; set; }

        protected IOperResultRepository OperationResultRepository { get; set; }

        protected IUserRepository UserRepository { get; set; }

        protected Calc Calc { get; set; }

        #endregion

        public CalcController()
        {
            OperationRepository = new NHOperationRepository();
            OperationResultRepository = new NHOperResultRepository();
            UserRepository = new NHUserRepository();
            Calc = new Calc();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new CalcModel()
            {
                Operations = Calc.GetOperationNames()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Exec(string operation, string args)
        {
            if (string.IsNullOrWhiteSpace(args))
            {
                return Content("Укажите входные данные");
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var result = Calc.Exec(operation, args.Split(new[] { ' ', ',' }));

            stopWatch.Stop();

            #region Сохранение в БД
            var oper = OperationRepository.GetOrCreate(operation);
            var curUser = UserRepository.GetByLogin(User.Identity.Name);

            var or = new OperationResult()
            {
                Operation = oper,
                Result = result,
                ExecutionTime = stopWatch.ElapsedMilliseconds,
                Error = "",
                Args = args.Trim(),
                CreationDate = DateTime.Now,
                Author = curUser
            };

            OperationResultRepository.Save(or);

            #endregion

            return PartialView("Result", or);
        }

        [Authorize(Roles = "admin,user")]
        public ActionResult History()
        {
            return View(OperationResultRepository.GetByUsername(User.Identity.Name));
        }
    }
}