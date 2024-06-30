using FluentValidation;
using RoyalEstateDapperProject.Dtos.LocationDtos;

namespace RoyalEstateDapperProject.Validation.LocationDtos
{
    public class UpdateLocationDtoValidator:AbstractValidator<UpdateLocationDto>
    {
        public UpdateLocationDtoValidator()
        {
            RuleFor(x => x.Location).NotEmpty().WithMessage("Lokasyon boş bırakılamaz.");
        }
    }
}
