using System.Linq;

namespace Faktorin.Actions
{
    public class BracketsPairAction : IAction
    {
        public string Name { get; } = "brackets";

        public object Do(string text)
        {
            var opened = text.Count(_ => _.Equals('{'));
            var closed = text.Count(_ => _.Equals('}'));

            return opened == closed;
        }
    }
}
