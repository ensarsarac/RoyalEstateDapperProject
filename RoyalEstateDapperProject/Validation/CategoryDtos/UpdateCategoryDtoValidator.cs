using FluentValidation;
using RoyalEstateDapperProject.Dtos.CategoryDtos;

namespace RoyalEstateDapperProject.Validation.CategoryDtos
{
    public class UpdateCategoryDtoValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
        }
    }
}
