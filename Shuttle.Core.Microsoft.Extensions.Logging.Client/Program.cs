using Microsoft.Extensions.Logging;
using Shuttle.Core.Logging;

namespace Shuttle.Core.Microsoft.Extensions.Logging.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory =
                LoggerFactory.Create(builder =>
                    builder.AddSimpleConsole());
            
            Log.Assign(new Logger(loggerFactory.CreateLogger<Program>()));

#if (!NETCOREAPP)
            Log.Information("successful - .net framework");
#else
            Log.Information("successful - .net core");
#endif
        }
    }
}