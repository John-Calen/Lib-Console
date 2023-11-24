namespace JC.Lib.Console.Query
{
    public class RepeatStatement<T_Key>: OperationScope<T_Key>
        where T_Key: Enum
    {
        internal RepeatStatement(OperationScope<T_Key> parent, IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(parent, consoleQueryBuilder)
        {
        }





        public override void Handle()
        {
            while (true)
            {
                base.Handle();
            
                consoleQueryBuilder.ConsoleService.WriteStyledLine("<f-m>Continue loop?<f-gy>(press any key to continue. To break press Esc key)");
                var keyInfo  = consoleQueryBuilder.ConsoleService.ReadKey(true);
                if (keyInfo.Key is ConsoleKey.Escape)
                    break;
            }
        }
    }
}
