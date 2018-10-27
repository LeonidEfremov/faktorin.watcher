using System.Linq;

namespace Faktorin.Actions
{
    public class MarksCountAction : IAction
    {
        private readonly char[] _marks = { '.', ',', '!', '?', ';', ':', '"', '(', ')', '\'' };

        public string Name { get; } = "marks";

        public object Do(string text) => text.Count(_ => _marks.Contains(_));
    }
}
