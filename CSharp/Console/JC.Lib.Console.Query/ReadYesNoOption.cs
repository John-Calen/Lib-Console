namespace JC.Lib.Console.Query
{
    public class ReadYesNoOption<T_Key> : ReadOption<T_Key, string>
        where T_Key: Enum
    {
        internal ReadYesNoOption(string text,string? description, T_Key key, IConsoleQueryBuilder<T_Key> consoleQueryBuilder)
            : base(text, description, key, (line) => line!.ToLower(), new string[] { "yes", "no" }, consoleQueryBuilder)
        {
        }
    }
}
