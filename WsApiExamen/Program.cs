using Microsoft.AspNetCore;

namespace WsApiExamen
{
    /// <summary>
    /// API main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Classic main method (Creates the default .NET host builder)
        /// </summary>
        /// <param name="args">Programs args</param>
        public static void Main(string[] args) => WebHost.CreateDefaultBuilder(args: args).UseStartup<Startup>().Build().Run();
    }
}