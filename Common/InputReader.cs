namespace Common;

public static class InputReader
{
    private const string fileName = "input.txt";

    public static async Task<string[]> GetInputAsync()
    {
        return await File.ReadAllLinesAsync(fileName);
    }

    public static async Task<TOutput> GetInputAsync<TParser, TOutput>()
        where TParser : IParser<TOutput>, new()
    {
        var parser = new TParser();
        var input = await File.ReadAllLinesAsync(fileName);

        return parser.Parse(input);
    }
}
