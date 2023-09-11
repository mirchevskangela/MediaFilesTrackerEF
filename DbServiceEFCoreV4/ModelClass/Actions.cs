using ClassLibrary.ModelClass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class Actions
    {
        [Key]
        public int Id { get; set; }
        public string Action { get; set; }
        public List<MonitoringDetail> MonitoringDetails { get; set; }
        public List<ConfigurationModificationDetail> ConfigurationModificationDetails { get; set; }


    }
}
