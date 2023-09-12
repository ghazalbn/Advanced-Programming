using System;
using System.IO;

namespace A8_cs
{

    public class SingleFileWatcher: IDisposable
    {
        private FileSystemWatcher Fwatcher;
        public Action change; 
        public SingleFileWatcher(string path)
        {
            Fwatcher = new FileSystemWatcher
            (Path.GetDirectoryName(path), Path.GetFileName(path));
            Fwatcher.EnableRaisingEvents = true;
            Fwatcher.Changed += onChange;
        }
        public void Register(Action notify)
            => change += notify;
        public void onChange(object sender, FileSystemEventArgs e)
        {
            if(change != null)
                change();
        }
        public void Dispose() => Fwatcher.Dispose();

        public void Unregister(Action notify)
            => change -=  notify;
    }
}