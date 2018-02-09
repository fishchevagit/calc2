namespace CalcLibrary
{
    public class OperResult : IOperationResult
    {
        public OperResult(double result, string error)
        {
            Result = result;
            Error = error;
        }

        public string Error { get; set; }

        public double Result { get; set; }
    }
}
