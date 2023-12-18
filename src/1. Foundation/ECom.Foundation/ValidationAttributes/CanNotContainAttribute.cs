namespace ECom.Foundation.ValidationAttributes;

// public class CanNotContainAttribute : ValidationAttribute
// {
//   public CanNotContainAttribute() {
//     ErrorMessageResourceName = "can_not_contain";
//     ErrorMessageResourceType = typeof(LocalizedResource);
//   }
//
//   public string Chars { get; set; }
//   public string? Name { get; set; }
//
//   public override bool IsValid(object value) {
//     if (Chars.Length == 0) throw new ArgumentException("Chars is empty");
//     if (value is not string str) return true;
//     return !Chars.Any(str.Contains);
//   }
//
//   public override string FormatErrorMessage(string name) {
//     var message = ErrorMessageString;
//     return message.LocFormat("chars", string.Join(",", Chars.ToArray())).LocFormat("name", Name ?? name);
//   }
// }