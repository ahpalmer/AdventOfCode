using Day1;

namespace ProgramStart;

public class ProgramStart : IProgramStart
{
    public IDay1Program Day1Program { get; set; }

    public ProgramStart(IDay1Program day1Program)
    {
        Day1Program = day1Program;
    }

    public async Task StartAsync()
    {
        await Day1Program.Run();
    }
}
