using Newtonsoft.Json;

namespace JC.Lib.Console.Query
{
    public class PrintValue<T_Key>: AOperation<T_Key>
        where T_Key: Enum
    {
        public string Text { get; }
        public T_Key Key { get; }





        internal PrintValue(string text, T_Key key, IConsoleQueryBuilder<T_Key> consoleQueryBuilder): base(consoleQueryBuilder)
        {
            Text = text;
            Key = key;
        }






        public override void Handle()
        {
            var content = JsonConvert.SerializeObject(consoleQueryBuilder.Storage.Get<object>(Key), Formatting.Indented);
            consoleQueryBuilder.ConsoleService.WriteStyledLine($"<f-g>{ Text }: <f-y>{ content }<f-*>\n");
        }
    }
}
