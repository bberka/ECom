namespace ECom.Foundation.ValidationAttributes;

// public class EnsureOneElementAttribute : ValidationAttribute
// {
//   public EnsureOneElementAttribute() {
//     ErrorMessageResourceName = "ensure_one_element";
//     ErrorMessageResourceType = typeof(LocalizedResource);
//   }
//
//   public string? Name { get; set; }
//
//   public override bool IsValid(object value) {
//     var list = value as IList;
//     return list is { Count: > 0 };
//   }
//
//   public override string FormatErrorMessage(string name) {
//     var message = ErrorMessageString;
//     return message.LocFormat("name", Name ?? name.ToLower());
//   }
// }