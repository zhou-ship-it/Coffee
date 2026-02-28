using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class User
{
    
    [Column("userID")]
    [StringLength(50)]
    [Unicode(false)]
    public string UserId { get; set; } 

    [Column("userName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? UserName { get; set; }

    [Column("password")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("role")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Role { get; set; }

}
