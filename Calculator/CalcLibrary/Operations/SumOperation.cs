using System.Collections.Generic;
using System.Linq;

namespace CalcLibrary.Operations
{
    public class SumOperation : NumberOperation
    {
        public override string Name => "sum";

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            return new OperResult(args.Sum(), null);
        }
    }
}
