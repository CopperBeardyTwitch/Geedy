using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Geed.Interfaces;
using Geed.Models;
using Geed.ViewModels;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace Geed
{
    public partial class MainPage : ContentPage
    {
        AccountViewModel vm;

        public MainPage()
        {
            InitializeComponent();

            vm = new AccountViewModel();

            BindingContext = vm;

            DisplayAlert("hrm", "jem", "ok");
        }
        }
}

