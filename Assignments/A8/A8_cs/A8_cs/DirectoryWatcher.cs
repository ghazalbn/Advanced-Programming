using System;
using System.IO;

namespace A8_cs
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher watcher;
        private Action<string> create;
        private Action<string> delete;
        public DirectoryWatcher(string dir)
        {
            watcher = new FileSystemWatcher(dir);
            watcher.EnableRaisingEvents = true;
            watcher.Created += onCreate;
            watcher.Deleted += onDelete;

        }

        private void onDelete(object sender, FileSystemEventArgs e)
        {
            if(delete != null)
                delete(e.FullPath);
        }

        private void onCreate(object sender, FileSystemEventArgs e)
        {
            if(create != null)
                create(e.FullPath);
        }
        public void Dispose() => watcher.Dispose();

        public void Register(Action<string> notify, ObserverType type)
        {
            if(type == ObserverType.Create)
                create += notify;
            else
                delete += notify;
        }

        public void Unregister(Action<string> notify, ObserverType type)
        {
            if(type == ObserverType.Create)
                create -= notify;
            else
                delete -= notify;
        }
    }
}