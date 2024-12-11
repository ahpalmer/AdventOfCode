using Day1;
using Microsoft.Extensions.DependencyInjection;

namespace ProgramStart;

public class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IProgramStart, ProgramStart>()
            .AddSingleton<IDay1Program, Day1Program>()
            .BuildServiceProvider();

        var service = serviceProvider.GetService<IProgramStart>()!;
        if (service != null)
        {
            await service.StartAsync();
        }
    }
}
