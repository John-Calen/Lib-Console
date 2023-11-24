namespace JC.Lib.Console.Query
{
    public class IfStatement<T_Key>: OperationScope<T_Key>
        where T_Key: Enum
    {
        private readonly Func<Storage<T_Key>, bool> condition;
        private OperationScope<T_Key>? onConditionFalse = null;






        internal IfStatement(Func<Storage<T_Key>, bool> condition, OperationScope<T_Key> parent, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(parent, consoleQueryBuilder)
        {
            this.condition = condition;
        }





        public IfStatement<T_Key> ElseIf(Func<Storage<T_Key>, bool> condition)
        {
            var statement = new IfStatement<T_Key>(condition, this, consoleQueryBuilder);
            onConditionFalse = statement;
            
            return statement;
        }

        public OperationScope<T_Key> Else()
        {
            var statement = new OperationScope<T_Key>(this, consoleQueryBuilder);
            onConditionFalse = statement;

            return statement;
        }

        public override void Handle()
        {
            if (condition(consoleQueryBuilder.Storage))
                base.Handle();

            else
                onConditionFalse?.Handle();
        }
    }
}
