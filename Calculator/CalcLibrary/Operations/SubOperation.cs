using System.Collections.Generic;
using System.Linq;

namespace CalcLibrary.Operations
{
    public class SubOperation : NumberOperation
    {
        public override string Name => "sub";

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            return new OperResult(args.Aggregate((a, b) => a - b), null);
        }
    }
}
