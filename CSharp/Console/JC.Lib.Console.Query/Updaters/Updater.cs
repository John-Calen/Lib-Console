using Console.Abstractions;
using JC.Lib.Exceptions;
using System.Reflection;

namespace JC.Lib.Console.Query.Updaters
{
    internal class Updater<T_Model>
        where T_Model : notnull, new()
    {
        public T_Model Model { get; }
        private CancellationTokenSource? cancellationTokenSource = null;
        private readonly PropertyInfo[] propertyInfos;
        private readonly IConsoleService consoleService;








        public Updater(IConsoleService consoleService)
        {
            this.consoleService = consoleService;
            Model = new T_Model();
            propertyInfos = typeof(T_Model).GetProperties()
                .Where((p) => p.GetCustomAttribute<ModelPropertyAttribute>() is not null)
                .ToArray();
        }





        public Task Start(TimeSpan delay)
        {
            if (cancellationTokenSource is not null)
            {
                throw new CausedException.Builder()
                    .SetMessage("already started")
                    .Build();
            }

            cancellationTokenSource = new CancellationTokenSource();

            return Task.Run
            (
                () =>
                {
                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        try
                        {
                            Print();
                        }

                        catch { }

                        Thread.Sleep(delay);
                    }

                    cancellationTokenSource = null;
                }
            );
        }

        private void Print()
        {
            foreach (var propertyInfo in propertyInfos)
            {
                var attr = propertyInfo.GetCustomAttribute<ModelPropertyAttribute>()!;
                if (attr.Prefix is not null)
                    consoleService.Write(attr.Prefix, attr.ForegroundText, attr.BackgroundText);
                
                consoleService.Write(propertyInfo.GetValue(Model)!.ToString()!, attr.ForegroundValue, attr.BackgroundValue);
                
                if (attr.Sufix is not null)
                    consoleService.WriteLine(attr.Sufix, attr.ForegroundText, attr.BackgroundText);
                
                else
                    consoleService.WriteLine();
            }

            consoleService.WriteLine();
        }

        public void Stop()
        {
            if (cancellationTokenSource is null)
            {
                throw new CausedException.Builder()
                    .SetMessage("has not been started")
                    .Build();
            }

            cancellationTokenSource.Cancel();

            try
            {
                Print();
            }

            catch { }
        }
    }
}
