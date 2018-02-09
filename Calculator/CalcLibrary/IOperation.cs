namespace CalcLibrary
{
    /// <summary>
    /// Операция
    /// </summary>
    public interface IOperation
    {
        string Name { get; }

        /// <summary>
        /// Выполнить операцию с входными значениями
        /// </summary>
        /// <param name="args">Входные параметры</param>
        /// <returns>Результат операции</returns>
        IOperationResult Exec(string[] args);
    }
}
