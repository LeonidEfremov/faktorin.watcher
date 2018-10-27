using System.IO;
using Faktorin.Actions;

namespace Faktorin.Parsers
{
    public class CssParser : IParser
    {
        public string Extension { get; } = ".css";

        public Result Parse(string path)
        {
            var action = new BracketsPairAction();
            var text = File.ReadAllText(path);
            var result = action.Do(text);

            return new Result
            {
                FileName = path,
                Operation = action.Name,
                Value = result
            };
        }
    }
}
