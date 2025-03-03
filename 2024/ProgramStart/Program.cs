﻿using Day1;
using Day2;
using Day3;
using Day4;
using Day5;
using Day6;
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
            .AddSingleton<IRunProgram, Day4Program>()
            .AddSingleton<IRunProgram, Day5Program>()
            .AddSingleton<IRunProgram, Day6Program>()
            .BuildServiceProvider();

        var service = serviceProvider.GetService<IProgramStart>()!;
        if (service != null)
        {
            await service.StartAsync();
        }
    }
}
