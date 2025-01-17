using Day1;
using Day2;
using Day4;

namespace ProgramStart;

public class ProgramStart : IProgramStart
{
    public IRunProgram Day1Program { get; set; }
    public IRunProgram Day2Program { get; set; }
    public IRunProgram Day3Program { get; set; }
    public IRunProgram Day4Program { get; set; }

    public ProgramStart(
        IRunProgram day1Program, 
        IRunProgram day2Program,
        IRunProgram day3Program,
        IRunProgram day4Program)
    {
        Day1Program = day1Program;
        Day2Program = day2Program;
        Day3Program = day3Program;
        Day4Program = day4Program;
    }

    public async Task StartAsync()
    {
        //await Day1Program.Run();
        //await Day2Program.Run();
        //await Day3Program.Run();
        await Day4Program.Run();
    }
}
