namespace JC.Lib.Console.Query.Updaters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModelPropertyAttribute: Attribute
    {
        public string? Prefix { get; }
        public string? Sufix { get; }
        public ConsoleColor ForegroundText { get; }
        public ConsoleColor BackgroundText { get; }
        public ConsoleColor ForegroundValue { get; }
        public ConsoleColor BackgroundValue { get; }
        
        
        
        
        
        
        public ModelPropertyAttribute
        (
            string? prefix = null, 
            string? sufix = null, 
            ConsoleColor foregroundText = ConsoleColor.Gray, 
            ConsoleColor backgroundText = ConsoleColor.Black, 
            ConsoleColor foregroundValue = ConsoleColor.Gray, 
            ConsoleColor backgroundValue = ConsoleColor.Black
        )
        {
            Prefix = prefix;
            Sufix = sufix;
            ForegroundText = foregroundText;
            BackgroundText = backgroundText;
            ForegroundValue = foregroundValue;
            BackgroundValue = backgroundValue;
        }
    }
}
