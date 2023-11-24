using JC.Lib.Exceptions;

namespace JC.Lib.Console.Query
{
    public class OperationScope<T_Key>: AOperation<T_Key>
        where T_Key: Enum
    {
        public OperationScope<T_Key>? Parent { get; }
        private readonly Queue<AOperation<T_Key>> operations = new();
        protected bool Opened { get; private set; }






        internal OperationScope(OperationScope<T_Key>? parent, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(consoleQueryBuilder)
        {
            Parent = parent;
        }






        private Func<string?, byte> ByteConverter()
        {
            return (line) => byte.Parse(line!);
        }

        private Func<string?, sbyte> SByteConverter()
        {
            return (line) => sbyte.Parse(line!);
        }

        private Func<string?, short> ShortConverter()
        {
            return (line) => short.Parse(line!);
        }

        private Func<string?, ushort> UShortConverter()
        {
            return (line) => ushort.Parse(line!);
        }

        private Func<string?, int> IntConverter()
        {
            return (line) => int.Parse(line!);
        }

        private Func<string?, uint> UIntConverter()
        {
            return (line) => uint.Parse(line!);
        }

        private Func<string?, long> LongConverter()
        {
            return (line) => long.Parse(line!);
        }

        private Func<string?, ulong> ULongConverter()
        {
            return (line) => ulong.Parse(line!);
        }

        private Func<string?, float> FloatConverter()
        {
            return (line) => float.Parse(line!);
        }

        private Func<string?, double> DoubleConverter()
        {
            return (line) => double.Parse(line!);
        }

        private Func<string?, char> CharConverter()
        {
            return (line) =>
            {
                if (line?.Length is 1)
                    return line[0];

                throw new CausedException.Builder()
                    .SetMessage("entered not a char")
                    .AddCauseValue(nameof(line), line)
                    .Build();
            };
        }

        private Func<string?, string> StringConverter()
        {
            return (line) => line!;
        }

        private Func<string?, bool> BoolConverter()
        {
            return (line) => bool.Parse(line!);
        }

        public OperationScope<T_Key> ReadByte(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, ByteConverter());
        }

        public OperationScope<T_Key> ReadSByte(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, SByteConverter());
        }

