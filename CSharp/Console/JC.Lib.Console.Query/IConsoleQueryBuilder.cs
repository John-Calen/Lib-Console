using Console.Abstractions;

namespace JC.Lib.Console.Query
{
    public interface IConsoleQueryBuilder<T_Key>
        where T_Key: Enum
    {
        public abstract IConsoleService ConsoleService { get; }
        public abstract IConsoleValueReadingService ConsoleValueReadingService { get; }
        public abstract Storage<T_Key> Storage { get; }
    }
}
