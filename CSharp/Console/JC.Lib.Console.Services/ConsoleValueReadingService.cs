using Console.Abstractions;
using JC.Lib.Exceptions;

namespace JC.Lib.Console.Services
{
    public class ConsoleValueReadingService : IConsoleValueReadingService
    {
        private readonly IConsoleService consoleService;





        public ConsoleValueReadingService(IConsoleService consoleService)
        {
            this.consoleService = consoleService;
        }






        public T_Value? Read<T_Value>(string requestValueText, IEnumerable<T_Value> values, Func<string?, T_Value> converter, Func<T_Value, T_Value, bool>? equlaityComparer = null)
        {
            var comparer = equlaityComparer ?? new Func<T_Value, T_Value, bool>((value_0, value_1) => Equals(value_0, value_1));
            var value = Read(requestValueText, converter)!;

            foreach (var v in values)
            {
                if (comparer(value, v))
                    return v;
            }

            return default;
        }

        public byte? Read(string requestValueText, IEnumerable<byte> values)
        {
            return Read(requestValueText, values, (line) => byte.Parse(line!));
        }

        public sbyte? Read(string requestValueText, IEnumerable<sbyte> values)
        {
            return Read(requestValueText, values, (line) => sbyte.Parse(line!));
        }

        public short? Read(string requestValueText, IEnumerable<short> values)
        {
            return Read(requestValueText, values, (line) => short.Parse(line!));
        }

        public ushort? Read(string requestValueText, IEnumerable<ushort> values)
        {
            return Read(requestValueText, values, (line) => ushort.Parse(line!));
        }

        public int? Read(string requestValueText, IEnumerable<int> values)
        {
            return Read(requestValueText, values, (line) => int.Parse(line!));
        }

        public uint? Read(string requestValueText, IEnumerable<uint> values)
        {
            return Read(requestValueText, values, (line) => uint.Parse(line!));
        }

        public long? Read(string requestValueText, IEnumerable<long> values)
        {
            return Read(requestValueText, values, (line) => long.Parse(line!));
        }

        public ulong? Read(string requestValueText, IEnumerable<ulong> values)
        {
            return Read(requestValueText, values, (line) => ulong.Parse(line!));
        }

        public float? Read(string requestValueText, IEnumerable<float> values)
        {
            return Read(requestValueText, values, (line) => float.Parse(line!));
        }

        public double? Read(string requestValueText, IEnumerable<double> values)
        {
            return Read(requestValueText, values, (line) => double.Parse(line!));
        }

        public char? Read(string requestValueText, IEnumerable<char> values)
        {
            return Read
            (
                requestValueText,
                values,
                (line) =>
                {
                    if (line?.Length is 1)
                        return line[0];

                    else
                    {
                        throw new CausedException.Builder()
                            .SetMessage("Invalid line to treat it like a char")
                            .AddCauseValue(nameof(line), line)
                            .Build();
                    }
                }
            );
        }

        public string? Read(string requestValueText, IEnumerable<string> values)
        {
            return Read(requestValueText, values, (line) => line!);
        }

        public bool? Read(string requestValueText)
        {
            return Read(requestValueText, new bool[] { true, false }, (line) => bool.Parse(line!));
        }

        public T_Value? Read<T_Value>(string requestValueText, Func<string?, T_Value> converter)
        {
            if (requestValueText.TrimEnd().LastIndexOf(':') != requestValueText.Length - 1)
                requestValueText = requestValueText + ": ";

            consoleService.WriteStyled(requestValueText);

            var line = consoleService.ReadLine();
            var value = converter(line);

            return value;
        }

        public byte? ReadByte(string requestValueText)
        {
            return Read(requestValueText, (line) => byte.Parse(line!));
        }

        public char? ReadChar(string requestValueText)
        {
            return Read
            (
                requestValueText,
                (line) =>
                {
                    if (line?.Length is 1)
                        return line[0];

                    else
                    {
                        throw new CausedException.Builder()
                            .SetMessage("Invalid line to treat it like a char")
                            .AddCauseValue(nameof(line), line)
                            .Build();
                    }
                }
            );
        }

        public double? ReadDouble(string requestValueText)
        {
            return Read(requestValueText, (line) => double.Parse(line!));
        }

        public float? ReadFloat(string requestValueText)
        {
            return Read(requestValueText, (line) => float.Parse(line!));
        }

        public int? ReadInt(string requestValueText)
        {
            return Read(requestValueText, (line) => string.IsNullOrEmpty(line!) ? (int?)null : int.Parse(line!));
        }

        public long? ReadLong(string requestValueText)
        {
            return Read(requestValueText, (line) => long.Parse(line!));
        }

        public sbyte? ReadSByte(string requestValueText)
        {
            return Read(requestValueText, (line) => sbyte.Parse(line!));
        }

        public short? ReadShort(string requestValueText)
        {
            return Read(requestValueText, (line) => short.Parse(line!));
        }

        public string? ReadString(string requestValueText)
        {
            return consoleService.ReadStyledAnswer(requestValueText);
        }

        public uint? ReadUInt(string requestValueText)
        {
            return Read(requestValueText, (line) => uint.Parse(line!));
        }

        public ulong? ReadULong(string requestValueText)
        {
            return Read(requestValueText, (line) => ulong.Parse(line!));
        }

        public ushort? ReadUShort(string requestValueText)
        {
            return Read(requestValueText, (line) => ushort.Parse(line!));
        }
    }
}
