using MauricioParcial2APP.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MauricioParcial2APP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}