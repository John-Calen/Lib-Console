namespace JC.Lib.Console.Query
{
    public abstract class AOperation<T_Key>
        where T_Key: Enum
    {
        protected readonly IConsoleQueryBuilder<T_Key> consoleQueryBuilder;






        protected AOperation(IConsoleQueryBuilder<T_Key> consoleQueryBuilder)
        {
            this.consoleQueryBuilder = consoleQueryBuilder;
        }






        public abstract void Handle();
    }
}
