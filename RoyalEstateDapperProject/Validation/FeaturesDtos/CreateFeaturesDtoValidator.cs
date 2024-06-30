using FluentValidation;
using RoyalEstateDapperProject.Dtos.FeaturesDtos;

namespace RoyalEstateDapperProject.Validation.FeaturesDtos
{
    public class CreateFeaturesDtoValidator:AbstractValidator<CreateFeaturesDto>
    {
        public CreateFeaturesDtoValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon boş bırakılamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
        }
    }
}
