namespace Common;

public interface IParser<TOutput>
{
    TOutput Parse(string[] input);
}
