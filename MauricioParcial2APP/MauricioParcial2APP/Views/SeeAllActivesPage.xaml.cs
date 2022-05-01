using MauricioParcial2APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MauricioParcial2APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeeAllActivesPage : ContentPage
    {
        ActiveViewModel ActiveVM;

        public SeeAllActivesPage()
        {
            InitializeComponent();

            BindingContext = ActiveVM = new ActiveViewModel();

            LoadList();

        }


        private async void LoadList() {

            LstMyActives.ItemsSource = await ActiveVM.GetQList();
        
        }



    }
}