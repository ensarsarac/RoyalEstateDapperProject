using FluentValidation;
using RoyalEstateDapperProject.Dtos.TagCloudDtos;

namespace RoyalEstateDapperProject.Validation.TagDtos
{
    public class UpdateTagDtoValidator:AbstractValidator<UpdateTagDto>
    {
        public UpdateTagDtoValidator()
        {
            RuleFor(x => x.TagName).NotEmpty().WithMessage("Tag adı boş bırakılamaz.");
        }
    }
}
