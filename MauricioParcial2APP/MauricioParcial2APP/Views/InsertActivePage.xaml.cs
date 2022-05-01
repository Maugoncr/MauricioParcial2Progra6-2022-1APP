
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauricioParcial2APP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MauricioParcial2APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertActivePage : ContentPage
    {
        ActiveViewModel vm;

        public InsertActivePage()
        {
            InitializeComponent();

            BindingContext = vm = new ActiveViewModel();

        }

        private async void CmdVolver(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            bool R = await vm.AddActive(TxtName.Text.Trim(),
                                           TxtArea.Text.Trim(),
                                           Decimal.Parse(TxtCost.Text.Trim()));
                                          

            if (R)
            {
                await DisplayAlert("Warning", "The active was added successfully", "OK");
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Warning", "Something went wrong", "OK");
            }


        }





    }
}