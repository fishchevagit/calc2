using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcLibrary.Operations
{
    public class SqrtOperation : NumberOperation
    {
        public override string Name => "sqrt";

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            return new OperResult(Math.Sqrt(args.FirstOrDefault()), null);
        }
    }
}
