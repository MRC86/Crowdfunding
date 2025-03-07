﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Crowdfunding.Database.Entities;

[Table("Favorite")]
public partial class Favorite
{
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }

    [Column("ProjectID")]
    public Guid ProjectId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreateTime { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("Favorites")]
    public virtual Project Project { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Favorites")]
    public virtual User User { get; set; }
}