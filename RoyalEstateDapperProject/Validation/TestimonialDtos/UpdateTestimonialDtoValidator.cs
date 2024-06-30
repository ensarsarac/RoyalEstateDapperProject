using FluentValidation;
using RoyalEstateDapperProject.Dtos.TestimonialDtos;

namespace RoyalEstateDapperProject.Validation.TestimonialDtos
{
    public class UpdateTestimonialDtoValidator:AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialDtoValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad soyad boş bırakılamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel boş bırakılamaz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş bırakılamaz.");
        }
    }
}
