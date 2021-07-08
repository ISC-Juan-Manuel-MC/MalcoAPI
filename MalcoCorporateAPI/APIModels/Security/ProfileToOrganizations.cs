using APIModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APIModels.Security
{
    [Table("ProfileToOrganizations")]
    public class ProfileToOrganizations
    {
        [Key, Column(Order = 0)]
        public Organization Organization { get; set; }
        [Key, Column(Order = 1)]
        public Profile Profile { get; set; }
    }
}
