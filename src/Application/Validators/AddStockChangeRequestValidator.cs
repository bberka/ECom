using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.DTOs.StockChangeDTOs;

namespace ECom.Application.Validators
{
    public class AddStockChangeRequestValidator : AbstractValidator<AddStockChangeRequest>, IValidator<AddStockChangeRequest>
    {
        public AddStockChangeRequestValidator()
        {

            RuleFor(x => x.Cost)
                .GreaterThan(0);

            RuleFor(x => x.Count)
                .GreaterThan(0);

            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.SupplierId)
                .GreaterThan(0);
        }
    }
}
