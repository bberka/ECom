using EasMe.Extensions;
using ECom.Shared.Extensions;
using ECom.Shared.Resources;

namespace ECom.Shared.Attributes;

public class AllowedCharsAttribute : ValidationAttribute
{
  public AllowedCharsAttribute() {
    ErrorMessageResourceName = "contains_invalid_characters";
    ErrorMessageResourceType = typeof(LocalizedResource);
  }
  public string Chars{ get; set; }
  public string? Name { get; set; }
  public override bool IsValid(object value) {
    if(Chars.Length == 0) throw new ArgumentException("Chars is empty");
    if (value is not string str) return true;
    var charArray = Chars.ToCharArray();
    var isAllValid = str.All(x => charArray.Contains(x));
    return isAllValid;
  }

  public override string FormatErrorMessage(string name) {
    var message = ErrorMessageString;
    return message.LocFormat("name",Name ?? name);
  }


}