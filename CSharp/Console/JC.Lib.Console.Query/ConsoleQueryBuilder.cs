using Console.Abstractions;

namespace JC.Lib.Console.Query
{
    public class ConsoleQueryBuilder<T_Key>: IConsoleQueryBuilder<T_Key>
        where T_Key: Enum
    {
        public IConsoleService ConsoleService { get; }
        public IConsoleValueReadingService ConsoleValueReadingService { get; }
        public Storage<T_Key> Storage { get; }
        
        
        
        
        
        
        public ConsoleQueryBuilder(IConsoleService consoleService, IConsoleValueReadingService consoleValueReadingService, IReadOnlyDictionary<T_Key, object> additionalValues)
        {
            ConsoleService = consoleService;
            ConsoleValueReadingService = consoleValueReadingService;

            Storage = new Storage<T_Key>(additionalValues);
        }

        public ConsoleQueryBuilder(IConsoleService consoleService, IConsoleValueReadingService consoleValueReadingService)
        {
            ConsoleService = consoleService;
            ConsoleValueReadingService = consoleValueReadingService;

            Storage = new Storage<T_Key>();
        }





        public OperationScope<T_Key> Open()
        {
            return new MainScope<T_Key>(null, this);
        }
    }
}
