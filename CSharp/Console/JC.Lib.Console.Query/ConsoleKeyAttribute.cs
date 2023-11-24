namespace JC.Lib.Console.Query
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ConsoleKeyAttribute: Attribute
    {
        public bool List { get; }
        
        
        
        
        
        
        public ConsoleKeyAttribute(bool list)
        {
            List = list;
        }
    }
}
