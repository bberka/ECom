﻿using System.Runtime.InteropServices;
using EasMe.EntityFrameworkCore;

namespace ECom.Domain.Entities;

[Table("EmailVerifyTokens", Schema = "ECPrivate")]
[Index(nameof(Token))]
public class EmailVerifyToken : IEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
  public DateTime ExpireDate { get; set; }
  public DateTime? UseDate { get; set; }
  [MaxLength(ValidationSettings.MaxTokenLength)]
  [MinLength(ValidationSettings.MinTokenLength)]
  public string Token { get; set; }

  [EmailAddress]
  public string EmailAddress { get; set; }
  
  public Guid UserId { get; set; }

  //virtual
  public virtual User User { get; set; }
}