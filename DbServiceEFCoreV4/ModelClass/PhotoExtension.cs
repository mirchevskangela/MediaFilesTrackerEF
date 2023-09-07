using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class PhotoExtension
    {
        [Key]
        public int Id { get; set; }
        public string Extension { get; set; }
    }
}
