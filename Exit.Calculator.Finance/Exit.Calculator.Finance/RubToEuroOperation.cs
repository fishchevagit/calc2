using CalcLibrary.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using CalcLibrary;

namespace Exit.Calculator.Finance
{
    public class RubToEuroOperation : NumberOperation
    {
        public override string Name
        {
            get { return "ru2euro"; }
        }

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            if (args.Count() == 0)
            {
                return new OperResult(double.NaN, "Не указана сумма в рублях");
            }

            var ruble = args.First();
            // todo : сделать запрос на какой-нибудь сайт
            return new OperResult(ruble * new Random().Next(58, 65), "");
        }

    }
}
