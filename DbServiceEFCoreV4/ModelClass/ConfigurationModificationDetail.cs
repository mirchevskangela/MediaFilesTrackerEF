using DbServiceEFCoreV4.ModelClass;
using System;

namespace ClassLibrary.ModelClass
{
    public class ConfigurationModificationDetail
    {
        #region Members
        [System.ComponentModel.Browsable(false)]
        public int Id { get; set; }
        public string CameraName { get; set; }
        public string FolderPath { get; set; }
        public string VideoExtension { get; set; }
        public string PhotoExtension { get; set; }

        [System.ComponentModel.Browsable(false)]
        public Actions Actions { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int ActionsID { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Action { get { return Actions?.Action; } }
        public DateTime Timestamp { get; set; }

        #endregion
    }
}
