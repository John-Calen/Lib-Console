using JC.Lib.Console.Query.Updaters;

namespace JC.Lib.Console.Query
{
    public class HeavyActionOperation<T_Key, T_Model>: AOperation<T_Key>
        where T_Key : Enum
        where T_Model : notnull, new()
    {
        private readonly Action<Storage<T_Key>, T_Model> body;
        public TimeSpan UpdateDelay { get; }
        private readonly Updater<T_Model> updater;






        public HeavyActionOperation(Action<Storage<T_Key>, T_Model> body, TimeSpan updateDelay , IConsoleQueryBuilder<T_Key> consoleQueryBuilder) : base(consoleQueryBuilder)
        {
            this.body = body;
            UpdateDelay = updateDelay;   
            updater = new Updater<T_Model>(consoleQueryBuilder.ConsoleService);
        }






        public override void Handle()
        {
            updater.Start(UpdateDelay);
            
            body(consoleQueryBuilder.Storage, updater.Model);
            
            updater.Stop();
        }
    }
}
