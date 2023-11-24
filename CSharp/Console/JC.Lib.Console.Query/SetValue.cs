namespace JC.Lib.Console.Query
{
    public class SetValue<T_Key, T_Value>: AOperation<T_Key>
        where T_Key: Enum
    {
        public T_Key Key { get; }
        public T_Value Value { get; }
        
        
        
        
        
        
        public SetValue(T_Key key, T_Value value, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(consoleQueryBuilder)
        {
            Key = key;
            Value = value;
        }






        public override void Handle()
        {
            consoleQueryBuilder.Storage.Set(Key, Value);
        }
    }
}
