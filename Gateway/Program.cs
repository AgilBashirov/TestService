using Ocelot.DependencyInjection;
using TestService;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHost(args).Build();

        host.Run();
    }

    private static IHostBuilder CreateHost(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                configurationBuilder
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    //.AddJsonFile("ocelot.json", optional: false, reloadOnChange: false)
                    .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: false)
                    .AddJsonFile($"ocelot.{context.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: false);
            })
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        return builder;
    }

}
