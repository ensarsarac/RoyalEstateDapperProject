using FluentValidation;
using RoyalEstateDapperProject.Dtos.TestimonialDtos;

namespace RoyalEstateDapperProject.Validation.TestimonialDtos
{
    public class CreateTestimonialDtoValidator:AbstractValidator<CreateTestimonialDto>
    {
        public CreateTestimonialDtoValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad soyad boş bırakılamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel boş bırakılamaz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş bırakılamaz.");
        }
    }
}
