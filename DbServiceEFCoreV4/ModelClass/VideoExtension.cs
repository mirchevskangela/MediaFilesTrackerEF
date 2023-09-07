using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class VideoExtension
    {
        [Key]
        public int Id { get; set; }
        public string Extension { get; set; }
    }
}
