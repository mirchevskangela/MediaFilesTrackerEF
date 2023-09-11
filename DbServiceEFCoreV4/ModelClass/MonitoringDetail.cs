using DbServiceEFCoreV4.ModelClass;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.ModelClass
{
    public class MonitoringDetail
    {
        #region Members
        [System.ComponentModel.Browsable(false)]
        public int Id { get; set; }
        [ForeignKey("CameraConfigurationID")]
        [System.ComponentModel.Browsable(false)]
        public CameraConfiguration CameraConfiguration { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int CameraConfigurationID { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string CameraName { get { return CameraConfiguration?.CameraName; } }

        [System.ComponentModel.Browsable(false)]
        public Actions Actions { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int ActionsID { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Action { get { return Actions?.Action; } }
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public DateTime StartTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        [System.ComponentModel.Browsable(false)]
        public bool IsVideo { get; set; }
        #endregion
    }
}
