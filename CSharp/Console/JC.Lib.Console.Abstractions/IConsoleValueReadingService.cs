namespace Console.Abstractions
{
    public interface IConsoleValueReadingService
    {
        T_Value? Read<T_Value>(string requestValueText, IEnumerable<T_Value> values, Func<string?, T_Value> converter, Func<T_Value, T_Value, bool>? equlaityComparer = null);
        byte? Read(string requestValueText, IEnumerable<byte> values);
        sbyte? Read(string requestValueText, IEnumerable<sbyte> values);
        short? Read(string requestValueText, IEnumerable<short> values);
        ushort? Read(string requestValueText, IEnumerable<ushort> values);
        int? Read(string requestValueText, IEnumerable<int> values);
        uint? Read(string requestValueText, IEnumerable<uint> values);
        long? Read(string requestValueText, IEnumerable<long> values);
        ulong? Read(string requestValueText, IEnumerable<ulong> values);
        float? Read(string requestValueText, IEnumerable<float> values);
        double? Read(string requestValueText, IEnumerable<double> values);
        char? Read(string requestValueText, IEnumerable<char> values);
        string? Read(string requestValueText, IEnumerable<string> values);
        bool? Read(string requestValueText);
        T_Value? Read<T_Value>(string requestValueText, Func<string?, T_Value> converter);
        byte? ReadByte(string requestValueText);
        sbyte? ReadSByte(string requestValueText);
        short? ReadShort(string requestValueText);
        ushort? ReadUShort(string requestValueText);
        int? ReadInt(string requestValueText);
        uint? ReadUInt(string requestValueText);
        long? ReadLong(string requestValueText);
        ulong? ReadULong(string requestValueText);
        float? ReadFloat(string requestValueText);
        double? ReadDouble(string requestValueText);
        char? ReadChar(string requestValueText);
        string? ReadString(string requestValueText);
    }
}
