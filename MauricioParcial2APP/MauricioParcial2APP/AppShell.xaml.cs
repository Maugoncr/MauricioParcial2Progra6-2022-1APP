using MauricioParcial2APP.ViewModels;
using MauricioParcial2APP.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MauricioParcial2APP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
