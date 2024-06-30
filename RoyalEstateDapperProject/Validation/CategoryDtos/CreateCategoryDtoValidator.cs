using FluentValidation;
using RoyalEstateDapperProject.Dtos.CategoryDtos;

namespace RoyalEstateDapperProject.Validation.CategoryDtos
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
        }
    }
}
