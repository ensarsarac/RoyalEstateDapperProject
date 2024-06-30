using FluentValidation;
using RoyalEstateDapperProject.Dtos.TagCloudDtos;

namespace RoyalEstateDapperProject.Validation.TagDtos
{
    public class CreateTagDtoValidator:AbstractValidator<CreateTagDto>
    {
        public CreateTagDtoValidator()
        {
            RuleFor(x => x.TagName).NotEmpty().WithMessage("Tag adı boş bırakılamaz.");
        }
    }
}
