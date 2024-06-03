using AndroidBlog.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBlog.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.UserName.Value).NotEmpty().Matches("^(?=.*[a-zA-Z])[a-zA-Z0-9]{4,30}$").WithMessage("Username must have at least one letter and can't have special characters");

            RuleFor(x => x.FirstName.Value).NotEmpty().Matches("^[A-Z][a-z]{2,15}$").WithMessage("Please enter  name ex. Joe");

            RuleFor(x => x.LastName.Value).NotEmpty().Matches("^[A-Z][a-z]{2,15}(\\s([A-Z][az]{2,15})){0,3}$").WithMessage("Please enter last name ex. James");

            RuleFor(x => x.Email.Value).NotEmpty().EmailAddress();

            RuleFor(x => x.Password.Value).NotEmpty().Matches("^(?=.*[a-zA-Z])(?=.*\\d).{8,}$");
        }
    }
}
