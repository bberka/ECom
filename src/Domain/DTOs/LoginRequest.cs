using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ECom.Domain.DTOs;

public class LoginRequest
{
  public string EmailAddress { get; set; }
  public string Password { get; set; }
  public bool IsHashed { get; set; } = false;


}