        public OperationScope<T_Key> ReadShort(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, ShortConverter());
        }

        public OperationScope<T_Key> ReadUShort(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, UShortConverter());
        }

        public OperationScope<T_Key> ReadInt(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, IntConverter());
        }

        public OperationScope<T_Key> ReadUInt(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, UIntConverter());
        }

        public OperationScope<T_Key> ReadLong(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, LongConverter());
        }

        public OperationScope<T_Key> ReadULong(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, ULongConverter());
        }

        public OperationScope<T_Key> ReadFloat(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, FloatConverter());
        }

        public OperationScope<T_Key> ReadDouble(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, DoubleConverter());
        }

        public OperationScope<T_Key> ReadChar(string text, string? description, T_Key storeAs)
        {
            return Read
            (
                text, 
                description,
                storeAs, 
                CharConverter()
            );
        }

        public OperationScope<T_Key> ReadBool(string text, string? description, T_Key storeAs)
        {
            return Read(text, description, storeAs, BoolConverter());
        }

        public OperationScope<T_Key> ReadString(string text, string? description, T_Key storeAs)
        {
            var read = new ReadValue<T_Key, string>(text, description, storeAs, StringConverter(), consoleQueryBuilder);
            operations.Enqueue(read);

            return GetScope();
        }

        public OperationScope<T_Key> Read<T_Read>(string text, string? description, T_Key storeAs, Func<string?, T_Read> converter)
        {
            var read = new ReadValue<T_Key, T_Read>(text, description, storeAs, converter, consoleQueryBuilder);
            operations.Enqueue(read);

            return GetScope();
        }

        public OperationScope<T_Key> ReadOption<T_Read>(string text, string? description, T_Key storeAs, Func<string?, T_Read> converter, IEnumerable<T_Read> options)
        {
            var read = new ReadOption<T_Key, T_Read>(text, description, storeAs, converter, options, consoleQueryBuilder);
            operations.Enqueue(read);

            return GetScope();
        }

        public OperationScope<T_Key> ReadByteOption(string text, string? description, T_Key storeAs, IEnumerable<byte> options)
        {
            return ReadOption(text, description, storeAs, ByteConverter(), options);
        }

        public OperationScope<T_Key> ReadSByteOption(string text, string? description, T_Key storeAs, IEnumerable<sbyte> options)
        {
            return ReadOption(text, description, storeAs, SByteConverter(), options);
        }

        public OperationScope<T_Key> ReadShortOption(string text, string? description, T_Key storeAs, IEnumerable<short> options)
        {
            return ReadOption(text, description, storeAs, ShortConverter(), options);
        }

        public OperationScope<T_Key> ReadUShortOption(string text, string? description, T_Key storeAs, IEnumerable<ushort> options)
        {
            return ReadOption(text, description, storeAs, UShortConverter(), options);
        }

        public OperationScope<T_Key> ReadIntOption(string text, string? description, T_Key storeAs, IEnumerable<int> options)
        {
            return ReadOption(text, description, storeAs, IntConverter(), options);
        }

        public OperationScope<T_Key> ReadUIntOption(string text, string? description, T_Key storeAs, IEnumerable<uint> options)
        {
            return ReadOption(text, description, storeAs, UIntConverter(), options);
        }

        public OperationScope<T_Key> ReadLongOption(string text, string? description, T_Key storeAs, IEnumerable<long> options)
        {
            return ReadOption(text, description, storeAs, LongConverter(), options);
        }

        public OperationScope<T_Key> ReadULongOption(string text, string? description, T_Key storeAs, IEnumerable<ulong> options)
        {
            return ReadOption(text, description, storeAs, ULongConverter(), options);
        }

        public OperationScope<T_Key> ReadFloatOption(string text, string? description, T_Key storeAs, IEnumerable<float> options)
        {
            return ReadOption(text, description, storeAs, FloatConverter(), options);
        }

        public OperationScope<T_Key> ReadDoubleOption(string text, string? description, T_Key storeAs, IEnumerable<double> options)
        {
            return ReadOption(text, description, storeAs, DoubleConverter(), options);
        }

        public OperationScope<T_Key> ReadCharOption(string text, string? description, T_Key storeAs, IEnumerable<char> options)
        {
            return ReadOption(text, description, storeAs, CharConverter(), options);
        }

        public OperationScope<T_Key> ReadBoolOption(string text, string? description, T_Key storeAs, IEnumerable<bool> options)
        {
            return ReadOption(text, description, storeAs, (line) => bool.Parse(line!), options);
        }

        public OperationScope<T_Key> ReadStringOption(string text, string? description, T_Key storeAs, IEnumerable<string> options)
        {
            return ReadOption(text, description, storeAs, (line) => line!, options);
        }

        public RepeatEnumearbleStatement<T_Key, T_Index> Repeat<T_Index>(T_Key key, IEnumerable<T_Index> counter)
        {
            var repeat = new RepeatEnumearbleStatement<T_Key, T_Index>(key, counter, this, consoleQueryBuilder);
            operations.Enqueue(repeat);

            return repeat;
        }

        public RepeatConditionStatement<T_Key> Repeat(Func<Storage<T_Key>, bool> condition)
        {
            var repeat = new RepeatConditionStatement<T_Key>(condition, this, consoleQueryBuilder);
            operations.Enqueue(repeat);

            return repeat;
        }

        public RepeatStatement<T_Key> Repeat()
        {
            var repeat = new RepeatStatement<T_Key>(this, consoleQueryBuilder);
            operations.Enqueue(repeat);

            return repeat;
        }

        public IfStatement<T_Key> If(Func<Storage<T_Key>, bool> condition)
        {
            var ifStatement = new IfStatement<T_Key>(condition, this, consoleQueryBuilder);
            operations.Enqueue(ifStatement);

            return ifStatement;
        }

        public OperationScope<T_Key> Action(Action<Storage<T_Key>> body)
        {
            var action = new ActionOperation<T_Key>(body, consoleQueryBuilder);
            operations.Enqueue(action);

            return GetScope();
        }


        /// <summary>
        /// Consumes a lot of time and displays a lot of information into console
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public OperationScope<T_Key> HeavyAction<T_Model>(Action<Storage<T_Key>, T_Model> body, TimeSpan updateDelay)
            where T_Model : notnull, new()
        {
            var action = new HeavyActionOperation<T_Key, T_Model>(body, updateDelay, consoleQueryBuilder);
            operations.Enqueue(action);

            return GetScope();
        }

        public OperationScope<T_Key> Header(string text)
        {
            var header = new Header<T_Key>(text, consoleQueryBuilder);
            operations.Enqueue(header);

            return GetScope();
        }

        public OperationScope<T_Key> PrintValue(string text, T_Key key)
        {
            var print = new PrintValue<T_Key>(text, key, consoleQueryBuilder);
            operations.Enqueue(print);

            return GetScope();
        }

        public OperationScope<T_Key> SetValue<T_Value>(T_Key key, T_Value value)
        {
            var set = new SetValue<T_Key, T_Value>(key, value, consoleQueryBuilder);
            operations.Enqueue(set);

            return GetScope();
        }

        public OperationScope<T_Key> RemoveValue<T_Value>(T_Key key)
        {
            var set = new RemoveValue<T_Key>(key, consoleQueryBuilder);
            operations.Enqueue(set);

            return GetScope();
        }

        public OperationScope<T_Key> OpenScope()
        {
            Opened = true;
            return this;
        }

        public OperationScope<T_Key> CloseScope()
        {
            Opened = false;
            return Parent!;
        }

        public override void Handle()
        {
            foreach (var operation in operations)
                operation.Handle();
        }

        private OperationScope<T_Key> GetScope()
        {
            return Opened ? this : (Parent ?? this);
        }
    }
}
