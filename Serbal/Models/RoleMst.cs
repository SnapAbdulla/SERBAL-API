using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Serbal.Models
{
    public partial class RoleMst
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
    }
}
