using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APIModels.General
{
    [Table("Organizations")]
    public class Organization
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public bool IsPerson { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime StorageDate { get; set; }
        [Required]
        public string StorageProfile { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedProfile { get; set; }


        public Organization()
        {
            this.Status = (int)STATUS.NEW;
        }


        public enum STATUS
        {
            NEW = 1,
            ACTIVE = 2,
            BLOCKED = 3,
            DISABLED = 4
        }
    }
}
