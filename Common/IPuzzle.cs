namespace Common;

public interface IPuzzle
{
    string Title { get; }

    Task<string> GetPart1OutputAsync();

    Task<string> GetPart2OutputAsync();
}
