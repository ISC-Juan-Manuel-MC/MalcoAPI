using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APIModels.General
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        [Column("PersonId")]
        public string ID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Timestamp]
        [Required]
        public DateTime Birthday { get; set; }
        [Phone]
        [Required]
        public string Cellphone { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime StorageDate { get; set; }
        [Required]
        public string StorageProfile { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedProfile { get; set; }


        public virtual ICollection<Profile> Profiles { get; set; }


        public Person()
        {
            this.Profiles = new HashSet<Profile>();
        }


        public enum GENDER
        {
            M,
            F,
            O
        }
    }
}
