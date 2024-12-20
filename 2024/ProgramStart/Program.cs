using Day1;
using Day2;
using Day3;
using Microsoft.Extensions.DependencyInjection;

namespace ProgramStart;

public class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IProgramStart, ProgramStart>()
            .AddSingleton<IRunProgram, Day1Program>()
            .AddSingleton<IRunProgram, Day2Program>()
            .AddSingleton<IRunProgram, Day3Program>()
            .BuildServiceProvider();

        var service = serviceProvider.GetService<IProgramStart>()!;
        if (service != null)
        {
            await service.StartAsync();
        }
    }
}
