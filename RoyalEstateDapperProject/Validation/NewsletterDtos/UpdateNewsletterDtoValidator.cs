using FluentValidation;
using RoyalEstateDapperProject.Dtos.NewsletterDtos;

namespace RoyalEstateDapperProject.Validation.NewsletterDtos
{
	public class UpdateNewsletterDtoValidator:AbstractValidator<UpdateNewsletterDto>
	{
        public UpdateNewsletterDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz. ");
        }
    }
}
