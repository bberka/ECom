namespace ECom.Foundation.ValidationAttributes;

// public class CanNotBeEqualAttribute : ValidationAttribute
// {
//   public CanNotBeEqualAttribute(string propertyName) {
//     ArgumentException.ThrowIfNullOrEmpty(propertyName);
//     PropertyName = propertyName;
//     ErrorMessageResourceName = "can_not_be_equal";
//     ErrorMessageResourceType = typeof(LocalizedResource);
//   }
//
//   public string PropertyName { get; set; }
//
//   protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
//     var property = validationContext.ObjectType.GetProperty(PropertyName);
//     if (property == null) throw new ArgumentException($"Property {PropertyName} not found");
//     var propertyValue = property.GetValue(validationContext.ObjectInstance);
//     if (value == null || propertyValue == null) return ValidationResult.Success;
//     if (value.Equals(propertyValue)) {
//       var mainDisplayName = validationContext.DisplayName;
//       var resMgr = new ResourceManager(typeof(LocalizedResource));
//       var compareDisplayAttribute = property.GetCustomAttribute<DisplayAttribute>();
//       var compareLocKey = compareDisplayAttribute?.Name ?? PropertyName;
//       var compareDisplayName = resMgr.GetString(compareLocKey) ?? PropertyName;
//       return new ValidationResult(GetErrorMessage(mainDisplayName, compareDisplayName));
//     }
//
//     return ValidationResult.Success;
//   }
//
//   public override string FormatErrorMessage(string name) {
//     return ErrorMessageString;
//     var message = ErrorMessageString;
//     return message.LocFormat("name", name.ToLower());
//   }
//
//   private string GetErrorMessage(string mainDisplayName, string compareDisplayName) {
//     return ErrorMessageString
//            .LocFormat("mainPropertyName", mainDisplayName)
//            .LocFormat("comparePropertyName", compareDisplayName);
//   }
// }