using FluentValidation;
using RoyalEstateDapperProject.Dtos.LocationDtos;

namespace RoyalEstateDapperProject.Validation.LocationDtos
{
    public class CreateLocationDtoValidator:AbstractValidator<CreateLocationDto>
    {
        public CreateLocationDtoValidator()
        {
            RuleFor(x => x.Location).NotEmpty().WithMessage("Lokasyon boş bırakılamaz.");
        }
    }
}
