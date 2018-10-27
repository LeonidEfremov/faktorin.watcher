using Faktorin.Parsers;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Faktorin
{
    public class Watcher
    {
        private readonly string _reportName = ".result";
        private readonly IParser[] _parsers;
        private string _reportPath;
        private FileSystemWatcher _fsw;

        public Watcher(IParser[] parsers)
        {
            _parsers = parsers;
        }

        public void Watch(string path)
        {
            if (IsWatching)
            {
                // TODO Have to be own exception
                throw new Exception("Already watched!");
            }

            _reportPath = Path.Combine(path, _reportName);

            _fsw = new FileSystemWatcher(path)
            {
                NotifyFilter = NotifyFilters.FileName,
                EnableRaisingEvents = true
            };
            _fsw.Created += OnCreated;
        }

        public bool IsWatching => _fsw != null && _fsw.EnableRaisingEvents;

        public void Stop()
        {
            _fsw.EnableRaisingEvents = false;
            _fsw.Dispose();
            _fsw = null;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            var fullPath = e.FullPath;

            if (!Path.GetFileName(fullPath).Equals(_reportName))
            {
                var extension = Path.GetExtension(fullPath);
                var parser =
                    _parsers.FirstOrDefault(_ =>
                        _.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase)) ??
                    new DefaultParser();

                // TODO Wait for file be fully written
                Thread.Sleep(1000);

                var result = parser.Parse(fullPath);

                File.AppendAllText(_reportPath, $"{result}{Environment.NewLine}");
            }
        }
    }
}
