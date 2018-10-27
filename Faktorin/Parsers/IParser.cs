namespace Faktorin.Parsers
{
    public interface IParser
    {
        string Extension { get; }

        Result Parse(string path);
    }
}