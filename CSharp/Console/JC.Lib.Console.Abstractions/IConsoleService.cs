using System.Text;

namespace Console.Abstractions
{
    public interface IConsoleService
    {
        void Write(string text, ConsoleColor? foreground = null, ConsoleColor? background = null);

        void WriteStyled(string text);

        void WriteLine(string text, ConsoleColor? foreground = null, ConsoleColor? background = null);

        void WriteStyledLine(string text);

        void WriteLine();

        string? ReadAnswer(string question, ConsoleColor? foreground = null, ConsoleColor? background = null);
        string? ReadStyledAnswer(string question);

        ConsoleKeyInfo ReadKey();
        ConsoleKeyInfo ReadKey(bool intercept);

        string? ReadLine();

        Encoding GetInputEncoding();

        void SetInputEncoding(Encoding encoding);

        Encoding GetOutputEncoding();

        void SetOutputEncoding(Encoding encoding);
    }
}
