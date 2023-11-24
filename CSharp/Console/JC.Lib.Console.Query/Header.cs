namespace JC.Lib.Console.Query
{
    public class Header<T_Key> : AOperation<T_Key>
        where T_Key: Enum
    {
        public string Text { get; }
        
        
        
        
        
        
        internal Header(string text, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(consoleQueryBuilder)
        {
            Text = text;
        }






        public override void Handle()
        {
            var lines = new string('-', 100);

            var ofs = (lines.Length - Text.Length) / 2;
            if (ofs < 0)
                ofs = 0;

            var consoleService = consoleQueryBuilder.ConsoleService;

            consoleService.WriteStyledLine($"<f-r>{ lines }");
            consoleService.WriteStyledLine($"{ new string(' ', ofs) }{ Text }");
            consoleService.WriteStyledLine($"<f-r>{ lines }");
        }
    }
}
