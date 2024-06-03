using AndroidBlog.Business;
using AndroidBlog.Business.DTO;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AndroidBlog;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void RegisterUserButton(object sender, EventArgs e)
    {
        RegistrationService registerService = new RegistrationService();
        RegistrationDTO registerDto = new RegistrationDTO
        {
            Email = this.Email.Text,
            Password = this.Password.Text,
            UserName = this.UserName.Text,
            FirstName = this.FirstName.Text,
            LastName = this.LastName.Text
        };

        bool isRegistred = registerService.RegisterUser(registerDto);
        if (isRegistred)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Green,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.Gray,
                CornerRadius = new CornerRadius(10),
            };

            string text = "Successful registration";
            string actionButtonText = "Close";
            TimeSpan duration = TimeSpan.FromSeconds(5);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
            Application.Current.MainPage = new MainPage();
        }
    }

    private void GoToLoginPage(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage();//new NavigationPage(new MainPage());
    }
}