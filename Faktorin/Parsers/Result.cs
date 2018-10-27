using System.IO;

namespace Faktorin.Parsers
{
    public class Result
    {
        public string FileName { get; set; }

        public string Operation { get; set; }

        public object Value { get; set; }

        public override string ToString() => $"{Path.GetFileName(FileName)}-{Operation}-{Value}";
    }
}
