namespace CalcLibrary
{
    /// <summary>
    /// Результат операции
    /// </summary>
    public interface IOperationResult
    {
        double Result { get; set; }

        string Error { get; set; }
    }
}
