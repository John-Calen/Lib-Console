using Console.Abstractions;
using JC.Lib.Exceptions;
using System.Text;
using System.Text.RegularExpressions;

namespace JC.Lib.Console.Services
{
    public class ConsoleService : IConsoleService
    {
        private readonly static Regex styleRegex = new("<(f|b)-(bk|db|dg|dc|dr|dm|dy|dgy|gy|b|g|c|r|m|y|w|\\*)>");






        public void Write(string text, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            var oldForeground = System.Console.ForegroundColor;
            var oldBackground = System.Console.BackgroundColor;

            if (foreground is not null)
                System.Console.ForegroundColor = foreground!.Value;

            if (background is not null)
                System.Console.BackgroundColor = background!.Value;

            System.Console.Write(text);

            System.Console.ForegroundColor = oldForeground;
            System.Console.BackgroundColor = oldBackground;
        }

        public void WriteStyled(string text)
        {
            var foreground = System.Console.ForegroundColor;
            var background = System.Console.BackgroundColor;

            var oldForeground = foreground;
            var oldBackground = background;

            var matches = styleRegex.Matches(text);
            var handledIndex = 0;
            foreach (var match in matches.OfType<Match>())
            {
                var entireTextGroup = match.Groups[0];
                if (handledIndex < entireTextGroup.Index)
                {
                    System.Console.ForegroundColor = foreground;
                    System.Console.BackgroundColor = background;
                    System.Console.Write(text[handledIndex..entireTextGroup.Index]);
                }

                handledIndex = entireTextGroup.Index + entireTextGroup.Length;

                var colorType = match.Groups[1].Value;
                var colorName = match.Groups[2].Value;

                changeColors(colorType, colorName, ref foreground, ref background);
            }

            if (handledIndex <= text.Length - 1)
            {
                System.Console.ForegroundColor = foreground;
                System.Console.BackgroundColor = background;
                System.Console.Write(text[handledIndex..]);
            }

            System.Console.ForegroundColor = oldForeground;
            System.Console.BackgroundColor = oldBackground;
        }

        private void changeColors(string colorType, string colorName, ref ConsoleColor foreground, ref ConsoleColor background)
        {
            switch (colorType)
            {
                case "f":
                    {
                        var f = getColorByName(colorName);
                        if (f is null)
                            foreground = ConsoleColor.Gray;

                        else
                            foreground = f!.Value;

                        break;
                    }
                case "b":
                    {
                        var b = getColorByName(colorName);
                        if (b is null)
                            background = ConsoleColor.Black;

                        else
                            background = b!.Value;

                        break;
                    }
                default:
                    throw CausedException.NewUnexpectedSwitchArgument(nameof(colorType), colorType);
            }
        }

        private ConsoleColor? getColorByName(string colorName)
        {
            switch (colorName)
            {
                case "*":
                    return null;
                case "bk":
                    return ConsoleColor.Black;
                case "db":
                    return ConsoleColor.DarkBlue;
                case "dg":
                    return ConsoleColor.DarkGreen;
                case "dc":
                    return ConsoleColor.DarkCyan;
                case "dr":
                    return ConsoleColor.DarkRed;
                case "dm":
                    return ConsoleColor.DarkMagenta;
                case "gy":
                    return ConsoleColor.Gray;
                case "dgy":
                    return ConsoleColor.DarkGray;
                case "b":
                    return ConsoleColor.Blue;
                case "g":
                    return ConsoleColor.Green;
                case "c":
                    return ConsoleColor.Cyan;
                case "r":
                    return ConsoleColor.Red;
                case "m":
                    return ConsoleColor.Magenta;
                case "y":
                    return ConsoleColor.Yellow;
                case "w":
                    return ConsoleColor.White;
                default:
                    throw CausedException.NewUnexpectedSwitchArgument(nameof(colorName), colorName);
            }
        }

        public void WriteLine(string text, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            var oldForeground = System.Console.ForegroundColor;
            var oldBackground = System.Console.BackgroundColor;

            if (foreground is not null)
                System.Console.ForegroundColor = foreground!.Value;

            if (background is not null)
                System.Console.BackgroundColor = background!.Value;

            System.Console.WriteLine(text);

            System.Console.ForegroundColor = oldForeground;
            System.Console.BackgroundColor = oldBackground;
        }

        public void WriteStyledLine(string text)
        {
            WriteStyled(text);
            WriteLine();
        }

        public void WriteLine()
        {
            System.Console.WriteLine();
        }

        public string? ReadAnswer(string question, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            if (!question.EndsWith(':'))
                question = $"{question}: ";

            Write(question, foreground, background);
            var result = System.Console.ReadLine();

            return result;
        }

        public string? ReadStyledAnswer(string question)
        {
            if (!question.EndsWith(':'))
                question = $"{question}: ";

            WriteStyled(question);
            var result = System.Console.ReadLine();

            return result;
        }

        public ConsoleKeyInfo ReadKey()
        {
            var result = System.Console.ReadKey();
            return result;
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            var result = System.Console.ReadKey(intercept);
            return result;
        }

        public Encoding GetInputEncoding()
        {
            return System.Console.InputEncoding;
        }

        public void SetInputEncoding(Encoding encoding)
        {
            System.Console.InputEncoding = encoding;
        }

        public Encoding GetOutputEncoding()
        {
            return System.Console.OutputEncoding;
        }

        public void SetOutputEncoding(Encoding encoding)
        {
            System.Console.OutputEncoding = encoding;
        }

        public string? ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
