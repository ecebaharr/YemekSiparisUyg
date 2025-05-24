using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SignalR.DtoLayer.BookingDto;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Phone)
      .NotEmpty().WithMessage("Telefon alanı boş geçilemez!")
      .Matches(@"^\d{11}$").WithMessage("Lütfen geçerli bir telefon numarası girin (11 rakam)");
            RuleFor(x => x.Phone).Must(x => x.All(char.IsDigit)).WithMessage("Sadece rakam giriniz!");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez lütfen tarih seçimi yapınız!");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karakter yazınız").MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 karakter yapınız.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 karakter yazınız.");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi yazınız");
        }
    }
}
