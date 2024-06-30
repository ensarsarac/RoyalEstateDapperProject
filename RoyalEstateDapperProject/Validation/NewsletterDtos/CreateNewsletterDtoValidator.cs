using FluentValidation;
using RoyalEstateDapperProject.Dtos.NewsletterDtos;

namespace RoyalEstateDapperProject.Validation.NewsletterDtos
{
	public class CreateNewsletterDtoValidator:AbstractValidator<CreateNewsletterDto>
	{
        public CreateNewsletterDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
        }
    }
}
