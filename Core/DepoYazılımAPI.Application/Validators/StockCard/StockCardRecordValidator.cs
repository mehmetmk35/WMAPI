using DepoYazılımAPI.Application.Features.Commands.StockCard.CreateStock;
using FluentValidation;

namespace DepoYazılımAPI.Application.Validators.StockCard
{
    public class CreateStockCardRecordValidator : AbstractValidator<CreateStockCommandRequest>
    {
        public CreateStockCardRecordValidator()
        {
            //RuleFor(s => s.StockName).NotEmpty().NotNull().WithMessage("Lütfen Stok İsmini Giriniz")
            //                        .MaximumLength(80).MinimumLength(2).WithMessage("Lütfen Stok Adını 2 ile 80 Arasında Tanımlayınız");

            RuleFor(s => s.StockCode).NotEmpty().NotNull().WithMessage("Lütfen Stok İsmini Giriniz")
                                    .MaximumLength(80).MinimumLength(2).WithMessage("Lütfen Stok Adını 2 ile 80 Arasında Tanımlayınız");
            RuleFor(s => s.CompanyName).NotEmpty().NotNull().WithMessage("Lütfen Şirket Giriniz");

            RuleFor(s => s.BranchCode).NotEmpty().NotNull().WithMessage("Lütfen Şube Giriniz");

            
            RuleFor(s => s.CreatedBy).NotEmpty().NotNull().WithMessage("Kullanıcı bilgisi girilmeli")
                                    .MaximumLength(80).MinimumLength(2).WithMessage("Lütfen Kullanıcı bilgisini 2 ile 80 Arasında Tanımlayınız");





        }
    }
}
