namespace JC.Lib.Console.Query
{
    public class ActionOperation<T_Key>: AOperation<T_Key>
        where T_Key : Enum
    {
        private readonly Action<Storage<T_Key>> body;






        internal ActionOperation(Action<Storage<T_Key>> body, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(consoleQueryBuilder)
        {
            this.body = body;
        }






        public override void Handle()
        {
            body(consoleQueryBuilder.Storage);
        }
    }
}
