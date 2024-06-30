using FluentValidation;
using RoyalEstateDapperProject.Dtos.AgentDtos;

namespace RoyalEstateDapperProject.Validation.AgentDtos
{
    public class CreateAgentDtoValidator:AbstractValidator<CreateAgentDto>
    {
        public CreateAgentDtoValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad soyad boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
        }
    }
}
