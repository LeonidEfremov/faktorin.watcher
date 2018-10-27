using System.IO;
using Faktorin.Actions;

namespace Faktorin.Parsers
{
    public class DefaultParser : IParser
    {
        public string Extension { get; } = null;

        public Result Parse(string path)
        {
            var text = File.ReadAllText(path);
            var action = new MarksCountAction();
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
