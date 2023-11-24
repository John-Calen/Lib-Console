namespace JC.Lib.Console.Query
{
    public class RepeatEnumearbleStatement<T_Key, T_Index> : OperationScope<T_Key>
        where T_Key: Enum
    {
        private readonly T_Key? key;
        private readonly IEnumerable<T_Index> counter;






        internal RepeatEnumearbleStatement(T_Key? key, IEnumerable<T_Index> counter, OperationScope<T_Key> parent, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(parent, consoleQueryBuilder)
        {
            this.counter = counter;
            this.key = key;
        }





        public override void Handle()
        {
            foreach (var i in counter)
            {
                if (key is not null)
                    consoleQueryBuilder.Storage.Set(key, i);

                base.Handle();
            }
        }
    }
}
