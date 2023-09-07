using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace detectVideoApp
{
    public class FileMonitoringService
    {
        #region Members
        private List<FileSystemWatcher> _fileSystemWatchers = new List<FileSystemWatcher>();
        private string _Extensions;
        public event EventHandler<MonitoringDetailsEventArgs> MonitoringDetailNotify;
        private MonitoringDetailDbService _monitoringDetailDbService;
        private CameraConfiguration _cameraConfiguration;
        #endregion

        #region Constructors

        public FileMonitoringService(CameraConfiguration cameraConfiguration)
        {
            _monitoringDetailDbService = new MonitoringDetailDbService();
            _cameraConfiguration = cameraConfiguration;
            _Extensions = _cameraConfiguration.VideoExtension + " " + _cameraConfiguration.PhotoExtension;

            var FolderPaths = cameraConfiguration.FolderPath.Split(',');
            foreach (var FolderPath in FolderPaths)
            {
                FileSystemWatcher folderWatcher = new FileSystemWatcher();
                folderWatcher.Path = FolderPath;
                folderWatcher.IncludeSubdirectories = true;
                folderWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.CreationTime;
                folderWatcher.Created += new FileSystemEventHandler(FileCreate);
                folderWatcher.Changed += new FileSystemEventHandler(FileChange);
                folderWatcher.Filter = "";
                folderWatcher.EnableRaisingEvents = true;

                _fileSystemWatchers.Add(folderWatcher);
            }
        }

        #endregion
        #region Events
        private void FileCreate(object sender, FileSystemEventArgs e)
        {
            string strFileExt = FileService.GetFileExtension(e.Name);


            if (_Extensions.Contains(strFileExt))
            {
                if (Enum.TryParse((strFileExt.Substring(1).ToUpper()), out VideoExtensionsEnum videoExten))
                {

                    _monitoringDetailDbService.WriteInDb_NewMonitoringDetail(_cameraConfiguration, e.FullPath.ToString(), e.Name.ToString(), true);
                    OnCreatedOrChangedFile(new MonitoringDetailsEventArgs(ActionsEnum.Created.ToString(), _cameraConfiguration.CameraName, e.FullPath.ToString(), e.Name.ToString(), DateTime.Now));
                }
                if (Enum.TryParse((strFileExt.Substring(1)), out PhotoExtensionsEnum PhotoExten))
                {
                    _monitoringDetailDbService.WriteInDb_NewMonitoringDetail(_cameraConfiguration, e.FullPath.ToString(), e.Name.ToString(), false);
                    OnCreatedOrChangedFile(new MonitoringDetailsEventArgs(ActionsEnum.Created.ToString(), _cameraConfiguration.CameraName, e.FullPath.ToString(), e.Name.ToString(), DateTime.Now));
                }
            }


        }
        /// <summary>
        /// Calls the event handler method registered with the MonitoringDetails event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCreatedOrChangedFile(MonitoringDetailsEventArgs e)
        {
            MonitoringDetailNotify?.Invoke(this, e);

        }
        private void FileChange(object sender, FileSystemEventArgs e)
        {
            if (_Extensions.Contains(FileService.GetFileExtension(e.Name)))
            {
                _monitoringDetailDbService.UpdateDb_MonitoringDetail(e.Name.ToString());
                OnCreatedOrChangedFile(new MonitoringDetailsEventArgs("File changed ", _cameraConfiguration.CameraName, e.FullPath.ToString(), e.Name.ToString(), DateTime.Now));

            }


        }
        #endregion
        /// <summary>
        /// Stops monitoring process
        /// </summary>
        public void StopMonitoring()
        {
            foreach (var fileSystemWatcher in _fileSystemWatchers)
            {
                fileSystemWatcher.EnableRaisingEvents = false;
                fileSystemWatcher.Dispose();
            }
        }
    }
}
