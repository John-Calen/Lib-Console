namespace JC.Lib.Console.Query
{
    public class MainScope<T_Key> : OperationScope<T_Key>
        where T_Key : Enum
    {
        internal MainScope(OperationScope<T_Key>? parent, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(parent, consoleQueryBuilder)
        {
        }





        public override void Handle()
        {
            consoleQueryBuilder.Storage.Clear();
            base.Handle();
        }
    }
}
