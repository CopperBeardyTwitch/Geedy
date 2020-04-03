using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Geed.Interfaces;
using Geed.Models;
using Microsoft.Identity.Client;
using MvvmHelpers;
using Xamarin.Forms;

namespace Geed.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand SignInCommand { get; }
        public ICommand SignOutCommand { get; }

        public event EventHandler SuccessfulSignIn;
        public event EventHandler UnsuccessfulSignIn;

        private bool _loggedIn = false;
        private bool _notLoggedIn = true;

       public object user  ;

        AuthenticationResult _authResult;

        private readonly IIdentityService _identityService;

        public AccountViewModel()
        {
            SignInCommand = new Command(async () => await ExecuteSignInCommandAsync());
            SignOutCommand = new Command(ExecuteSignOutCommand);

            _identityService = DependencyService.Get<IIdentityService>();

            Task.Run(async () => await CheckLoginStatusAsync());
          
          

        }

       
        
   


        public bool LoggedIn
        {
            get => _loggedIn;
            set
            {
                SetProperty(ref _loggedIn, value);
                NotLoggedIn = !LoggedIn;
            }
        }

        public bool NotLoggedIn
        {
            get => _notLoggedIn;
            set => SetProperty(ref _notLoggedIn, value);
        }

        void ExecuteSignOutCommand()
        {
            if (IsBusy)
                return;

            if (NotLoggedIn)
                return;

            try
            {
                IsBusy = true;
                _identityService.Logout();
                LoggedIn = false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteSignInCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                _authResult = await _identityService.Login();
                var apiservice = DependencyService.Get<IWebAPIService>();

                user = apiservice.GetUserProfileAsync(_authResult.UniqueId, _authResult.AccessToken);

            }
            finally
            {
                IsBusy = false;
            }

            if (_authResult?.User == null)
            {
                LoggedIn = false;
                UnsuccessfulSignIn?.Invoke(this, new EventArgs());
            }
            else
            {
                LoggedIn = true;
                SuccessfulSignIn?.Invoke(this, new EventArgs());
            }
        }

        public async Task CheckLoginStatusAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                _authResult = await _identityService.GetCachedSignInTokenAsync();

                if (_authResult?.User != null)
                {
                    LoggedIn = true;
                    ExecuteSignOutCommand();

                }
                else
                {
                    Title = "Account";
                    LoggedIn = false;
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
