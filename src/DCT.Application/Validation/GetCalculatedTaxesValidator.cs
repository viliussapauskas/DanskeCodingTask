using DCT.Application.Models;
using FluentValidation;

namespace DCT.Application.Validation
{
    public class GetCalculatedTaxesValidator : AbstractValidator<GetCalculatedTaxesDTO>
    {
        public GetCalculatedTaxesValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}
