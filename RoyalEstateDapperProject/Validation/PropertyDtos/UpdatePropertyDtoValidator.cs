using FluentValidation;
using RoyalEstateDapperProject.Dtos.PropertyDtos;

namespace RoyalEstateDapperProject.Validation.PropertyDtos
{
    public class UpdatePropertyDtoValidator:AbstractValidator<UpdatePropertyDto>
    {
        public UpdatePropertyDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("İlan başlığı boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İlan açıklaması boş bırakılamaz.");
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video linki boş bırakılamaz.");
            RuleFor(x => x.Sqft).NotNull().WithMessage("Metre kare boş bırakılamaz.");
            RuleFor(x => x.Bathroom).NotNull().WithMessage("Banyo sayısı boş bırakılamaz.");
            RuleFor(x => x.Bedroom).NotNull().WithMessage("Yatak sayısı boş bırakılamaz.");
            RuleFor(x => x.Price).NotNull().WithMessage("Fiyat boş bırakılamaz.");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("Kategori boş bırakılamaz.");
            RuleFor(x => x.LocationId).NotNull().WithMessage("Lokasyon boş bırakılamaz.");
            RuleFor(x => x.ImageUrl1).NotEmpty().WithMessage("Görsel 1 boş bırakılamaz.");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel 2 boş bırakılamaz.");
            RuleFor(x => x.ImageUrl3).NotEmpty().WithMessage("Görsel 3 boş bırakılamaz.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş bırakılamaz.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("İlan durumu boş bırakılamaz.");
        }
    }
}
