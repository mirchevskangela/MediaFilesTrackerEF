using System;

namespace detectVideoApp
{
    public class MonitoringDetailsEventArgs : EventArgs
    {
        #region Members
        public string Camera { get; set; }
        public string Action { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public MonitoringDetailsEventArgs(string action, string camera, string path, string name, DateTime timeStamp)
        {
            this.Action = action;
            this.Camera = camera;
            this.Path = path;
            this.Name = name;
            this.TimeStamp = timeStamp;
        }
        public MonitoringDetailsEventArgs()
        {
          
        }
        #endregion

    }
}
