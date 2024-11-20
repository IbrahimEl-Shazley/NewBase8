using NewBase.Core.Enums;
using NewBase.Core.Helpers.Validation;
using NewBase.Services.Interfaces.General;
using FluentValidation;
using NewBase.Service.Interfaces.General;
using NewBase.Core.Helpers;

namespace NewBase.Services.DTOs.Schema.SEC
{
    public class UserVerifyDTO
    {
        public string OTP { get; set; }
    }


    public class UserVerifyValidator : AbstractValidator<UserVerifyDTO>
    {
        public UserVerifyValidator(ICurrentUserService currentUserService)
        {
            var lang = currentUserService.Language;

            RuleFor(x => x.OTP)
                .NotEmpty().WithMessage(x => FluentValidationHelper.Message<UserVerifyDTO>(lang, MyConstants.ValidationLocalizationPath, nameof(x.OTP), ValidationTypesEnum.Required))
                .MinimumLength(4).WithMessage(x => FluentValidationHelper.Message<UserVerifyDTO>(lang, MyConstants.ValidationLocalizationPath, nameof(x.OTP), ValidationTypesEnum.MinLength, 4))
                .MaximumLength(4).WithMessage(x => FluentValidationHelper.Message<UserVerifyDTO>(lang, MyConstants.ValidationLocalizationPath, nameof(x.OTP), ValidationTypesEnum.MaxLength, 4));
        }

    }
}
