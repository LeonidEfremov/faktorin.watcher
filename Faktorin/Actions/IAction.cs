namespace Faktorin.Actions
{
    public interface IAction
    {
        string Name { get; }

        object Do(string text);
    }
}