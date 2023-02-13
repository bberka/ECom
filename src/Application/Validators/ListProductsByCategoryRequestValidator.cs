using ECom.Domain.DTOs.Request;
using FluentValidation;

namespace ECom.Application.Validators
{
    public class ListProductsByCategoryRequestValidator : AbstractValidator<ListProductsByCategoryRequest>, IValidator<ListProductsByCategoryRequest>
	{
		public ListProductsByCategoryRequestValidator()
		{
			RuleFor(x => x.Page)
                .GreaterThan(0);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

        }

	}
}
