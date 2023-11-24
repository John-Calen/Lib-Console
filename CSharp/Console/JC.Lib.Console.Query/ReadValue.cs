namespace JC.Lib.Console.Query
{
    public class ReadValue<T_Key, T_Value> : AOperation<T_Key>
        where T_Key: Enum
    {
        public string Text { get; }
        public string? Desciption { get; }
        public T_Key Key { get; }
        private readonly Func<string?, T_Value> converter;






        internal ReadValue(string text, string? description, T_Key key, Func<string?, T_Value> converter, IConsoleQueryBuilder<T_Key> consoleQueryBuilder): base(consoleQueryBuilder)
        {
            Text = text;
            Key = key;
            Desciption = description;
            this.converter = converter;
        }






        public override void Handle()
        {
            if (Desciption is not null)
                consoleQueryBuilder.ConsoleService.WriteStyledLine(Desciption);
            
            var value = Read();
            consoleQueryBuilder.Storage.TryAdd(Key, value);
        }

        protected T_Value? Read()
        {
            while (true)
            {
                try
                {
                    return consoleQueryBuilder.ConsoleValueReadingService.Read(Text, converter);
                }

                catch (Exception exc)
                {
                    consoleQueryBuilder.ConsoleService.WriteStyledLine($"<f-r>Couldn't read. Perhaps input line format is incorrent.\n<f-m>{ exc.Message }\n");
                }
            }
        }
    }
}
