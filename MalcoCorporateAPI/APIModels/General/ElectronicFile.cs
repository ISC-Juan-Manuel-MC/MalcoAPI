using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIModels.General
{
    [Table("ElectronicFiles")]
    public class ElectronicFile
    {
        [Key]
        public String Id { get; set; }
        [Required]
        public string OriginalName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public byte[] File { get; set; }
        [Required]
        public DateTime StorageDate { get; set; }
        [Required]
        public string StorageProfile { get; set; }



        public enum EXTENSIONS
        {
            JPEG,
            JPG,
            PNG
        }
    }
}
