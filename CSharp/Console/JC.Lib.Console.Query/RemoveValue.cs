namespace JC.Lib.Console.Query
{
    public class RemoveValue<T_Key>: AOperation<T_Key>
        where T_Key: Enum
    {
        public T_Key Key { get; }
        
        
        
        
        
        
        public RemoveValue(T_Key key, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(consoleQueryBuilder)
        {
            Key = key;
        }






        public override void Handle()
        {
            consoleQueryBuilder.Storage.Remove(Key);
        }
    }
}
