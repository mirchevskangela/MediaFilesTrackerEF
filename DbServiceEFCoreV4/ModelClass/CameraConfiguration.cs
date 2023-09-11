using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using detectVideoApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace ClassLibrary.ModelClass
{
    public class CameraConfiguration
    {
        #region Fields
        [Key]
        public int Id { get; set; }
        public string CameraName { get; set; }
        public string FolderPath { get; set; }
        public string VideoExtension { get; set; }
        public string PhotoExtension { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Active { get; set; }
        public List<MonitoringDetail> MonitoringDetails { get; set; }

        public override string ToString()
        {
            return CameraName; 
        }
        #endregion


        /*
        private void test()
        {
            CameraConfiguration cameraConfiguration = new CameraConfiguration();
            cameraConfiguration.CameraName = "test";

            Enum.TryParse("mp3", out VideoExtensionsEnum result);

            cameraConfiguration.VideoExtensions.Add(new CameraConfiguration_VideoExtension { VideoExtensionId = (int)result,CameraConfigurationId = cameraConfiguration.Id }) ;
        }
        */
    }
}
