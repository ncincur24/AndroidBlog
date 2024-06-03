using AndroidBlog.Common;
using AndroidBlog.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBlog.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public RegistrationViewModel()
        {
            Email.OnValueChange = Validate;
            Password.OnValueChange = Validate;
            UserName.OnValueChange = Validate;
            FirstName.OnValueChange = Validate;
            LastName.OnValueChange = Validate;

            IsRegisterButtonEnabled = false;

            Email.Value = "";
            Password.Value = "";
            UserName.Value = "";
            FirstName.Value = "";
            LastName.Value = "";

            Email.Error = "";
            Password.Error = "";
            UserName.Error = "";
            FirstName.Error = "";
            LastName.Error = "";
        }

        public MProp<string> FirstName { get; set; } = new MProp<string>();
        public MProp<string> LastName { get; set; } = new MProp<string>();
        public MProp<string> UserName { get; set; } = new MProp<string>();
        public MProp<string> Email { get; set; } = new MProp<string>();
        public MProp<string> Password { get; set; } = new MProp<string>();

        public bool IsRegisterButtonEnabled { get; set; }

        private void Validate()
        {
            var validator = new RegisterViewModelValidator();

            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                IsRegisterButtonEnabled = false;

                var firstNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("FirstName"));
                var lastNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("LastName"));
                var userNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("UserName"));
                var emailError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Email"));
                var passwordError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Password"));

                ErrorPrint(firstNameError, FirstName);
                ErrorPrint(lastNameError, LastName);
                ErrorPrint(userNameError, UserName);
                ErrorPrint(emailError, Email);
                ErrorPrint(passwordError, Password);
            }
            else
            {
                IsRegisterButtonEnabled = true;
                Email.Error = "";
                Password.Error = "";
                FirstName.Error = "";
                LastName.Error = "";
                UserName.Error = "";
            }

            OnPropertyChanged(nameof(IsRegisterButtonEnabled));
        }

        public void ErrorPrint(FluentValidation.Results.ValidationFailure checkError, MProp<string> printError)
        {
            if (checkError != null)
            {
                printError.Error = checkError.ErrorMessage;
            }
            else
            {
                printError.Error = "";
            }
        }
    }
}
