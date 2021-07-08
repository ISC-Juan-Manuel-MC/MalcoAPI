using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APIModels.General
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PersonID { get; set; }
        [Required]
        [Column("AvatarElectronicFileId")]
        public string AvatarID { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime StorageDate { get; set; }
        [Required]
        public string StorageProfile { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedProfile { get; set; }


        //Foreing Entity
        [Required]
        public virtual Person Person { get; set; }


        public Profile()
        {
            this.Status = (int) STATUS.NEW;
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
