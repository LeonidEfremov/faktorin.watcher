using System.IO;
using Faktorin.Actions;

namespace Faktorin.Parsers
{
    public class HtmlParser : IParser
    {
        public string Extension { get; } = ".html";

        public Result Parse(string path)
        {
            var action = new DivCountAction();
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
