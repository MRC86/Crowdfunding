﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Crowdfunding.Database.Entities;

[Table("ProjectType")]
public partial class ProjectType
{
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
}