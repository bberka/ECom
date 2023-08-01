using System.Collections;
using System.Linq;
using ECom.Shared.Extensions;
using ECom.Shared.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ECom.Shared.Attributes;

public class CanNotContainAttribute : ValidationAttribute
{
  public CanNotContainAttribute() {
    ErrorMessageResourceName = "can_not_contain";
    ErrorMessageResourceType = typeof(LocalizedResource);
  }
  public string Chars{ get; set; }
  public string? Name { get; set; }
  public override bool IsValid(object value) {
    if(Chars.Length == 0) throw new ArgumentException("Chars is empty");
    if (value is not string str) return true;
    return !Chars.Any(str.Contains);
  }

  public override string FormatErrorMessage(string name) {
    var message = ErrorMessageString;
    return message.LocFormat("chars",string.Join(",",Chars.ToArray())).LocFormat("name",Name ?? name);
  }


}
