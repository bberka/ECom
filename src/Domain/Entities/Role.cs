﻿namespace ECom.Domain.Entities;

public class Role : IEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [MinLength(ConstantMgr.NameMinLength)]
  [MaxLength(ConstantMgr.NameMaxLength)]
  public string Name { get; set; }

  public bool IsValid { get; set; } = true;

  //Virtual
  public IEnumerable<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();
}