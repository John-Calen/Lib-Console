namespace JC.Lib.Console.Query
{
    public class RepeatConditionStatement<T_Key>: OperationScope<T_Key>
        where T_Key: Enum
    {
        private readonly Func<Storage<T_Key>, bool> condition;






        internal RepeatConditionStatement(Func<Storage<T_Key>, bool> condition, OperationScope<T_Key> parent, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(parent, consoleQueryBuilder)
        {
            this.condition = condition;
        }





        public override void Handle()
        {
            while (condition(consoleQueryBuilder.Storage))
                base.Handle();
        }
    }
}
