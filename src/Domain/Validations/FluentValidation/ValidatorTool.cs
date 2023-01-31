using FluentValidation;
namespace ECom.Domain.CrossCuttingConcerns.Validations.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            //var result = validator.Validate(entity);
            //if (result.Errors.Count > 0)
            //{
                
            //    throw new ValidationException(result.Errors);
            //}
        }
    }
}
