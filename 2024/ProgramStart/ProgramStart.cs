using Day1;
using Day2;

namespace ProgramStart;

public class ProgramStart : IProgramStart
{
    public IRunProgram Day1Program { get; set; }
    public IRunProgram Day2Program { get; set; }

    public ProgramStart(
        IRunProgram day1Program, 
        IRunProgram day2Program)
    {
        Day1Program = day1Program;
        Day2Program = day2Program;
    }

    public async Task StartAsync()
    {
        //await Day1Program.Run();
        await Day2Program.Run();
    }
}
