using System;
using System.IO;

namespace OrderMonitor.Interfaces
{
    public interface IFileWatcher
    {
        void WatchForOrders(string directory);
    }

    public class FileWatcher : IFileWatcher
    {
        private IOrderParser parser;
        private IOrderOutputter outputter;

        public FileWatcher(IOrderParser parser, IOrderOutputter outputter)
        {
            this.parser = parser;
            this.outputter = outputter;
        }

        public void WatchForOrders(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"The Directory {directory} doesn't exist");
            }

            Console.WriteLine($"Watching directory {directory}");

            var watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.Filter = "*.csv";

            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"Reading file {e.FullPath}");
            var orders = parser.ReadOrders(e.FullPath);

            File.Move(e.FullPath, e.FullPath + ".processed");

            outputter.CreateDocument(orders, Path.GetDirectoryName(e.FullPath), Path.GetFileNameWithoutExtension(e.FullPath));
        }
    }
}
