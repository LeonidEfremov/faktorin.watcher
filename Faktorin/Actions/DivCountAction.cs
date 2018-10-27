using System.Text.RegularExpressions;

namespace Faktorin.Actions
{
    public class DivCountAction : IAction
    {
        private readonly Regex _div = new Regex(@"<\s*div[^>]*>(.*?)<\s*/\s*div>");

        public string Name { get; } = "div";

        public object Do(string text)
        {
            var matches = _div.Matches(text).Count;

            return matches;
        }
    }
}
