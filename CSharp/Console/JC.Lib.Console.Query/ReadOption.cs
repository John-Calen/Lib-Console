using System.Text;

namespace JC.Lib.Console.Query
{
    public class ReadOption<T_Key, T_Value> : ReadValue<T_Key, T_Value>
        where T_Key: Enum
    {
        public IReadOnlyList<T_Value> Options { get; }
        public bool HasDefaultOption { get; }
        public T_Value DefaultOption { get; } = default!;






        internal ReadOption(string text, string? description, T_Key key, Func<string?, T_Value> converter, IEnumerable<T_Value> options, IConsoleQueryBuilder<T_Key> consoleQueryBuilder)
            : this(text, description, key, converter, options, default, false, consoleQueryBuilder)
        {
            Options = options.ToArray();
        }

        internal ReadOption(string text, string? description, T_Key key, Func<string?, T_Value> converter, IEnumerable<T_Value> options, T_Value defaultOption, IConsoleQueryBuilder<T_Key> consoleQueryBuilder)
            : this(text, description, key, converter, options, defaultOption, true, consoleQueryBuilder) { }

        protected ReadOption
        (
            string text,
            string? description,
            T_Key key, 
            Func<string?, T_Value> converter, 
            IEnumerable<T_Value> options,
            T_Value defaultOption,
            bool hasDefaultOption,
            IConsoleQueryBuilder<T_Key> consoleQueryBuilder
        )
            : base(text, description, key, converter, consoleQueryBuilder)
        {
            Options = options.ToArray();
            HasDefaultOption = hasDefaultOption;
            DefaultOption = defaultOption;
        }






        public override void Handle()
        {
            if (Desciption is not null)
                consoleQueryBuilder.ConsoleService.WriteStyledLine(Desciption);

            var optionsBuilder = new StringBuilder();
            foreach (var option in Options)
            {
                if (HasDefaultOption && Equals(option, DefaultOption))
                    optionsBuilder.AppendLine($"   <f-y>{ option }<f-dc>(default)");

                else
                    optionsBuilder.AppendLine($"   <f-y>{ option }");
            }

            var optionsString = optionsBuilder.ToString();
            consoleQueryBuilder.ConsoleService.WriteStyledLine($"Available options:\n{ optionsString }");

            var excMessage = null as string;
            while (true)
            {
                var value = Read();
                if (value is null && HasDefaultOption)
                {
                    consoleQueryBuilder.Storage.TryAdd(Key, DefaultOption);
                    break;
                }

                else if (Options.Contains(value))
                {
                    consoleQueryBuilder.Storage.TryAdd(Key, value);
                    break;
                }

                else
                {
                    if (excMessage is null)
                    {
                        var builder = new StringBuilder("<f-r>Value is not one of the options.\n<f-gy>Avaiable options:\n<f-y>");
                        builder.Append(optionsString);

                        excMessage = builder.ToString();
                    }

                    consoleQueryBuilder.ConsoleService.WriteStyledLine(excMessage);
                }
            }
        }
    }
}
